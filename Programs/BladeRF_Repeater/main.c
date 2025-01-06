
#include "get_parameter.h"
#include "parameters.h"
#include "mod_rxtx.h"
#include "mod_tx.h"


int main(int argc, char* argv[]) 
{

	/*---------------Program Argumanlari ------------*/

	if (argc < 2) {
		kullanim_talimati(argv[0]);
		exit(1);
	}
	const char* dosya_adi = argv[1];

	FILE* dosya = fopen(dosya_adi, "r");

	if (dosya == NULL) 
	{
		printf("Dosya acilamadi: %s ! \n", dosya_adi); 
		kullanim_talimati(argv[0]);
		exit(1);
	}

	/*---------------Varsayilan Parametreler------------*/

	program_t			 program_st				= { 0 };
	kanal_t				 tx_kanal_st			= { 0 };
	kanal_t				 rx_kanal_st			= { 0 };
	rxtx_parametreleri_t rxtx_parametreleri_st	= { 0 };
	tx_parametreleri_t   tx_parametreleri_st	= { 0 };
	// todo : tx_parametreleri
	// todo : rx_parametreleri

	strcpy(tx_kanal_st.channel_name, TX_CHANNEL_NAME);
	tx_kanal_st.channel_i32			= TX2;
	tx_kanal_st.sample_rate_u32		= TX_SAMPLE_RATE;
	tx_kanal_st.frequency_u64		= TX_FREQ;
	tx_kanal_st.gain_i32			= TX_GAIN;
	tx_kanal_st.bandwidth_u32		= TX_BANDWIDTH;
	tx_kanal_st.bias_tee_et			= BIAS_TEE_KAPALI;
	tx_kanal_st.timeout_u32			= TX_TIMEOUT;

	strcpy(rx_kanal_st.channel_name, RX_CHANNEL_NAME);
	rx_kanal_st.channel_i32			= RX1;
	rx_kanal_st.sample_rate_u32		= RX_SAMPLE_RATE;
	rx_kanal_st.frequency_u64		= RX_FREQ;
	rx_kanal_st.gain_i32			= RX_GAIN;
	rx_kanal_st.bandwidth_u32		= RX_BANDWIDTH;
	rx_kanal_st.bias_tee_et			= BIAS_TEE_AKTIF;
	rx_kanal_st.timeout_u32			= RX_TIMEOUT;

	program_st.cihaz_versiyon_et		= BLADERF_V2;
	program_st.mod_et					= RXTX;
	program_st.program_sure_saniye_u32	= PROG_SURE_SANIYE;

	rxtx_parametreleri_st.ornek_uzunlugu_u16				= RXTX_ORNEK_UZUNLUGU;
	rxtx_parametreleri_st.tampon_boyutu_u32					= RXTX_TAMPON_BOYUTU;
	rxtx_parametreleri_st.tampon_sayisi_u8					= RXTX_TAMPON_SAYISI;
	rxtx_parametreleri_st.veri_transfer_sayisi_u8			= RXTX_VERI_TRANSFER_SAYISI;
	rxtx_parametreleri_st.zaman_asimi_16t					= RXTX_ZAMAN_ASIMI;
	rxtx_parametreleri_st.ornek_alma_gonderme_sayisi_u32	= RXTX_ORNEK_ALMA_GONDERME_SAYISI;



	/*-----------------------Dosyadan Okuma----------------------------------*/

	uint16_t parametre_sayisi_u16		= 0;
	parametre_oku_csv(dosya, &rxtx_parametreleri_st, &tx_parametreleri_st, &tx_kanal_st, &rx_kanal_st, &program_st,&parametre_sayisi_u16);

	if (TOPLAM_PARAMETRE_SAYISI != parametre_sayisi_u16)
	{
		printf(" Yetersiz parametre,\n gerekli : %d, mevcut : %d\n", TOPLAM_PARAMETRE_SAYISI, parametre_sayisi_u16);
		exit(1);
	}



	/*-------------------------------------------Bagli Cihazlari Kontrol Et--------------------------------------------*/

	struct bladerf_devinfo* cihaz_listesi_sta = NULL;
	struct bladerf* cihaz_st				  = NULL;
	int16_t	cihaz_sayisi_i16				  = 0;
	uint8_t uygun_cihaz_id_u8				  = 255;
	cihaz_sayisi_i16						  = bladerf_get_device_list(&cihaz_listesi_sta);

	if (cihaz_sayisi_i16 < 0) printf( "Cihaz listesi alinamadi: %s\n", bladerf_strerror(cihaz_sayisi_i16));
	

	for (int i = 0; i < cihaz_sayisi_i16; i++)
	{
		printf("Cihaz %d: Cihaz Model: %s, Seri No: %s\n", i, cihaz_listesi_sta[i].product, cihaz_listesi_sta[i].serial);

		if (strcmp(cihaz_listesi_sta[i].product, "bladeRF 2.0") == 0 && program_st.cihaz_versiyon_et == BLADERF_V2)
		{
			printf("Cihaz %d uygun: Seri No: %s, Versiyon: BLADERF V2\n", i, cihaz_listesi_sta[i].serial);
			uygun_cihaz_id_u8 = i;
			break;
		}
		else if (strcmp(cihaz_listesi_sta[i].product, "bladeRF 1.0") == 0 && program_st.cihaz_versiyon_et == BLADERF_V1)
		{
			printf("Cihaz %d uygun: Seri No: %s, Versiyon: BLADERF V1\n", i, cihaz_listesi_sta[i].serial);
			uygun_cihaz_id_u8 = i;
			break;
		}
	}

	if (uygun_cihaz_id_u8 == 255)
	{
		printf( "Uygun cihaz bulunamadi! Lutfen dogru versiyonu secin ! \n");
		bladerf_free_device_list(cihaz_listesi_sta);
		exit(1);
	}


	/*--------------------------------------------Cihazi Ac-----------------------------------------------------------*/
	HATA_KONTROL(
		bladerf_open_with_devinfo(&cihaz_st, &cihaz_listesi_sta[uygun_cihaz_id_u8]),
		"Cihaz acilamadi!!"
	);
	printf("Cihaz basariyla acildi!\n");


	/*--------------------------------------------Uygulama Baþlat-----------------------------------------------------------*/

	switch (program_st.mod_et)
	{
	case(RXTX):
		printf("RXTX modu calistiriliyor...\n");
		mod_rxtx(cihaz_st, &rxtx_parametreleri_st, &tx_kanal_st, &rx_kanal_st,&program_st);
		break;
	case(RX):
		printf("RX modu calistiriliyor...\n");
		break;
	case(TX):
		printf("TX modu calistiriliyor...\n");
		mod_tx(cihaz_st, &tx_parametreleri_st, &tx_kanal_st);
		break;
	default:
		printf("Mod gecerli degil!\n");
		break;
	}

	/*--------------------------------------------Program Sonlandir-----------------------------------------------------------*/

	HATA_KONTROL(
		bladerf_enable_module(cihaz_st, BLADERF_TX, false),
		"TX port kapatilamadi ! "
	);
	printf("\n TX port kapatildi.\n");
	HATA_KONTROL(
		bladerf_enable_module(cihaz_st, BLADERF_RX, false),
		"RX port kapatilamadi ! "
	);
	printf("\n RX port kapatildi.\n");
	bladerf_close(cihaz_st);

	printf("\nProgram Sonlandirildi.\n");

	return 0;
}


