
#include "get_parameter.h"


void kullanim_talimati(const char* program_adi)
{
	printf("Kullanim: %s <csv_dosya_adi>\n", program_adi);
}

int satir_ayristir(const char* satir, char* parametre, char* deger)
{

	char satir_kopya[256];

	strncpy(satir_kopya, satir, sizeof(satir_kopya));

	satir_kopya[sizeof(satir_kopya) - 1] = '\0';

	char* temp_parametre = strtok(satir_kopya, ",");
	char* temp_deger	 = strtok(NULL, ",");

	if (temp_parametre != NULL && temp_deger != NULL)
	{
		strncpy(parametre, temp_parametre, 128);
		strncpy(deger, temp_deger, 128);

		parametre[127]	= '\0';
		deger[127]		= '\0';

		return 1;
	}
	return 0;
}



void parametre_oku_csv(FILE* dosya,rxtx_parametreleri_t * rxtx_parametreleri_st, tx_parametreleri_t* tx_parametreleri_st,kanal_t* tx_kanal_st,kanal_t *rx_kanal_st ,program_t*program_st,uint16_t *parametre_sayisi_u16)
{

	char satir[256] = { 0 };
	char parametre[128] = { 0 };
	char deger[128] = { 0 };
	// not : hash table ile temize cekilebilir
	while (fgets(satir, sizeof(satir), dosya) != NULL) 
{

		satir[strcspn(satir, "\n")] = '\0';

		if (satir_ayristir(satir, parametre, deger))
		{
			/* TX Parametreleri*/
			if (strcmp(parametre, "kanal_tx_kanal_adi") == 0)
			{
				strncpy(tx_kanal_st->channel_name, deger, sizeof(tx_kanal_st->channel_name) - 1);
				tx_kanal_st->channel_name[sizeof(tx_kanal_st->channel_name) - 1] = '\0';
			}
			else if (strcmp(parametre, "kanal_tx_kanal") == 0)
			{
				tx_kanal_st->channel_i32 = (strcmp(deger,"TX2") == 0) ? TX2 : TX1;
			}
			else if (strcmp(parametre, "kanal_tx_frekans") == 0)
			{
				tx_kanal_st->frequency_u64 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_ornekleme_orani") == 0)
			{
				tx_kanal_st->sample_rate_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_bant_genisligi") == 0)
			{
				tx_kanal_st->bandwidth_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_kazanc") == 0)
			{
				tx_kanal_st->gain_i32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_zaman_asimi") == 0)
			{
				tx_kanal_st->timeout_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_tx_bias_tee") == 0)
			{
				tx_kanal_st->bias_tee_et = (strcmp(deger,"Aktif") == 0) ? BIAS_TEE_AKTIF : BIAS_TEE_KAPALI;
			}
			/* RX Parametreleri*/
			else if (strcmp(parametre, "kanal_rx_kanal_adi") == 0)
			{
				strncpy(rx_kanal_st->channel_name, deger, sizeof(rx_kanal_st->channel_name) - 1);
				rx_kanal_st->channel_name[sizeof(rx_kanal_st->channel_name) - 1] = '\0'; // Null sonlandýrma
			}
			else if (strcmp(parametre, "kanal_rx_kanal") == 0)
			{
				rx_kanal_st->channel_i32 = (strcmp(deger, "RX2") == 0) ? RX2 : RX1;
			}
			else if (strcmp(parametre, "kanal_rx_frekans") == 0)
			{
				rx_kanal_st->frequency_u64 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_ornekleme_orani") == 0)
			{
				rx_kanal_st->sample_rate_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_bant_genisligi") == 0)
			{
				rx_kanal_st->bandwidth_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_kazanc") == 0)
			{
				rx_kanal_st->gain_i32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_zaman_asimi") == 0)
			{
				rx_kanal_st->timeout_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "kanal_rx_bias_tee") == 0)
			{
				rx_kanal_st->bias_tee_et = (strcmp(deger, "Aktif") == 0) ? BIAS_TEE_AKTIF : BIAS_TEE_KAPALI;
			}
			/*Program Parametreleri*/
			else if (strcmp(parametre, "prog_cihaz_versiyon") == 0)
			{
				program_st->cihaz_versiyon_et = (strcmp(deger, "BladeRF v2.0") == 0) ? BLADERF_V2 : BLADERF_V1;
			}

			else if (strcmp(parametre, "prog_mod") == 0)
			{
				if (strcmp(deger, "RXTX") == 0)
				{
					program_st->mod_et = RXTX;
				}
				else if (strcmp(deger, "TX") == 0)
				{
					program_st->mod_et = TX;
				}
				else if (strcmp(deger, "RX") == 0)
				{
					program_st->mod_et = RX;
				}
			}
			else if (strcmp(parametre, "prog_sure") == 0)
			{
				program_st->program_sure_saniye_u32 = atoi(deger);
			}
			/* RXTX Mod Parametreleri*/
			else if (strcmp(parametre, "rxtx_ornek_uzunlugu") == 0)
			{
				rxtx_parametreleri_st->ornek_uzunlugu_u16 = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_tampon_boyutu") == 0)
			{
				rxtx_parametreleri_st->tampon_boyutu_u32 = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_tampon_sayisi") == 0)
			{
				rxtx_parametreleri_st->tampon_sayisi_u8 = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_veri_transfer_sayisi") == 0)
			{
				rxtx_parametreleri_st->veri_transfer_sayisi_u8 = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_zaman_asimi") == 0)
			{
				rxtx_parametreleri_st->zaman_asimi_16t = atoi(deger);
			}
			else if (strcmp(parametre, "rxtx_ornek_alma_gonderme_sayisi") == 0)
			{
				rxtx_parametreleri_st->ornek_alma_gonderme_sayisi_u32 = atoi(deger);
			}
			/* TX Mod Parametreleri*/ // todo : parametreler eklenecek
			else if (strcmp(parametre, "tx_dosya_adi") == 0)
			{
				printf("tx ! \n");
			}
			else
			{
				printf("Bilinmeyen parametre: %s\n", parametre);
				continue;
			}
			(*parametre_sayisi_u16)++;
		}

	}	
	if (dosya != NULL) {
		fclose(dosya);
	}
	printf("CSV dosyasi okuma tamamlandi.\n");	
}