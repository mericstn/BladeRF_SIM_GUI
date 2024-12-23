#pragma once



#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>
#include <inttypes.h>
#include <time.h>
#include "parameters.h"
#include "channel.h"



#define BUFFER_SIZE 2048
#define NUM_SAMPLES 4096
#define NUM_TRANSFERS 16
#define TIMEOUT_MS 1000

typedef struct {
    char tx_dosya[255];
} tx_parametreleri_t;



int wait_for_timestamp(struct bladerf* dev,
    bladerf_direction dir,
    uint64_t timestamp,
    unsigned int timeout_ms);


size_t read_samples_from_file(FILE* file, int16_t* buffer, size_t max_samples);


void mod_tx(struct bladerf* cihaz_st, tx_parametreleri_t* tx_parametreleri_st, kanal_t* tx_kanal_st);