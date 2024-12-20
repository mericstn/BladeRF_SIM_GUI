
#include "rxtx.h"

// todo : printf ler duzeltilecel
void kanal_baslat(struct bladerf* cihaz_st, kanal_t* kanal_st)
{
	printf("Kanal (%s) parametreleri ayarlaniyor.\n", kanal_st->channel_name);

	HATA_KONTROL(
		bladerf_set_sample_rate(cihaz_st, kanal_st->channel_i32, kanal_st->sample_rate_u32, NULL),
		"Kanal ornekleme hizi ayarlanamadi ! "
	);
	
	HATA_KONTROL(
		bladerf_set_frequency(cihaz_st, kanal_st->channel_i32, kanal_st->frequency_u64),
		"Kanal frekansi ayarlanamadi ! "
	);

	HATA_KONTROL(
		bladerf_set_gain_mode(cihaz_st, kanal_st->channel_i32, BLADERF_GAIN_MGC),
		"Kanal kazanc modu ayarlanamadi ! "
	);

	HATA_KONTROL(
		bladerf_set_gain(cihaz_st, kanal_st->channel_i32, kanal_st->gain_i32),
		"Kanal kazanci ayarlanamadi ! "
	);

	HATA_KONTROL(
		bladerf_set_bandwidth(cihaz_st, kanal_st->channel_i32, kanal_st->bandwidth_u32, 0),
		"Kanal bant genisligi ayarlanamadi ! "
	);
	
	HATA_KONTROL(
		bladerf_enable_module(cihaz_st, kanal_st->channel_i32, true),
		"Kanal aktiflestirilemedi ! "
	);

	printf("Kanal (%s) basariyla baslatildi.\n", kanal_st->channel_name);

}

void kanal_bilgi_yazdir(struct bladerf* cihaz_st, kanal_t* kanal_st)
{
	bladerf_sample_rate sample_rate;
	bladerf_frequency	frequency;
	bladerf_gain		gain;
	bladerf_bandwidth	bandwidth;

	HATA_KONTROL(
		bladerf_get_sample_rate(cihaz_st, kanal_st->channel_i32, &sample_rate),
		"Ornekleme hizi alinamadi"
	);
	printf("Kanal: %s - Ornekleme Hizi: %d Hz\n", kanal_st->channel_name, sample_rate);

	HATA_KONTROL(
		bladerf_get_frequency(cihaz_st, kanal_st->channel_i32, &frequency),
		"Frekans alinamadi"
	);
	printf("Kanal: %s - Frekans: %ld Hz\n", kanal_st->channel_name, frequency);

	HATA_KONTROL(
		bladerf_get_gain(cihaz_st, kanal_st->channel_i32, &gain),
		"Kazanc alinamadi"
	);
	printf("Kanal: %s - Kazanc: %d dB\n", kanal_st->channel_name, gain);

	HATA_KONTROL(
		bladerf_get_bandwidth(cihaz_st, kanal_st->channel_i32, &bandwidth),
		"Bant Genisligi alinamadi"
	);
	printf("Kanal: %s - Bant Genisligi: %d Hz\n", kanal_st->channel_name, bandwidth);

}


// todo : duzenle
/* Just retransmit the received samples */
/* From example*/
bool do_work(rxtx_parametreleri_t* rxtx_parametreleri_st, int16_t* rx, unsigned int rx_len, bool* have_tx_data, int16_t* tx, unsigned int tx_len)
{
	static unsigned int call_no = 0;
	assert(tx_len == rx_len);
	memcpy(tx, rx, rx_len * 2 * sizeof(int16_t));
	*have_tx_data = true;

	return (++call_no >= rxtx_parametreleri_st->ornek_alma_gonderme_sayisi_u32);
}


void mod_rxtx(struct bladerf* cihaz_st, rxtx_parametreleri_t* rxtx_parametreleri_st, kanal_t* tx_kanal_st, kanal_t* rx_kanal_st)
{

	/*--------------------------------------------Cihaz Kanal Parametrelerini Kur-------------------------------------------- */

	kanal_baslat(cihaz_st, tx_kanal_st);
	kanal_bilgi_yazdir(cihaz_st, tx_kanal_st);
	bias_tee_t			bias_tee_et;


	bladerf_set_bias_tee(cihaz_st, RX1, true);


	bladerf_get_bias_tee(cihaz_st, RX1, &bias_tee_et);

	printf("RX Bias Tee Durumu: %s\n", rx_kanal_st->bias_tee_et == true ? "Aktif" : "Kapali");
	printf("Kanal: %s - Bias Tee Durumu: %s\n", rx_kanal_st->channel_name, (bias_tee_et == true) ? "Aktif" : "Kapali");

	kanal_baslat(cihaz_st, rx_kanal_st);
	kanal_bilgi_yazdir(cihaz_st, rx_kanal_st);

	/*--------------------------------------------Ana Program Ayarlari (Sync)---------------------------------------------------*/
	int8_t durum_i8 = 0;
	islem_durumu_t tamam		 = DURUM_BEKLIYOR;
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

	uint8_t		tampon_sayisi_u8		= rxtx_parametreleri_st->tampon_sayisi_u8;	
	uint32_t	tampon_boyutu_u32		= rxtx_parametreleri_st->tampon_boyutu_u32; /* Must be a multiple of 1024 */
	uint8_t     veri_transfer_sayisi_u8 = rxtx_parametreleri_st->veri_transfer_sayisi_u8;
	uint16_t    zaman_asimi_16t			= rxtx_parametreleri_st->zaman_asimi_16t;

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

	/*--------------------------------------------Ana Program Dongusu-----------------------------------------------------*/

	printf("Islem basladi !");
	while (durum_i8 == 0 && !tamam)
	{
		// ornek al
		durum_i8 = bladerf_sync_rx(cihaz_st, rx_ornekleri_i16a, ornek_uzunlugu_u16, NULL, RX_TIMEOUT);
		if (durum_i8 == 0)
		{
			tamam = do_work(rxtx_parametreleri_st,rx_ornekleri_i16a, ornek_uzunlugu_u16, &tx_verisi_var, tx_ornekleri_i16a, ornek_uzunlugu_u16);
			// ornek gonder
			if (!tamam && tx_verisi_var)
			{

				durum_i8 = bladerf_sync_tx(cihaz_st, tx_ornekleri_i16a, ornek_uzunlugu_u16, NULL, TX_TIMEOUT);
				if (durum_i8 != 0)
				{
					printf("TX ornegi gonderilemedi ! ");
				}
			}
		}
		else
		{
			printf("RX ornegi alinamadi ! ");
		}
	}

	/*--------------------------------------------Program Sonu-------------------------------------------------------------*/

	if (cihaz_st != NULL) {
		bladerf_close(cihaz_st);
	}
	// TODO
	// kanal kapat fonksiyonu // bladerf_enable_module(dev, BLADERF_RX, false);
	printf("Program sonlandirildi.\n");
}
