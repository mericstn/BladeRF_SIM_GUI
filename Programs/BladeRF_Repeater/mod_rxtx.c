#include "mod_rxtx.h"
#include "new.h"
#include <signal.h>
#include <pthread.h>
#include <stdio.h>
#include <windows.h>
volatile bool ctrl_c_basildi = false;

void handle_signal(int signal) // SIGINT sinyali için iþleyici
{
	if (signal == SIGINT)
	{
		ctrl_c_basildi = true; // Ctrl+C ile durumu true yap
	}
}

bool do_work(int16_t* rx, unsigned int rx_len, bool* have_tx_data, int16_t* tx, unsigned int tx_len)
{
	assert(tx_len == rx_len);
	memcpy(tx, rx, rx_len * 2 * sizeof(int16_t));
	*have_tx_data = true;

	return true;
}

void mod_rxtx(struct bladerf* cihaz_st, rxtx_parametreleri_t* rxtx_parametreleri_st, kanal_t* tx_kanal_st, kanal_t* rx_kanal_st, program_t* program_st)
{


	/*--------------------------------------------Cihaz Kanal Parametrelerini Kur-------------------------------------------- */

	kanal_baslat(cihaz_st, tx_kanal_st);
	kanal_bilgi_yazdir(cihaz_st, tx_kanal_st);
	bias_tee_t			bias_tee_et;

	
	bladerf_set_bias_tee(cihaz_st, RX2, false);   
	bladerf_get_bias_tee(cihaz_st, RX2, &bias_tee_et); // Bug mevcut

	printf("RX Bias Tee Durumu: %s\n", rx_kanal_st->bias_tee_et == true ? "Aktif" : "Kapali");
	//printf("Kanal: %s - Bias Tee Durumu: %s\n", rx_kanal_st->channel_name, (bias_tee_et == true) ? "Aktif" : "Kapali");

	kanal_baslat(cihaz_st, rx_kanal_st);
	kanal_bilgi_yazdir(cihaz_st, rx_kanal_st);

	/*--------------------------------------------Ana Program Ayarlari (Sync)---------------------------------------------------*/
	int8_t durum_i8 = 0;
	islem_durumu_t tamam = DURUM_BEKLIYOR;
	veri_durumu_t  tx_verisi_var = VERI_YOK;

	/*--------TX RX ornekleri tampon ayarlari-----*/
	int16_t* rx_ornekleri_i16a = NULL;
	int16_t* tx_ornekleri_i16a = NULL;
	const uint16_t ornek_uzunlugu_u16 = rxtx_parametreleri_st->ornek_uzunlugu_u16;

	rx_ornekleri_i16a = malloc(ornek_uzunlugu_u16 * 2 * 1 * sizeof(int16_t));

	if (rx_ornekleri_i16a == NULL)
	{
		printf("RX bellek ayirma hatasi ! \n");
		exit(1);
	}

	tx_ornekleri_i16a = malloc(ornek_uzunlugu_u16 * 2 * 1 * sizeof(int16_t));

	if (tx_ornekleri_i16a == NULL)
	{
		printf("TX bellek ayirma hatasi ! \n");
		free(rx_ornekleri_i16a);
		exit(1);
	}


	/*-------Senkron parametre Ayarlamalari------*/

	uint8_t		tampon_sayisi_u8 = rxtx_parametreleri_st->tampon_sayisi_u8;
	uint32_t	tampon_boyutu_u32 = rxtx_parametreleri_st->tampon_boyutu_u32; /* Must be a multiple of 1024 */
	uint8_t     veri_transfer_sayisi_u8 = rxtx_parametreleri_st->veri_transfer_sayisi_u8;
	uint16_t    zaman_asimi_16t = rxtx_parametreleri_st->zaman_asimi_16t;

	HATA_KONTROL(
		bladerf_sync_config(cihaz_st, BLADERF_TX_X1, BLADERF_FORMAT_SC16_Q11,
			tampon_sayisi_u8, tampon_boyutu_u32, veri_transfer_sayisi_u8,
			zaman_asimi_16t),
		"Senkron TX ayari basarisiz !"
	);

	HATA_KONTROL(
		bladerf_sync_config(cihaz_st, BLADERF_RX_X1, BLADERF_FORMAT_SC16_Q11,
			tampon_sayisi_u8, tampon_boyutu_u32, veri_transfer_sayisi_u8,
			zaman_asimi_16t),
		"Senkron RX ayari basarisiz !"
	);

	HATA_KONTROL(
		bladerf_enable_module(cihaz_st, tx_kanal_st->channel_i32, true),
		"TX Kanal aktiflestirilemedi ! "
	);

	HATA_KONTROL(
		bladerf_enable_module(cihaz_st, rx_kanal_st->channel_i32, true),
		"RX Kanal aktiflestirilemedi ! "
	);


	/*--------------------------------------------Ana Program Dongusu-----------------------------------------------------*/
	clock_t baslangic_zamani = clock();
	clock_t simdiki_zaman;
	double gecen_zaman;
	bool done = false;

	printf("Islem basladi !");

	while (durum_i8 == 0 && !tamam && !ctrl_c_basildi)
	{
		simdiki_zaman = clock();
		gecen_zaman = (double)(simdiki_zaman - baslangic_zamani) / CLOCKS_PER_SEC;

		printf("\rGecen Sure: %.3f saniye", gecen_zaman);
		fflush(stdout);

		if (0 != program_st->program_sure_saniye_u32)
		{
			if (gecen_zaman >= program_st->program_sure_saniye_u32) break;
		}

		
		durum_i8 = bladerf_sync_rx(cihaz_st, rx_ornekleri_i16a, ornek_uzunlugu_u16, NULL, RX_TIMEOUT);
		if (durum_i8 == 0)
		{
			done = do_work(rx_ornekleri_i16a, ornek_uzunlugu_u16, &tx_verisi_var, tx_ornekleri_i16a,
				ornek_uzunlugu_u16);
			
			if (done && tx_verisi_var)
			{
				durum_i8 = bladerf_sync_tx(cihaz_st, tx_ornekleri_i16a, ornek_uzunlugu_u16, NULL, TX_TIMEOUT);
				if (durum_i8 != 0) {
					printf("TX ornegi gonderilemedi !\n");
				}
			}
		}
		else
		{
			printf("RX ornegi alinamadi !\n");
		}
		if (durum_i8 == 0) {
			/* Wait a few seconds for any remaining TX samples to finish
			 * reaching the RF front-end */
			Sleep(500);
		}
		/*clock_t hedef_zaman = clock() + CLOCKS_PER_SEC / 10;
		while (clock() < hedef_zaman) {
			
		}*/
	}


}



