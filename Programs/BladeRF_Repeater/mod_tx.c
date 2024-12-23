#include "mod_tx.h"
#include <sys/stat.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <time.h>
#include <inttypes.h>

// TX için bekleme fonksiyonu
int wait_for_timestamp(struct bladerf* dev,
    bladerf_direction dir,
    uint64_t timestamp,
    unsigned int timeout_ms)
{
    int status;
    uint64_t curr_ts = 0;
    unsigned int slept_ms = 0;
    bool done;

    do {
        status = bladerf_get_timestamp(dev, dir, &curr_ts);
        done = (status != 0) || curr_ts >= timestamp;

        if (!done) {
            if (slept_ms > timeout_ms) {
                done = true;
                status = BLADERF_ERR_TIMEOUT;
            }
            else {
                // Bekleme için zaman kontrolü
                slept_ms += 10;
                clock_t start_time = clock();
                while (clock() - start_time < CLOCKS_PER_SEC / 100) {} // 10ms bekleme
            }
        }
    } while (!done);

    return status;
}

// Dosyadan örnek okuma fonksiyonu
size_t read_samples_from_file(FILE* file, int16_t* buffer, size_t max_samples) {
    size_t samples_read = fread(buffer, sizeof(int16_t), max_samples, file);
    return samples_read;
}

// TX iþlevi
void mod_tx(struct bladerf* cihaz_st, tx_parametreleri_t* tx_parametreleri_st, kanal_t* tx_kanal_st)
{
    kanal_baslat(cihaz_st, tx_kanal_st);
    kanal_bilgi_yazdir(cihaz_st, tx_kanal_st);

    int status = 0;
    int16_t* samples = NULL;
    struct bladerf_metadata meta;
    FILE* file;
    size_t samples_read = 0;

    file = fopen("C:\\Users\\PC_3740\\Desktop\\proje\\BladeRF_SIM_GUI\\Programs\\BladeRF_Repeater\\x64\\Debug\\test.bin", "rb");
    if (file == NULL) {
        perror("fopen");
        exit(1);
    }

    // Bellek tahsisi
    samples = (int16_t*)malloc(NUM_SAMPLES * 2 * sizeof(int16_t)); // Ýki kanal (I ve Q) için
    if (samples == NULL) {
        perror("malloc");
        fclose(file);
        exit(1);
    }

    // BladeRF senkronizasyon yapýlandýrmasý
    const unsigned int num_buffers = 32;
    const unsigned int buffer_size = BUFFER_SIZE;
    status = bladerf_sync_config(cihaz_st, BLADERF_TX_X1, BLADERF_FORMAT_SC16_Q11_META, num_buffers, buffer_size, NUM_TRANSFERS, TIMEOUT_MS);
    if (status != 0) {
        fprintf(stderr, "Sync config failed: %s\n", bladerf_strerror(status));
        free(samples);
        fclose(file);
        return;
    }

    // TX modülünü etkinleþtir
    status = bladerf_enable_module(cihaz_st, BLADERF_TX, true);
    if (status != 0) {
        fprintf(stderr, "Failed to enable TX module: %s\n", bladerf_strerror(status));
        free(samples);
        fclose(file);
        return;
    }

    memset(&meta, 0, sizeof(meta));
    meta.flags = BLADERF_META_FLAG_TX_NOW;

    // TX iþlemine baþla
    while ((samples_read = read_samples_from_file(file, samples, NUM_SAMPLES * 2)) > 0) {
        if (samples_read < NUM_SAMPLES * 2) {
            // Eksik veri varsa, tamponu sýfýrlarla doldur
            memset(samples + samples_read, 0, (NUM_SAMPLES * 2 - samples_read) * sizeof(int16_t));
            meta.flags |= BLADERF_META_FLAG_TX_BURST_END;
        }

        // Veriyi gönder
        status = bladerf_sync_tx(cihaz_st, samples, NUM_SAMPLES, &meta, TIMEOUT_MS);
        if (status != 0) {
            fprintf(stderr, "TX failed: %s\n", bladerf_strerror(status));
            break;
        }
    }

    // TX bitiþi için bekle
    if (status == 0) {
        status = bladerf_get_timestamp(cihaz_st, BLADERF_TX, &meta.timestamp);
        if (status != 0) {
            fprintf(stderr, "Failed to get current TX timestamp: %s\n", bladerf_strerror(status));
        }
        else {
            status = wait_for_timestamp(cihaz_st, BLADERF_TX, meta.timestamp + 2 * NUM_SAMPLES, TIMEOUT_MS);
            if (status != 0) {
                fprintf(stderr, "Failed to wait for timestamp.\n");
            }
        }
    }

    // Temizlik
    free(samples);
    fclose(file);
}
