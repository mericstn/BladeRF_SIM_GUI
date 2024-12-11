#pragma once
#include "main.h"
#include <stdio.h>

void gps_zamani_yazdir(const gps_zamani_t* gps_zamani) {
	if (gps_zamani) {
		printf("GPS Haftasi: %d, Saniye: %.2f\n", gps_zamani->hafta, gps_zamani->saniye);
	}
}

void takvim_zamani_yazdir(const takvim_zamani_t* takvim_zamani) {
	if (takvim_zamani) {
		printf("Tarih: %d-%02d-%02d %02d:%02d:%06.3f\n",
			takvim_zamani->yil,
			takvim_zamani->ay,
			takvim_zamani->gun,
			takvim_zamani->saat,
			takvim_zamani->dakika,
			takvim_zamani->saniye);
	}
}

void uydu_efemeris_yazdir(const efemeris_t* efemeris)
{
	printf("Gecerli Bayrak: %d\n", efemeris->gecerli_bayrak);
	printf("Takvim Zamani: %d-%02d-%02d %02d:%02d:%06.3f\n",
		efemeris->takvim_zamani.yil,
		efemeris->takvim_zamani.ay,
		efemeris->takvim_zamani.gun,
		efemeris->takvim_zamani.saat,
		efemeris->takvim_zamani.dakika,
		efemeris->takvim_zamani.saniye);
	printf("GPS Zamani: Hafta %d, Saniye %.3f\n",
		efemeris->gps_zamani.hafta,
		efemeris->gps_zamani.saniye);
	printf("Efemeris Zamani: Hafta %d, Saniye %.3f\n",
		efemeris->efemeris_zamani.hafta,
		efemeris->efemeris_zamani.saniye);
	printf("Veri Versiyonu Saat: %d\n", efemeris->veri_versiyonu_saat);
	printf("Veri Versiyonu Efemeris: %d\n", efemeris->veri_versiyonu_efemeris);
	printf("Delta N: %.9e\n", efemeris->delta_n);
	printf("Yorunge Konum Kosinus Duzeltmesi: %.9e\n", efemeris->yorunge_konum_kosinus_duzeltmesi);
	printf("Yorunge Konum Sinus Duzeltmesi: %.9e\n", efemeris->yorunge_konum_sinus_duzeltmesi);
	printf("Egilim Kosinus Duzeltmesi: %.9e\n", efemeris->egilim_kosinus_duzeltmesi);
	printf("Egilim Sinus Duzeltmesi: %.9e\n", efemeris->egilim_sinus_duzeltmesi);
	printf("Yorunge Yaricap Kosinus Duzeltmesi: %.9e\n", efemeris->yorunge_yaricap_kosinus_duzeltmesi);
	printf("Yorunge Yaricap Sinus Duzeltmesi: %.9e\n", efemeris->yorunge_yaricap_sinus_duzeltmesi);
	printf("Eksantriklik: %.9e\n", efemeris->eksantriklik);
	printf("Buyuk Eksen A Karekok: %.9e\n", efemeris->buyuk_eksen_A_karekok);
	printf("Ortalama Anomalilik: %.9e\n", efemeris->ortalama_anomalilik);
	printf("Yukselen Dugum Boylami: %.9e\n", efemeris->yukselen_dugum_boylami);
	printf("Egilim: %.9e\n", efemeris->egilim);
	printf("Perige Acisi: %.9e\n", efemeris->perige_acisi);
	printf("Yukselen Dugum Degisim Orani: %.9e\n", efemeris->yukselen_dugum_degisim_orani);
	printf("Egiliklik Acisi Degisim Orani: %.9e\n", efemeris->egiklik_acisi_degisim_orani);
	printf("Saat Ofseti: %.9e\n", efemeris->saat_ofseti);
	printf("Saat Kaymasi: %.9e\n", efemeris->saat_kaymasi);
	printf("Saat Hizlanmasi: %.9e\n", efemeris->saat_hizlanmasi);
	printf("Grup Gecikmesi: %.9e\n", efemeris->grup_gecikmesi);
	printf("Uydu Saglik Durumu: %d\n", efemeris->uydu_saglik);
	printf("L2 Sinyal Kodu: %d\n", efemeris->L2_sinyal_kodu);
	printf("Ortalama Acisal Hiz: %.9e\n", efemeris->ortalama_acisal_hiz);
	printf("Eksantriklik Karekok: %.9e\n", efemeris->eksantriklik_karekok);
	printf("Buyuk Yaricap: %.9e\n", efemeris->buyuk_yaricap);
	printf("Omega Dot: %.9e\n", efemeris->omega_dot);
}

void dosya_veri_yazdir(iyono_utc_t iyono_utc, const efemeris_t* efemeris_verileri, int efemeris_sayisi)
{
	printf("ION ALPHA: %e, %e, %e, %e\n", iyono_utc.iyon_alfa[0], iyono_utc.iyon_alfa[1], iyono_utc.iyon_alfa[2], iyono_utc.iyon_alfa[3]);
	printf("ION BETA: %e, %e, %e, %e\n", iyono_utc.iyon_beta[0], iyono_utc.iyon_beta[1], iyono_utc.iyon_beta[2], iyono_utc.iyon_beta[3]);
	printf("Delta UTC A0: %e\n", iyono_utc.delta_utc_a[0]);
	printf("Delta UTC A1: %e\n", iyono_utc.delta_utc_a[1]);

	printf("------------------------------------------------------\n");
	for (int i = 0; i < efemeris_sayisi; i++) {
		printf("efemeris num %d\n", i+1 );
		printf("------------------------------------------------------\n");
		uydu_efemeris_yazdir(&efemeris_verileri[i]);
		printf("------------------------------------------------------\n");
	}
	printf("toplam efemeris sayisi %d\n", efemeris_sayisi);
}


// range_t yapý deðiþkenlerini yazdýran fonksiyon
void yazdir_range(range_t* range)
{
	printf("Range Deðiþkenleri:\n");
	printf("Range: %f\n", range->range);
	printf("Rate: %f\n", range->rate);
	printf("Geometrik Mesafe (d): %f\n", range->d);
	printf("Azimut: %f, Elevasyon: %f\n", range->azel[0], range->azel[1]);
	printf("Ionosfer Gecikmesi: %f\n", range->iono_delay);
}

// kanal_t yapý deðiþkenlerini yazdýran fonksiyon
void yazdir_kanal(kanal_t* kanal)
{
	printf("Kanal Deðiþkenleri:\n");
	printf("PRN: %d\n", kanal->prn);
	printf("Taþýyýcý Frekansý: %f\n", kanal->tasiyici_frekansi);
	printf("Kod Frekansý: %f\n", kanal->kod_frekansi);

#ifdef FLOAT_CARR_PHASE
	printf("Taþýyýcý Faz: %f\n", kanal->tasiyici_faz);
#else
	printf("Taþýyýcý Faz: %u\n", kanal->tasiyici_faz);
	printf("Taþýyýcý Faz Adýmý: %d\n", kanal->tasiyici_faz_adimi);
#endif

	printf("Kod Fazý: %f\n", kanal->kod_fazi);

	// Subframe verilerini yazdýr
	printf("Subframe Verileri:\n");
	for (int i = 0; i < 5; i++) {
		for (int j = 0; j < N_DWRD_SBF; j++) {
			printf("%lu ", kanal->subframe[i][j]);
		}
		printf("\n");
	}

	printf("Ýlk Kelime: %d\n", kanal->ilk_word);
	printf("Ýlk Bit: %d\n", kanal->ilk_bit);
	printf("Ýlk Kod: %d\n", kanal->ilk_kod);
	printf("Veri Bit: %d\n", kanal->veri_biti);
	printf("C/A Kodu: %d\n", kanal->ca_kodu);
	printf("Azimut: %f, Elevasyon: %f\n", kanal->azel[0], kanal->azel[1]);

	// Range bilgilerini yazdýr
	yazdir_range(&kanal->rho0);
}