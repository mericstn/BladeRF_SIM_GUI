
#include "get_parameter.h"
#include "parameters.h"
#include "rxtx.h"

void kullanim_talimati(const char* program_adi)
{
	printf("Kullanim: %s <csv_dosya_adi>\n", program_adi);
}

int main(int argc, char* argv[]) {

	if (argc < 2) {
		kullanim_talimati(argv[0]);
		exit(1);
	}
	const char* dosya_adi = argv[1];

	FILE* dosya = fopen(dosya_adi, "r");

	if (dosya == NULL) {
		printf("Dosya acilamadi: %s, Varsayilan paramatreler kullaniliyor ! \n", dosya_adi); // todo : null pointer oluyor hatayi coz
	}
	/*---------------Varsayilan Parametreler------------*/
	
	program_t			 program_st			   = { 0 };
	kanal_t				 tx_kanal_st		   = { 0 };
	kanal_t				 rx_kanal_st		   = { 0 };
	rxtx_parametreleri_t rxtx_parametreleri_st = { 0 };
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

	program_st.cihaz_versiyon_et = BLADERF_V2;
	program_st.mod_et			 = RXTX;

	rxtx_parametreleri_st.ornek_uzunlugu_u16			 = RXTX_ORNEK_UZUNLUGU;
	rxtx_parametreleri_st.tampon_boyutu_u32				 = RXTX_TAMPON_BOYUTU;
	rxtx_parametreleri_st.tampon_sayisi_u8				 = RXTX_TAMPON_SAYISI;
	rxtx_parametreleri_st.veri_transfer_sayisi_u8		 = RXTX_VERI_TRANSFER_SAYISI;
	rxtx_parametreleri_st.zaman_asimi_16t				 = RXTX_ZAMAN_ASIMI;
	rxtx_parametreleri_st.ornek_alma_gonderme_sayisi_u32 = RXTX_ORNEK_ALMA_GONDERME_SAYISI;


	/*-----------------------Dosyadan Okuma----------------------------------*/
	
	char satir[256]				= { 0 };
	char parametre[128]			= { 0 };
	char deger[128]				= { 0 };
	uint8_t parametre_sayisi_u8 = 0;


	// not : hash table ile temize cekilebilir
	while (dosya != NULL && fgets(satir, sizeof(satir), dosya)) {
	
		satir[strcspn(satir, "\n")] = '\0';

		if (satir_ayristir(satir, parametre, deger))
		{
			/* TX Parametreleri*/
			if (strcmp(parametre, "kanal_tx_kanal_adi") == 0)
			{
				strncpy(tx_kanal_st.channel_name, deger, sizeof(tx_kanal_st.channel_name) - 1);
				tx_kanal_st.channel_name[sizeof(tx_kanal_st.channel_name) - 1] = '\0';
			}
			else if (strcmp(parametre, "kanal_tx_kanal") == 0) 
			{
				tx_kanal_st.channel_i32 = (atoi(deger) == 1) ? TX2 : TX1;					
			}
			else if (strcmp(parametre, "kanal_tx_frekans") == 0) 
			{
				tx_kanal_st.frequency_u64 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_ornekleme_orani") == 0)
			{
				tx_kanal_st.sample_rate_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_bant_genisligi") == 0)
			{
				tx_kanal_st.bandwidth_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_kazanc") == 0)
			{
				tx_kanal_st.gain_i32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_zaman_asimi") == 0)
			{
				tx_kanal_st.timeout_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_bias_tee") == 0)
			{
				tx_kanal_st.bias_tee_et = (atoi(deger) == 1) ? BIAS_TEE_AKTIF : BIAS_TEE_KAPALI;
			}
			/* RX Parametreleri*/
			else if (strcmp(parametre, "kanal_rx_kanal_adi") == 0)
			{
				strncpy(rx_kanal_st.channel_name, deger, sizeof(rx_kanal_st.channel_name) - 1);
				rx_kanal_st.channel_name[sizeof(rx_kanal_st.channel_name) - 1] = '\0'; // Null sonlandýrma
			}
			else if (strcmp(parametre, "kanal_rx_kanal") == 0) 
			{
				rx_kanal_st.channel_i32 = (atoi(deger) == 1) ? RX2 : RX1;
			}
			else if (strcmp(parametre, "kanal_rx_frekans") == 0)
			{
				rx_kanal_st.frequency_u64 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_ornekleme_orani") == 0)
			{
				rx_kanal_st.sample_rate_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_bant_genisligi") == 0)
			{
				rx_kanal_st.bandwidth_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_kazanc") == 0)
			{
				rx_kanal_st.gain_i32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_zaman_asimi") == 0)
			{
				rx_kanal_st.timeout_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_bias_tee") == 0)
			{
				rx_kanal_st.bias_tee_et = (atoi(deger) == 1) ? BIAS_TEE_AKTIF : BIAS_TEE_KAPALI;
			}
			/*Program Parametreleri*/
			else if (strcmp(parametre, "prog_cihaz_versiyon") == 0)
			{
				program_st.cihaz_versiyon_et = (atoi(deger) == 2) ? BLADERF_V2 : BLADERF_V1;
			}
			else if (strcmp(parametre, "prog_mod") == 0)
			{
				if (strcmp(deger, "RXTX") == 0)
				{
					program_st.mod_et = RXTX;
				}
				else if (strcmp(deger, "TX") == 0)
				{
					program_st.mod_et = TX;
				}
				else if (strcmp(deger, "RX") == 0)
				{
					program_st.mod_et = RX;
				}			
			}
			/* Senkron Veri Iletim Parametreleri*/
			else if (strcmp(parametre, "rxtx_ornek_uzunlugu") == 0)
			{
				rxtx_parametreleri_st.ornek_uzunlugu_u16 = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_tampon_boyutu") == 0)
			{
				rxtx_parametreleri_st.tampon_boyutu_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_tampon_sayisi") == 0)
			{
				rxtx_parametreleri_st.tampon_sayisi_u8 = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_veri_transfer_sayisi") == 0)
			{
				rxtx_parametreleri_st.veri_transfer_sayisi_u8 = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_zaman_asimi") == 0)
			{
				rxtx_parametreleri_st.zaman_asimi_16t = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_ornek_alma_gonderme_sayisi") == 0)
			{
				rxtx_parametreleri_st.ornek_alma_gonderme_sayisi_u32 = atoi(deger);
			}
			else {
				printf("Bilinmeyen parametre: %s\n", parametre);
				continue;
			}
			parametre_sayisi_u8++;
		}
				
	}
	if (TOPLAM_PARAMETRE_SAYISI != parametre_sayisi_u8)
	{
		printf("Parametreler eksik ! \t  Gerekli : %d, Mevcut : %d\n", TOPLAM_PARAMETRE_SAYISI, parametre_sayisi_u8);
		return 1;
	}
	fclose(dosya);
	printf("CSV dosyasi okuma tamamlandi.\n");

	/*-------------------------------------------Bagli Cihazlari Kontrol Et--------------------------------------------*/
	struct bladerf_devinfo* cihaz_listesi_sta = NULL;
	struct bladerf* cihaz_st				  = NULL;
	int16_t	cihaz_sayisi_i16				  = 0;
	uint8_t uygun_cihaz_id_u8				  = 255;
	cihaz_sayisi_i16 = bladerf_get_device_list(&cihaz_listesi_sta);

	if (cihaz_sayisi_i16 < 0)
	{
		fprintf(stderr, "Cihaz listesi alinamadi: %s\n", bladerf_strerror(cihaz_sayisi_i16));
		return -1;
	}
	
	
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
		fprintf(stderr, "Uygun cihaz bulunamadi! Lutfen dogru versiyonu secin ! \n");
		bladerf_free_device_list(cihaz_listesi_sta);
		return -1;
	}
	
	/*--------------------------------------------Cihazi Ac-----------------------------------------------------------*/
	// todo : cihaz versiyon kontrol et ONA GORE AC
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
		mod_rxtx(cihaz_st, &rxtx_parametreleri_st, &tx_kanal_st, &rx_kanal_st);
		break;
	case(RX):
		printf("RX modu calistiriliyor...\n");
		break;
	case(TX):
		printf("TX modu calistiriliyor...\n");
		break;
	default:
		printf("Mod gecerli degil!\n");
		break;
	}

	return 0;
}


