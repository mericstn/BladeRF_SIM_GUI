#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <math.h>
#include <time.h>


#include "uc_birim.h"
#include "main.h"
#include "terminal.h"



// rinex icerisinde D sci notaion ifadesini E yapar
void ustel_isareti_degistir(char* str, size_t len)
{
	for (size_t i = 0; i < len; ++i) {
		if (str[i] == 'D' || str[i] == 'd') {
			str[i] = 'E';
		}
	}
}


/*! \brief UTC tarihini GPS tarihine dönüştürür
 *  \param[in] t Girdi tarihi UTC formatında
 *  \param[out] g Çıktı tarihi GPS formatında
 */
void takvim2gps(const takvim_zamani_t* t, gps_zamani_t* g)
{
	int doy[12] = { 0,31,59,90,120,151,181,212,243,273,304,334 };
	int ye;
	int de;
	int lpdays;

	ye = t->yil - 1980;

	// Compute the number of leap days since Jan 5/Jan 6, 1980.
	lpdays = ye / 4 + 1;
	if ((ye % 4) == 0 && t->ay <= 2)
		lpdays--;

	// Compute the number of days elapsed since Jan 5/Jan 6, 1980.
	de = ye * 365 + doy[t->ay - 1] + t->gun + lpdays - 6;

	// Convert time to GPS haftas and seconds.
	g->hafta = de / 7;
	g->saniye = (double)(de % 7) * GUNDE_SANIYE + t->saat * SAATTE_SANIYE
+ t->dakika * DAKIKADA_SANIYE + t->saniye;

	return;
}

/*! \brief Iki GPS zaman degeri arasindaki farki hesaplar
 *  \param g1 Ilk GPS zamani
 *  \param g0 Ikinci GPS zamani
 *  \returns Iki zaman degeri arasindaki fark (saniye cinsinden)
 */
double gps_zaman_farki_hesapla(gps_zamani_t g1, gps_zamani_t g0)
{
	double dt;
	//printf("g0: %lf, g1: %lf \n", g0.saniye, g1.saniye);
	dt = g1.saniye - g0.saniye;
	dt += (double)(g1.hafta - g0.hafta) * HAFTADA_SANIYE;

	return(dt);
}

int rinex_dosya_okuma(const char* fname, iyono_utc_t* ionoutc, efemeris_t efemerisler[][MAKSIMUM_UYDU])
{
	FILE* fp;
	int efemeris_indeksi;

	int uydu;
	char str[MAKSIMUM_KARAKTER];
	char tmp[20];

	takvim_zamani_t t;
	gps_zamani_t g;
	gps_zamani_t g0;
	double dt;

	int flags = 0x0;

	if (NULL == (fp = fopen(fname, "rt")))
		return(-1);
		
	
	// Clear valid flag
	for (efemeris_indeksi = 0; efemeris_indeksi < EPHEMERIS_DIZI_UZUNLUGU; efemeris_indeksi++)
		for (uydu = 0; uydu < MAKSIMUM_UYDU; uydu++)
			efemerisler[efemeris_indeksi][uydu].gecerli_bayrak = 0;

	// Read header lines
	while (1)
	{
		if (NULL == fgets(str, MAKSIMUM_KARAKTER, fp))
			break;

		if (strncmp(str + 60, "END OF HEADER", 13) == 0)
			break;
		else if (strncmp(str + 60, "ION ALPHA", 9) == 0)
		{
			strncpy(tmp, str + 2, 12);
			tmp[12] = 0;
			ustel_isareti_degistir(tmp, 12);
			ionoutc->iyon_alfa[0] = atof(tmp);

			strncpy(tmp, str + 14, 12);
			tmp[12] = 0;
			ustel_isareti_degistir(tmp, 12);
			ionoutc->iyon_alfa[1] = atof(tmp);

			strncpy(tmp, str + 26, 12);
			tmp[12] = 0;
			ustel_isareti_degistir(tmp, 12);
			ionoutc->iyon_alfa[2] = atof(tmp);

			strncpy(tmp, str + 38, 12);
			tmp[12] = 0;
			ustel_isareti_degistir(tmp, 12);
			ionoutc->iyon_alfa[3] = atof(tmp);

			flags |= 0x1;
		}
		else if (strncmp(str + 60, "ION BETA", 8) == 0)
		{
			strncpy(tmp, str + 2, 12);
			tmp[12] = 0;
			ustel_isareti_degistir(tmp, 12);
			ionoutc->iyon_beta[0] = atof(tmp);

			strncpy(tmp, str + 14, 12);
			tmp[12] = 0;
			ustel_isareti_degistir(tmp, 12);
			ionoutc->iyon_beta[1] = atof(tmp);

			strncpy(tmp, str + 26, 12);
			tmp[12] = 0;
			ustel_isareti_degistir(tmp, 12);
			ionoutc->iyon_beta[2] = atof(tmp);

			strncpy(tmp, str + 38, 12);
			tmp[12] = 0;
			ustel_isareti_degistir(tmp, 12);
			ionoutc->iyon_beta[3] = atof(tmp);

			flags |= 0x1 << 1;
		}
		else if (strncmp(str + 60, "DELTA-UTC", 9) == 0)
		{
			strncpy(tmp, str + 3, 19);
			tmp[19] = 0;
			ustel_isareti_degistir(tmp, 19);
			ionoutc->delta_utc_a[0] = atof(tmp);

			strncpy(tmp, str + 22, 19);
			tmp[19] = 0;
			ustel_isareti_degistir(tmp, 19);
			ionoutc->delta_utc_a[1] = atof(tmp);

			strncpy(tmp, str + 41, 9);
			tmp[9] = 0;
			ionoutc->iletim_zamani = atoi(tmp);

			strncpy(tmp, str + 50, 9);
			tmp[9] = 0;
			ionoutc->iletim_haftasi = atoi(tmp);

			if (ionoutc->iletim_zamani % 4096 == 0)
				flags |= 0x1 << 2;
		}
		else if (strncmp(str + 60, "LEAP SECONDS", 12) == 0)
		{
			strncpy(tmp, str, 6);
			tmp[6] = 0;
			ionoutc->delta_ls = atoi(tmp);

			flags |= 0x1 << 3;
		}
	}

	ionoutc->gecerli_bayrak = FALSE;
	if (flags == 0xF) // Read all Iono/UTC lines
		ionoutc->gecerli_bayrak = TRUE;

	// Read ephemeris blocks
	g0.hafta = -1;
	efemeris_indeksi = 0;
	int counter = 0;
	while (1)
	{

		if (NULL == fgets(str, MAKSIMUM_KARAKTER, fp))
			break;

		// PRN
		strncpy(tmp, str, 2);
		tmp[2] = 0;
		uydu = atoi(tmp) - 1;


		// EPOCH
		strncpy(tmp, str + 3, 2);
		tmp[2] = 0;
		t.yil = atoi(tmp) + 2000;

		strncpy(tmp, str + 6, 2);
		tmp[2] = 0;
		t.ay = atoi(tmp);

		strncpy(tmp, str + 9, 2);
		tmp[2] = 0;
		t.gun = atoi(tmp);

		strncpy(tmp, str + 12, 2);
		tmp[2] = 0;
		t.saat = atoi(tmp);

		strncpy(tmp, str + 15, 2);
		tmp[2] = 0;
		t.dakika = atoi(tmp);

		strncpy(tmp, str + 18, 4);
		tmp[2] = 0;
		t.saniye = atof(tmp);
		//printf("%d    saniye : %s \n", counter++, tmp);

		takvim2gps(&t, &g);

		if (g0.hafta == -1)
			g0 = g;

		// Check current time of clock
		dt = gps_zaman_farki_hesapla(g, g0);

		//printf("%d    saniye : %lf \n", counter++, dt);
		if (dt > SAATTE_SANIYE)
		{
			g0 = g;
			efemeris_indeksi++; // a new set of ephemerides
			//printf("efemeris_indeksi : :: %d\n",efemeris_indeksi);
			if (efemeris_indeksi >= EPHEMERIS_DIZI_UZUNLUGU)
				break;
		}

		// Date and time
		efemerisler[efemeris_indeksi][uydu].takvim_zamani = t;

		// SV CLK
		efemerisler[efemeris_indeksi][uydu].gps_zamani = g;

		strncpy(tmp, str + 22, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19); // tmp[15]='E';
		efemerisler[efemeris_indeksi][uydu].saat_ofseti = atof(tmp);

		strncpy(tmp, str + 41, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].saat_kaymasi = atof(tmp);

		strncpy(tmp, str + 60, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].saat_hizlanmasi = atof(tmp);

		// BROADCAST ORBIT - 1
		if (NULL == fgets(str, MAKSIMUM_KARAKTER, fp))
			break;

		strncpy(tmp, str + 3, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].veri_versiyonu_efemeris = (int)atof(tmp);

		strncpy(tmp, str + 22, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].yorunge_yaricap_sinus_duzeltmesi = atof(tmp);

		strncpy(tmp, str + 41, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].delta_n = atof(tmp);

		strncpy(tmp, str + 60, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].ortalama_anomalilik = atof(tmp);

		// BROADCAST ORBIT - 2
		if (NULL == fgets(str, MAKSIMUM_KARAKTER, fp))
			break;

		strncpy(tmp, str + 3, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].yorunge_konum_kosinus_duzeltmesi = atof(tmp);

		strncpy(tmp, str + 22, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].eksantriklik = atof(tmp);

		strncpy(tmp, str + 41, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].yorunge_konum_sinus_duzeltmesi = atof(tmp);

		strncpy(tmp, str + 60, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].buyuk_eksen_A_karekok = atof(tmp);

		// BROADCAST ORBIT - 3
		if (NULL == fgets(str, MAKSIMUM_KARAKTER, fp))
			break;

		strncpy(tmp, str + 3, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].efemeris_zamani.saniye = atof(tmp);

		strncpy(tmp, str + 22, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].egilim_kosinus_duzeltmesi = atof(tmp);

		strncpy(tmp, str + 41, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].yukselen_dugum_boylami = atof(tmp);

		strncpy(tmp, str + 60, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].egilim_sinus_duzeltmesi = atof(tmp);

		// BROADCAST ORBIT - 4
		if (NULL == fgets(str, MAKSIMUM_KARAKTER, fp))
			break;

		strncpy(tmp, str + 3, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].egilim = atof(tmp);

		strncpy(tmp, str + 22, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].yorunge_yaricap_kosinus_duzeltmesi = atof(tmp);

		strncpy(tmp, str + 41, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].perige_acisi = atof(tmp);

		strncpy(tmp, str + 60, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].yukselen_dugum_degisim_orani = atof(tmp);

		// BROADCAST ORBIT - 5
		if (NULL == fgets(str, MAKSIMUM_KARAKTER, fp))
			break;

		strncpy(tmp, str + 3, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].egiklik_acisi_degisim_orani = atof(tmp);

		strncpy(tmp, str + 22, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].L2_sinyal_kodu = (int)atof(tmp);

		strncpy(tmp, str + 41, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].efemeris_zamani.hafta = (int)atof(tmp);

		// BROADCAST ORBIT - 6
		if (NULL == fgets(str, MAKSIMUM_KARAKTER, fp))
			break;

		strncpy(tmp, str + 22, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].uydu_saglik = (int)atof(tmp);
		if ((efemerisler[efemeris_indeksi][uydu].uydu_saglik > 0) && (efemerisler[efemeris_indeksi][uydu].uydu_saglik < 32))
			efemerisler[efemeris_indeksi][uydu].uydu_saglik += 32; // Set MSB to 1

		strncpy(tmp, str + 41, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].grup_gecikmesi = atof(tmp);

		strncpy(tmp, str + 60, 19);
		tmp[19] = 0;
		ustel_isareti_degistir(tmp, 19);
		efemerisler[efemeris_indeksi][uydu].veri_versiyonu_saat = (int)atof(tmp);

		// BROADCAST ORBIT - 7
		if (NULL == fgets(str, MAKSIMUM_KARAKTER, fp))
			break;
	


		efemerisler[efemeris_indeksi][uydu].gecerli_bayrak = 1;
		efemerisler[efemeris_indeksi][uydu].buyuk_yaricap = efemerisler[efemeris_indeksi][uydu].buyuk_eksen_A_karekok * efemerisler[efemeris_indeksi][uydu].buyuk_eksen_A_karekok;
		efemerisler[efemeris_indeksi][uydu].ortalama_acisal_hiz = sqrt(DUNYA_YER_CEKIMI_SABITI / (efemerisler[efemeris_indeksi][uydu].buyuk_yaricap * efemerisler[efemeris_indeksi][uydu].buyuk_yaricap * efemerisler[efemeris_indeksi][uydu].buyuk_yaricap)) + efemerisler[efemeris_indeksi][uydu].delta_n;
		efemerisler[efemeris_indeksi][uydu].eksantriklik_karekok = sqrt(1.0 - efemerisler[efemeris_indeksi][uydu].eksantriklik * efemerisler[efemeris_indeksi][uydu].eksantriklik);
		efemerisler[efemeris_indeksi][uydu].omega_dot = efemerisler[efemeris_indeksi][uydu].yukselen_dugum_degisim_orani - DUNYA_ACISAL_HIZ;

	}

	fclose(fp);

	if (g0.hafta >= 0)
		efemeris_indeksi += 1; // Number of sets of ephemerides
	
	return(efemeris_indeksi);
}

/*! \brief Enlem/Boylam/Yukseklik değerlerini ECEF'ye donusturur
 *  \param[in] llh Girdi Enlem, Boylam ve Yukseklik dizisi
 *  \param[out] xyz Cikis X, Y ve Z ECEF koordinatları dizisi
 */
void llh2xyz(const double* llh, double* xyz)
{
	double n;
	double a;
	double e;
	double e2;
	double clat;
	double slat;
	double clon;
	double slon;
	double d, nph;
	double tmp;

	a = WGS84_YARICAP;
	e = WGS84_EKSANTRIKLIK;
	e2 = e * e;

	clat = cos(llh[0]);
	slat = sin(llh[0]);
	clon = cos(llh[1]);
	slon = sin(llh[1]);
	d = e * slat;

	n = a / sqrt(1.0 - d * d);
	nph = n + llh[2];

	tmp = nph * clat;
	xyz[0] = tmp * clon;
	xyz[1] = tmp * slon;
	xyz[2] = ((1.0 - e2) * n + llh[2]) * slat;

	return;
}
/*! \brief Verilen GPS zamanina bir zaman araligi ekler
 *  \param g0 Baslangic GPS zamani
 *  \param dt Eklenmesi gereken zaman araligi (saniye cinsinden)
 *  \returns Yeni hesaplanan GPS zamani
 */
gps_zamani_t gps_zaman_arttir(gps_zamani_t g0, double dt)
{
	gps_zamani_t g1;

	g1.hafta = g0.hafta;
	g1.saniye = g0.saniye + dt;

	g1.saniye = round(g1.saniye * 1000.0) / 1000.0; // Avoid rounding error

	while (g1.saniye >= HAFTADA_SANIYE)
	{
		g1.saniye -= HAFTADA_SANIYE;
		g1.hafta++;
	}

	while (g1.saniye < 0.0)
	{
		g1.saniye += HAFTADA_SANIYE;
		g1.hafta--;
	}

	return(g1);
}
/*! \brief NMEA GGA formatındaki verileri okur ve kullanıcı konumunu ECEF formatına dönüştürür.
 *
 *  Bu fonksiyon, NMEA GGA formatındaki konum verilerini içeren bir dosyayı okuyarak, kullanıcı hareketi için
 *  Dünya Merkezli, Dünya Sabit (ECEF) koordinatlarına dönüştürür. Elde edilen koordinatlar `xyz` dizisine
 *  kaydedilir ve okunan toplam veri sayısı geri döndürülür.
 *
 *  \param[out] xyz Elde edilen ECEF koordinatlarını tutan çıktı dizisi.
 *  \param[in] nmea_dosya_yolu Okunacak NMEA GGA dosyasının dosya yolu.
 *  \returns Okunan geçerli veri kayıtlarının sayısı. Hata durumunda -1 döner.
 */
int NmeaGGA_oku(double xyz[KULLANICI_HAREKET_BOYUTU][3], const char* nmea_dosya_yolu)
{
	FILE* fp;
	int numd = 0;
	char str[MAKSIMUM_KARAKTER];
	char* token;
	double llh[3], pos[3];
	char tmp[8];

	// Dosya açılır, açılamazsa hata kodu döndürülür
	if ((fp = fopen(nmea_dosya_yolu, "rt")) == NULL)
	{
		fprintf(stderr, "Dosya açılamadı: %s\n", nmea_dosya_yolu);
		return -1;
	}

	// Dosya sonuna kadar satır satır okuma yapılır
	while (fgets(str, MAKSIMUM_KARAKTER, fp) != NULL)
	{
		// Satırdan ilk token alınarak GGA kontrolü yapılır
		token = strtok(str, ",");
		if (strncmp(token + 3, "GGA", 3) == 0)
		{
			// Enlem verisi alınır, derece ve dakika olarak ayrılır
			token = strtok(NULL, ","); // Saat
			token = strtok(NULL, ","); // Enlem
			strncpy(tmp, token, 2); // İlk iki karakteri derece için al
			tmp[2] = '\0';
			llh[0] = atof(tmp) + atof(token + 2) / 60.0; // Dereceye çevirme

			// Enlemin kuzey ya da güneyde olduğu bilgisi alınır
			token = strtok(NULL, ",");
			if (token[0] == 'S') llh[0] *= -1.0;
			llh[0] /= R2D; // Enlemi radyana çevirir

			// Boylam verisi alınır, derece ve dakika olarak ayrılır
			token = strtok(NULL, ","); // Boylam
			strncpy(tmp, token, 3); // İlk üç karakter dereceyi içerir
			tmp[3] = '\0';
			llh[1] = atof(tmp) + atof(token + 3) / 60.0; // Dereceye çevirme

			// Boylamın doğu ya da batıda olduğu bilgisi alınır
			token = strtok(NULL, ",");
			if (token[0] == 'W') llh[1] *= -1.0;
			llh[1] /= R2D; // Boylamı radyana çevirir

			// Yükseklik bilgisi alınır
			token = strtok(NULL, ","); // GPS fix durumu
			token = strtok(NULL, ","); // Uydu sayısı
			token = strtok(NULL, ","); // HDOP
			token = strtok(NULL, ","); // Deniz seviyesinden yükseklik
			llh[2] = atof(token);
			token = strtok(NULL, ","); // Birim (ör. metre)

			// Geoid yüksekliği alınarak WGS84 elipsoidi üzerindeki yükseklik elde edilir
			token = strtok(NULL, ",");
			llh[2] += atof(token);

			// Coğrafi (LLH) konum ECEF koordinatlarına dönüştürülür
			llh2xyz(llh, pos);
			xyz[numd][0] = pos[0];
			xyz[numd][1] = pos[1];
			xyz[numd][2] = pos[2];

			// Toplam kayıt sayısı güncellenir
			numd++;

			// Kullanıcı hareket boyutuna ulaşıldıysa döngü sonlandırılır
			if (numd >= KULLANICI_HAREKET_BOYUTU) break;
		}
	}

	// Dosya kapatılır
	fclose(fp);

	// Okunan veri kayıtlarının sayısı döndürülür
	return numd;
}

/*! \brief GPS tarihini takvim tarihine dönüştürür
 *  \param[in] g Girdi GPS tarihi
 *  \param[out] t Çıktı takvim tarihi
 */
void gps2zaman(const gps_zamani_t* g, takvim_zamani_t* t)
{
	// Convert Julian day number to calendar date
	int c = (int)(7 * g->hafta + floor(g->saniye / 86400.0) + 2444245.0) + 1537;
	int d = (int)((c - 122.1) / 365.25);
	int e = 365 * d + d / 4;
	int f = (int)((c - e) / 30.6001);

	t->gun = c - e - (int)(30.6001 * f);
	t->ay = f - 1 - 12 * (f / 14);
	t->yil = d - 4715 - ((7 + t->ay) / 10);
	t->saat = ((int)(g->saniye / 3600.0)) % 24;
	t->dakika = ((int)(g->saniye / 60.0)) % 60;
	t->saniye = g->saniye - 60.0 * floor(g->saniye / 60.0);

	return;
}
/*! \brief ECEF'den Kuzey-Doğu-Yukseklik formatına dönüştürür
 *  \param[in] xyz ECEF formatında vektör olarak girdi konumu
 *  \param[in] t \ref ltc_matrisi fonksiyonu ile hesaplanan ara matris
 *  \param[out] neu Kuzey-Doğu-Yukseklik formatında çıktı konumu
 */
void ecef2neh(const double* xyz, double t[3][3], double* neu)
{
	neu[0] = t[0][0] * xyz[0] + t[0][1] * xyz[1] + t[0][2] * xyz[2];
	neu[1] = t[1][0] * xyz[0] + t[1][1] * xyz[1] + t[1][2] * xyz[2];
	neu[2] = t[2][0] * xyz[0] + t[2][1] * xyz[1] + t[2][2] * xyz[2];

	return;
}
/*! \brief Vektorun normunu hesaplar
 *  \param[in] x Girdi vektoru
 *  \returns Girdi vektorunun uzunlugu (norm)
 */
double vektor_norm_al(const double* x)
{
	return(sqrt(x[0] * x[0] + x[1] * x[1] + x[2] * x[2]));
}
/*! \brief ECEF koordinatlarını Enlem/Boylam/Yükseklik formatına dönüştürür
 *  \param[in] xyz Girdi X, Y ve Z ECEF koordinatları dizisi
 *  \param[out] llh Çıktı Enlem, Boylam ve Yükseklik dizisi
 */
void xyz2llh(const double* xyz, double* llh)
{
	double a, eps, e, e2;
	double x, y, z;
	double rho2, dz, zdz, nh, slat, n, dz_new;

	// WGS84 yarıçapı (a) ve eksantriklik (e) sabitleri
	a = WGS84_YARICAP;
	e = WGS84_EKSANTRIKLIK;

	// Hata toleransı (eps), bu değer altındaki farklar ihmal edilir
	eps = 1.0e-3;

	// Eksantrikliğin karesi (e^2)
	e2 = e * e;

	// ECEF koordinat vektörünün normu kontrol edilir; norm < eps ise geçersiz sayılır
	if (vektor_norm_al(xyz) < eps)
	{
		// Geçersiz ECEF vektörü durumunda llh dizisi başlangıç değerleri atanır
		llh[0] = 0.0;     // Enlem
		llh[1] = 0.0;     // Boylam
		llh[2] = -a;      // Yükseklik (-a: geçersiz yükseklik)

		return;
	}

	// ECEF koordinatlarının ayrı ayrı atanması
	x = xyz[0];
	y = xyz[1];
	z = xyz[2];

	// rho2: X ve Y eksenlerindeki uzaklığın karesi, rho^2 = x^2 + y^2
	rho2 = x * x + y * y;

	// Z ekseni üzerinde e^2 * z ilk değeri atanır
	dz = e2 * z;

	// Newton-Raphson yöntemiyle yükseklik (h) ve enlem (phi) hesaplaması
	while (1)
	{
		// zdz: z eksenindeki toplam mesafe, z + dz
		zdz = z + dz;

		// nh: yer merkezinden zdz noktasına uzaklık, nh = sqrt(rho^2 + (zdz)^2)
		nh = sqrt(rho2 + zdz * zdz);

		// slat: sin(enlem) değeri, slat = zdz / nh
		slat = zdz / nh;

		// n: ana yarıçap değeri, n = a / sqrt(1 - e^2 * sin(phi)^2)
		n = a / sqrt(1.0 - e2 * slat * slat);

		// dz_new: yeni dz değeri, dz_new = n * e^2 * sin(phi)
		dz_new = n * e2 * slat;

		// Döngü devam koşulu: dz - dz_new farkı eps değerinden küçük olana kadar devam eder
		if (fabs(dz - dz_new) < eps)
			break;

		// dz güncellenir
		dz = dz_new;
	}

	// Enlem (lat) değeri atanır, lat = atan2(zdz, sqrt(rho^2))
	llh[0] = atan2(zdz, sqrt(rho2));

	// Boylam (lon) değeri atanır, lon = atan2(y, x)
	llh[1] = atan2(y, x);

	// Yükseklik (alt) değeri atanır, alt = nh - n
	llh[2] = nh - n;

	return;
}

/*! \brief Iki double vektorunu cikarir
 *  \param[out] y Cikarma isleminin sonucu
 *  \param[in] x1 Cikarma isleminin minusu
 *  \param[in] x2 Cikarma isleminin cikartani
 */
void vektor_cikar(double* y, const double* x1, const double* x2)
{
	y[0] = x1[0] - x2[0];
	y[1] = x1[1] - x2[1];
	y[2] = x1[2] - x2[2];

	return;
}
/*! \brief LLH'den ECEF'ye giden ara matrisini hesaplar
 *  \param[in] llh Enlem-Uzunluk-Yükseklik formatındaki konum
 *  \param[out] t 3x3 boyutunda çıktı matrisi
 *
 *  Fonksiyon, LLH (Enlem, Boylam, Yükseklik) formatında verilen bir konumun ECEF koordinat sistemine
 *  dönüşümünde kullanılacak ara matrisini hesaplar. Dönüşüm matrisi, dünya yüzeyindeki bir noktadan
 *  ECEF koordinatlarına geçiş yapmak için gereken eksenleri hizalamayı sağlar.
 */
void ltc_matrisi(const double* llh, double t[3][3])
{
	double slat, clat;
	double slon, clon;

	// Enlem (latitude) ve boylam (longitude) açıları için sinüs ve kosinüs hesaplanır
	slat = sin(llh[0]);   // Enlem sinüsü
	clat = cos(llh[0]);   // Enlem kosinüsü
	slon = sin(llh[1]);   // Boylam sinüsü
	clon = cos(llh[1]);   // Boylam kosinüsü

	// Dönüşüm matrisi elemanlarının atanması
	// İlk satır: t[0][0], t[0][1], t[0][2]
	t[0][0] = -slat * clon;  // -sin(lat) * cos(lon)
	t[0][1] = -slat * slon;  // -sin(lat) * sin(lon)
	t[0][2] = clat;          // cos(lat)

	// İkinci satır: t[1][0], t[1][1], t[1][2]
	t[1][0] = -slon;         // -sin(lon)
	t[1][1] = clon;          // cos(lon)
	t[1][2] = 0.0;

	// Üçüncü satır: t[2][0], t[2][1], t[2][2]
	t[2][0] = clat * clon;   // cos(lat) * cos(lon)
	t[2][1] = clat * slon;   // cos(lat) * sin(lon)
	t[2][2] = slat;          // sin(lat)

	return;
}
/*! \brief Belirli bir zamanda Uydu konumunu, hızını ve saatini hesaplar
 *  \param[in] eph Uyduya ait ephemeris verisi
 *  \param[in] g Konumun hesaplanacağı GPS zamanı
 *  \param[out] pos Hesaplanan konum (vektör)
 *  \param[out] vel Hesaplanan hız (vektör)
 *  \param[out] clk Hesaplanan saat
 *
 *  Bu fonksiyon, verilen ephemeris verilerine dayanarak bir uydunun konum, hız ve saat
 *  değerlerini hesaplar. Hesaplama, yörünge parametreleri kullanılarak yapılır ve GPS saat
 *  düzeltmeleri de içerir.
 */
void uydu_hiz_konum_saat_hesapla(efemeris_t eph, gps_zamani_t g, double* pos, double* vel, double* clk)
{
	// Computing Satellite Velocity using the Broadcast Ephemeris
	// http://www.ngs.noaa.gov/gps-toolbox/bc_velo.htm

	double tk;
	double mk;
	double ek;
	double ekold;
	double ekdot;
	double cek, sek;
	double pk;
	double pkdot;
	double c2pk, s2pk;
	double uk;
	double ukdot;
	double cuk, suk;
	double ok;
	double sok, cok;
	double ik;
	double ikdot;
	double sik, cik;
	double rk;
	double rkdot;
	double xpk, ypk;
	double xpkdot, ypkdot;

	double relativistic, OneMinusecosE, tmp;

	tk = g.saniye - eph.efemeris_zamani.saniye;

	if (tk > YARIM_HAFTADA_SANIYE)
		tk -= HAFTADA_SANIYE;
	else if (tk < -YARIM_HAFTADA_SANIYE)
		tk += HAFTADA_SANIYE;

	mk = eph.ortalama_anomalilik + eph.ortalama_acisal_hiz * tk;
	ek = mk;
	ekold = ek + 1.0;

	OneMinusecosE = 0; // Suppress the uninitialized warning.
	while (fabs(ek - ekold) > 1.0E-14)
	{
		ekold = ek;
		OneMinusecosE = 1.0 - eph.eksantriklik * cos(ekold);
		ek = ek + (mk - ekold + eph.eksantriklik * sin(ekold)) / OneMinusecosE;
	}

	sek = sin(ek);
	cek = cos(ek);

	ekdot = eph.ortalama_acisal_hiz / OneMinusecosE;

	relativistic = -4.442807633E-10 * eph.eksantriklik * eph.buyuk_eksen_A_karekok * sek;

	pk = atan2(eph.eksantriklik_karekok * sek, cek - eph.eksantriklik) + eph.perige_acisi;
	pkdot = eph.eksantriklik_karekok * ekdot / OneMinusecosE;

	s2pk = sin(2.0 * pk);
	c2pk = cos(2.0 * pk);

	uk = pk + eph.yorunge_konum_sinus_duzeltmesi * s2pk + eph.yorunge_konum_kosinus_duzeltmesi * c2pk;
	suk = sin(uk);
	cuk = cos(uk);
	ukdot = pkdot * (1.0 + 2.0 * (eph.yorunge_konum_sinus_duzeltmesi * c2pk - eph.yorunge_konum_kosinus_duzeltmesi * s2pk));

	rk = eph.buyuk_yaricap * OneMinusecosE + eph.yorunge_yaricap_kosinus_duzeltmesi * c2pk + eph.yorunge_yaricap_sinus_duzeltmesi * s2pk;
	rkdot = eph.buyuk_yaricap * eph.eksantriklik * sek * ekdot + 2.0 * pkdot * (eph.yorunge_yaricap_sinus_duzeltmesi * c2pk - eph.yorunge_yaricap_kosinus_duzeltmesi * s2pk);

	ik = eph.egilim + eph.egiklik_acisi_degisim_orani * tk + eph.egilim_kosinus_duzeltmesi * c2pk + eph.egilim_sinus_duzeltmesi * s2pk;
	sik = sin(ik);
	cik = cos(ik);
	ikdot = eph.egiklik_acisi_degisim_orani + 2.0 * pkdot * (eph.egilim_sinus_duzeltmesi * c2pk - eph.egilim_kosinus_duzeltmesi * s2pk);

	xpk = rk * cuk;
	ypk = rk * suk;
	xpkdot = rkdot * cuk - ypk * ukdot;
	ypkdot = rkdot * suk + xpk * ukdot;

	ok = eph.yukselen_dugum_boylami + tk * eph.omega_dot - DUNYA_ACISAL_HIZ * eph.efemeris_zamani.saniye;
	sok = sin(ok);
	cok = cos(ok);

	pos[0] = xpk * cok - ypk * cik * sok;
	pos[1] = xpk * sok + ypk * cik * cok;
	pos[2] = ypk * sik;

	tmp = ypkdot * cik - ypk * sik * ikdot;

	vel[0] = -eph.omega_dot * pos[1] + xpkdot * cok - tmp * sok;
	vel[1] = eph.omega_dot * pos[0] + xpkdot * sok + tmp * cok;
	vel[2] = ypk * cik * ikdot + ypkdot * sik;

	// Satellite clock correction
	tk = g.saniye - eph.gps_zamani.saniye;

	if (tk > YARIM_HAFTADA_SANIYE)
		tk -= HAFTADA_SANIYE;
	else if (tk < -YARIM_HAFTADA_SANIYE)
		tk += HAFTADA_SANIYE;

	clk[0] = eph.saat_ofseti + tk * (eph.saat_kaymasi + tk * eph.saat_hizlanmasi) + relativistic - eph.grup_gecikmesi;
	clk[1] = eph.saat_kaymasi + 2.0 * tk * eph.saat_hizlanmasi;

	return;
}
/*! \brief Kuzey-Doğu-Yükseklik formatından Azimut + Yükseklik formatına dönüştürür
 *  \param[in] neu Kuzey-Doğu-Yükseklik formatında girdi konumu
 *  \param[out] azel Azimut + Yükseklik olarak double türünde çıktı dizisi
 */
void neu2azel(double* azel, const double* neu)
{
	double ne; // Kuzey ve Doğu bileşenlerinin karışımının uzunluğunu tutan değişken

	// Azimut açısını hesapla: atan2, y eksenine göre x eksenindeki açıyı verir
	azel[0] = atan2(neu[1], neu[0]);
	if (azel[0] < 0.0) // Negatif açı durumunda 360 derece ekle
		azel[0] += (2.0 * PI);

	// Kuzey ve Doğu bileşenlerinin uzunluğunu hesapla
	ne = sqrt(neu[0] * neu[0] + neu[1] * neu[1]);
	// Yükseklik açısını hesapla: yatay düzleme göre yükseklik
	azel[1] = atan2(neu[2], ne);

	return; 
}


/*! \brief Uydu gorunurlugunu kontrol eder
 *  \param[in] eph Uydu ephemeris verisi
 *  \param[in] g GPS zamani
 *  \param[in] xyz Alici pozisyonu (ECEF formatinda)
 *  \param[in] elvMask Yukseklik esigi
 *  \param[out] azel Alicidan uyduya giden azimut ve yukseklik acisi
 *  \returns 1: Gorunur, 0: Gorunmez, -1: Gecersiz
 */

int uydu_gorunurlugunu_kontrol_et(efemeris_t eph, gps_zamani_t g, double* xyz, double elvMask, double* azel)
{
	double llh[3], neu[3]; // LLH: Enlem, boylam, yukseklik; NEU: Kuzey, Dogu, Yukari bileşenleri
	double pos[3], vel[3], clk[3], los[3]; // Uydu pozisyonu, hizi, saat verisi ve görüş hattı
	double tmat[3][3]; // Dönüşüm matrisi

	// Ephemeris verisi geçersizse
	if (eph.gecerli_bayrak != 1)
		return (-1); // Geçersiz durumu döndür

	// Alıcı pozisyonunu enlem, boylam, yükseklik (LLH) formata dönüştür
	xyz2llh(xyz, llh);

	// LLH'ye göre yerel dönüşüm matrisini oluştur
	ltc_matrisi(llh, tmat);

	// Uydu konumu, hızı ve saat verisini hesapla
	uydu_hiz_konum_saat_hesapla(eph, g, pos, vel, clk);

	// Alıcıdan uyduya olan görüş hattını (LOS) hesapla
	vektor_cikar(los, pos, xyz);

	// Görüş hattını NEU (Kuzey, Doğu, Yukarı) formata dönüştür
	ecef2neh(los, tmat, neu);

	// Azimut ve yükseklik açısını hesapla
	neu2azel(azel, neu);

	// Yükseklik açısı elvMask değerinden büyükse uydu görünür
	if (azel[1] * R2D > elvMask)
		return (1); // Görünür
	// aksi takdirde
	return (0); // Görünmez
}

/*! \brief Belirtilen Uydu Aracinin PRN'si için C/A kod dizisini olusturur
 *  \param[in] prn Uydu Aracinin PRN numarasi
 *  \param[out] ca Caller-tarafindan ayrilmis 1023 bayt uzunlugunda tam sayi dizisi
 */
void ca_kod_olustur(int* ca, int prn)
{
	int delay[] = { // PRN'ye göre gecikme dizisi
		  5,   6,   7,   8,  17,  18, 139, 140, 141, 251,
		252, 254, 255, 256, 257, 258, 469, 470, 471, 472,
		473, 474, 509, 512, 513, 514, 515, 516, 859, 860,
		861, 862 };

	int g1[CA_DIZI_UZUNLUGU], g2[CA_DIZI_UZUNLUGU]; // C/A kodu için iki genlik dizisi
	int r1[N_DWRD_SBF], r2[N_DWRD_SBF]; // Register dizileri
	int c1, c2; // Geçici değişkenler
	int i, j;

	if (prn < 1 || prn > 32) // PRN 1 ile 32 arasında değilse çık
		return;

	// Register dizilerini başlat
	for (i = 0; i < N_DWRD_SBF; i++)
		r1[i] = r2[i] = -1;

	// C/A kodunu oluşturmak için döngü
	for (i = 0; i < CA_DIZI_UZUNLUGU; i++)
	{
		g1[i] = r1[9]; // r1'in 9. elemanını g1 dizisine atar
		g2[i] = r2[9]; // r2'nin 9. elemanını g2 dizisine atar

		// c1 ve c2 hesaplamaları
		c1 = r1[2] * r1[9]; // c1, r1'in 2. elemanı ile 9. elemanının çarpımı
		c2 = r2[1] * r2[2] * r2[5] * r2[7] * r2[8] * r2[9]; // c2, r2'nin belirli elemanlarının çarpımı

		// Register dizilerini kaydır
		for (j = 9; j > 0; j--)
		{
			r1[j] = r1[j - 1]; // r1 dizisini sağa kaydır
			r2[j] = r2[j - 1]; // r2 dizisini sağa kaydır
		}
		r1[0] = c1; // Yeni c1 değerini r1'in başına ekle
		r2[0] = c2; // Yeni c2 değerini r2'nin başına ekle
	}

	// C/A kod dizisini oluştur
	for (i = 0, j = CA_DIZI_UZUNLUGU - delay[prn - 1]; i < CA_DIZI_UZUNLUGU; i++, j++)
		ca[i] = (1 - g1[i] * g2[j % CA_DIZI_UZUNLUGU]) / 2; // C/A kodunu hesapla

	/*
	 * C/A kodu hesaplama formülü:
	 * ca[i] = (1 - g1[i] * g2[j]) / 2
	 *
	 * Burada g1[i] ve g2[j], iki farklı genlik dizisidir ve
	 * j % CA_DIZI_UZUNLUGU ifadesi, döngüsel bir erişim sağlar.
	 * Hesaplamanın sonucu 0 veya 1 değerine dönüşür.
	 */

	return; // Fonksiyon sonlanıyor
}

/*! \brief Ephemeristen Alt Çerçeve Hesaplar
 *  \param[in] eph Verilen SV'ye ait ephemeris
 *  \param[out] sbf Her biri 10 uzun kelimeden oluşan beş alt çerçeve dizisi
 */
void ephemeris2subframe(const efemeris_t eph, const iyono_utc_t ionoutc, unsigned long sbf[5][N_DWRD_SBF])
{
	unsigned long wn;
	unsigned long efemeris_zamani;
	unsigned long toc;
	unsigned long iode;
	unsigned long iodc;
	long deltan;
	long cuc;
	long cus;
	long cic;
	long cis;
	long crc;
	long crs;
	unsigned long ecc;
	unsigned long sqrta;
	long m0;
	long omg0;
	long inc0;
	long aop;
	long omgdot;
	long idot;
	long af0;
	long af1;
	long af2;
	long tgd;
	int uyduhlth;
	int codeL2;

	unsigned long ura = 0UL;
	unsigned long dataId = 1UL;
	unsigned long sbf4_page25_uyduId = 63UL;
	unsigned long sbf5_page25_uyduId = 51UL;

	unsigned long wna;
	unsigned long toa;

	signed long alpha0, alpha1, alpha2, alpha3;
	signed long beta0, beta1, beta2, beta3;
	signed long A0, A1;
	signed long dtls, dtlsf;
	unsigned long tot, wnt, wnlsf, dn;
	unsigned long sbf4_page18_uyduId = 56UL;

	// FIXED: This has to be the "transmission" hafta number, not for the ephemeris reference time
	//wn = (unsigned long)(eph.efemeris_zamani.hafta%1024);
	wn = 0UL;
	efemeris_zamani = (unsigned long)(eph.efemeris_zamani.saniye / 16.0);
	toc = (unsigned long)(eph.gps_zamani.saniye / 16.0);
	iode = (unsigned long)(eph.veri_versiyonu_efemeris);
	iodc = (unsigned long)(eph.veri_versiyonu_saat);
	deltan = (long)(eph.delta_n / POW2_M43 / PI);
	cuc = (long)(eph.yorunge_konum_kosinus_duzeltmesi / POW2_M29);
	cus = (long)(eph.yorunge_konum_sinus_duzeltmesi / POW2_M29);
	cic = (long)(eph.egilim_kosinus_duzeltmesi / POW2_M29);
	cis = (long)(eph.egilim_sinus_duzeltmesi / POW2_M29);
	crc = (long)(eph.yorunge_yaricap_kosinus_duzeltmesi / POW2_M5);
	crs = (long)(eph.yorunge_yaricap_sinus_duzeltmesi / POW2_M5);
	ecc = (unsigned long)(eph.eksantriklik / POW2_M33);
	sqrta = (unsigned long)(eph.buyuk_eksen_A_karekok / POW2_M19);
	m0 = (long)(eph.ortalama_anomalilik / POW2_M31 / PI);
	omg0 = (long)(eph.yukselen_dugum_boylami / POW2_M31 / PI);
	inc0 = (long)(eph.egilim / POW2_M31 / PI);
	aop = (long)(eph.perige_acisi / POW2_M31 / PI);
	omgdot = (long)(eph.yukselen_dugum_degisim_orani / POW2_M43 / PI);
	idot = (long)(eph.egiklik_acisi_degisim_orani / POW2_M43 / PI);
	af0 = (long)(eph.saat_ofseti / POW2_M31);
	af1 = (long)(eph.saat_kaymasi / POW2_M43);
	af2 = (long)(eph.saat_hizlanmasi / POW2_M55);
	tgd = (long)(eph.grup_gecikmesi / POW2_M31);
	uyduhlth = (unsigned long)(eph.uydu_saglik);
	codeL2 = (unsigned long)(eph.L2_sinyal_kodu);

	wna = (unsigned long)(eph.efemeris_zamani.hafta % 256);
	toa = (unsigned long)(eph.efemeris_zamani.saniye / 4096.0);

	alpha0 = (signed long)round(ionoutc.iyon_alfa[0] / POW2_M30);
	alpha1 = (signed long)round(ionoutc.iyon_alfa[1] / POW2_M27);
	alpha2 = (signed long)round(ionoutc.iyon_alfa[2] / POW2_M24);
	alpha3 = (signed long)round(ionoutc.iyon_alfa[3] / POW2_M24);
	beta0 = (signed long)round(ionoutc.iyon_beta[0] / 2048.0);
	beta1 = (signed long)round(ionoutc.iyon_beta[1] / 16384.0);
	beta2 = (signed long)round(ionoutc.iyon_beta[2] / 65536.0);
	beta3 = (signed long)round(ionoutc.iyon_beta[3] / 65536.0);
	A0 = (signed long)round(ionoutc.delta_utc_a[0] / POW2_M30);
	A1 = (signed long)round(ionoutc.delta_utc_a[1] / POW2_M50);
	dtls = (signed long)(ionoutc.delta_ls);
	tot = (unsigned long)(ionoutc.iletim_zamani / 4096);
	wnt = (unsigned long)(ionoutc.iletim_haftasi % 256);
	// TO DO: Specify scheduled leap seconds in command options
	// 2016/12/31 (Sat) -> WNlsf = 1929, DN = 7 (http://navigationservices.agi.com/GNSSWeb/)
	// Days are counted from 1 to 7 (Sunday is 1).
	wnlsf = 1929 % 256;
	dn = 7;
	dtlsf = 18;

	// Subframe 1
	sbf[0][0] = 0x8B0000UL << 6;
	sbf[0][1] = 0x1UL << 8;
	sbf[0][2] = ((wn & 0x3FFUL) << 20) | ((codeL2 & 0x3UL) << 18) | ((ura & 0xFUL) << 14) | ((uyduhlth & 0x3FUL) << 8) | (((iodc >> 8) & 0x3UL) << 6);
	sbf[0][3] = 0UL;
	sbf[0][4] = 0UL;
	sbf[0][5] = 0UL;
	sbf[0][6] = (tgd & 0xFFUL) << 6;
	sbf[0][7] = ((iodc & 0xFFUL) << 22) | ((toc & 0xFFFFUL) << 6);
	sbf[0][8] = ((af2 & 0xFFUL) << 22) | ((af1 & 0xFFFFUL) << 6);
	sbf[0][9] = (af0 & 0x3FFFFFUL) << 8;

	// Subframe 2
	sbf[1][0] = 0x8B0000UL << 6;
	sbf[1][1] = 0x2UL << 8;
	sbf[1][2] = ((iode & 0xFFUL) << 22) | ((crs & 0xFFFFUL) << 6);
	sbf[1][3] = ((deltan & 0xFFFFUL) << 14) | (((m0 >> 24) & 0xFFUL) << 6);
	sbf[1][4] = (m0 & 0xFFFFFFUL) << 6;
	sbf[1][5] = ((cuc & 0xFFFFUL) << 14) | (((ecc >> 24) & 0xFFUL) << 6);
	sbf[1][6] = (ecc & 0xFFFFFFUL) << 6;
	sbf[1][7] = ((cus & 0xFFFFUL) << 14) | (((sqrta >> 24) & 0xFFUL) << 6);
	sbf[1][8] = (sqrta & 0xFFFFFFUL) << 6;
	sbf[1][9] = (efemeris_zamani & 0xFFFFUL) << 14;

	// Subframe 3
	sbf[2][0] = 0x8B0000UL << 6;
	sbf[2][1] = 0x3UL << 8;
	sbf[2][2] = ((cic & 0xFFFFUL) << 14) | (((omg0 >> 24) & 0xFFUL) << 6);
	sbf[2][3] = (omg0 & 0xFFFFFFUL) << 6;
	sbf[2][4] = ((cis & 0xFFFFUL) << 14) | (((inc0 >> 24) & 0xFFUL) << 6);
	sbf[2][5] = (inc0 & 0xFFFFFFUL) << 6;
	sbf[2][6] = ((crc & 0xFFFFUL) << 14) | (((aop >> 24) & 0xFFUL) << 6);
	sbf[2][7] = (aop & 0xFFFFFFUL) << 6;
	sbf[2][8] = (omgdot & 0xFFFFFFUL) << 6;
	sbf[2][9] = ((iode & 0xFFUL) << 22) | ((idot & 0x3FFFUL) << 8);

	if (ionoutc.gecerli_bayrak == TRUE)
	{
		// Subframe 4, page 18
		sbf[3][0] = 0x8B0000UL << 6;
		sbf[3][1] = 0x4UL << 8;
		sbf[3][2] = (dataId << 28) | (sbf4_page18_uyduId << 22) | ((alpha0 & 0xFFUL) << 14) | ((alpha1 & 0xFFUL) << 6);
		sbf[3][3] = ((alpha2 & 0xFFUL) << 22) | ((alpha3 & 0xFFUL) << 14) | ((beta0 & 0xFFUL) << 6);
		sbf[3][4] = ((beta1 & 0xFFUL) << 22) | ((beta2 & 0xFFUL) << 14) | ((beta3 & 0xFFUL) << 6);
		sbf[3][5] = (A1 & 0xFFFFFFUL) << 6;
		sbf[3][6] = ((A0 >> 8) & 0xFFFFFFUL) << 6;
		sbf[3][7] = ((A0 & 0xFFUL) << 22) | ((tot & 0xFFUL) << 14) | ((wnt & 0xFFUL) << 6);
		sbf[3][8] = ((dtls & 0xFFUL) << 22) | ((wnlsf & 0xFFUL) << 14) | ((dn & 0xFFUL) << 6);
		sbf[3][9] = (dtlsf & 0xFFUL) << 22;

	}
	else
	{
		// Subframe 4, page 25
		sbf[3][0] = 0x8B0000UL << 6;
		sbf[3][1] = 0x4UL << 8;
		sbf[3][2] = (dataId << 28) | (sbf4_page25_uyduId << 22);
		sbf[3][3] = 0UL;
		sbf[3][4] = 0UL;
		sbf[3][5] = 0UL;
		sbf[3][6] = 0UL;
		sbf[3][7] = 0UL;
		sbf[3][8] = 0UL;
		sbf[3][9] = 0UL;
	}

	// Subframe 5, page 25
	sbf[4][0] = 0x8B0000UL << 6;
	sbf[4][1] = 0x5UL << 8;
	sbf[4][2] = (dataId << 28) | (sbf5_page25_uyduId << 22) | ((toa & 0xFFUL) << 14) | ((wna & 0xFFUL) << 6);
	sbf[4][3] = 0UL;
	sbf[4][4] = 0UL;
	sbf[4][5] = 0UL;
	sbf[4][6] = 0UL;
	sbf[4][7] = 0UL;
	sbf[4][8] = 0UL;
	sbf[4][9] = 0UL;

	return;
}
/*! \brief 1'e ayarlanmış bit sayısını sayar
 *  \param[in] v Bitlerin sayıldığı uzun kelime
 *  \returns 1'e ayarlanmış bitlerin sayısı
 */
unsigned long bitleri_say(unsigned long v)
{
	unsigned long c;
	const int S[] = { 1, 2, 4, 8, 16 };
	const unsigned long B[] = {
		0x55555555, 0x33333333, 0x0F0F0F0F, 0x00FF00FF, 0x0000FFFF };

	c = v;
	c = ((c >> S[0]) & B[0]) + (c & B[0]);
	c = ((c >> S[1]) & B[1]) + (c & B[1]);
	c = ((c >> S[2]) & B[2]) + (c & B[2]);
	c = ((c >> S[3]) & B[3]) + (c & B[3]);
	c = ((c >> S[4]) & B[4]) + (c & B[4]);

	return(c);
}
/*! \brief Bir alt çerçevenin verilen kelimesi için Kontrol Toplamını hesaplar
 *  \param[in] source Girdi verisi
 *  \param[in] nib Bu kelime bilgi taşımayan bitler içeriyor mu?
 *  \returns Hesaplanan Kontrol Toplamı
 */
unsigned long checksum_hesapla(unsigned long source, int nib)
{
	/*
	Bits 31 to 30 = 2 LSBs of the previous transmitted word, D29* and D30*
	Bits 29 to  6 = Source data bits, d1, d2, ..., d24
	Bits  5 to  0 = Empty parity bits
	*/

	/*
	Bits 31 to 30 = 2 LSBs of the previous transmitted word, D29* and D30*
	Bits 29 to  6 = Data bits transmitted by the SV, D1, D2, ..., D24
	Bits  5 to  0 = Computed parity bits, D25, D26, ..., D30
	*/

	/*
					  1            2           3
	bit    12 3456 7890 1234 5678 9012 3456 7890
	---    -------------------------------------
	D25    11 1011 0001 1111 0011 0100 1000 0000
	D26    01 1101 1000 1111 1001 1010 0100 0000
	D27    10 1110 1100 0111 1100 1101 0000 0000
	D28    01 0111 0110 0011 1110 0110 1000 0000
	D29    10 1011 1011 0001 1111 0011 0100 0000
	D30    00 1011 0111 1010 1000 1001 1100 0000
	*/

	unsigned long bmask[6] = {
		0x3B1F3480UL, 0x1D8F9A40UL, 0x2EC7CD00UL,
		0x1763E680UL, 0x2BB1F340UL, 0x0B7A89C0UL };

	unsigned long D;
	unsigned long d = source & 0x3FFFFFC0UL;
	unsigned long D29 = (source >> 31) & 0x1UL;
	unsigned long D30 = (source >> 30) & 0x1UL;

	if (nib) // Non-information bearing bits for word 2 and 10
	{
		/*
		Solve bits 23 and 24 to presearve parity check
		with zeros in bits 29 and 30.
		*/

		if ((D30 + bitleri_say(bmask[4] & d)) % 2)
			d ^= (0x1UL << 6);
		if ((D29 + bitleri_say(bmask[5] & d)) % 2)
			d ^= (0x1UL << 7);
	}

	D = d;
	if (D30)
		D ^= 0x3FFFFFC0UL;

	D |= ((D29 + bitleri_say(bmask[0] & d)) % 2) << 5;
	D |= ((D30 + bitleri_say(bmask[1] & d)) % 2) << 4;
	D |= ((D29 + bitleri_say(bmask[2] & d)) % 2) << 3;
	D |= ((D30 + bitleri_say(bmask[3] & d)) % 2) << 2;
	D |= ((D30 + bitleri_say(bmask[4] & d)) % 2) << 1;
	D |= ((D29 + bitleri_say(bmask[5] & d)) % 2);

	D &= 0x3FFFFFFFUL;
	//D |= (source & 0xC0000000UL); // Add D29* and D30* from source data bits

	return(D);
}
/*! \brief Navigasyon mesaji uretir
 *  \param[in] g GPS zaman bilgisi
 *  \param[in,out] chan Kanal bilgisi ve veri dizileri
 *  \param[in] init Baslatma durumu (1: Baslat, 0: Devam et)
 *  \returns 1 basarili, 0 basarisiz
 */
int navigasyon_mesaji_olustur(gps_zamani_t g, kanal_t* chan, int init)
{
	int iwrd, isbf; // Yazma döngü değişkenleri
	gps_zamani_t g0; // Zaman bilgisi yapısı
	unsigned long wn, tow; // Hafta numarası ve zaman üzerinde işlem
	unsigned sbfwrd; // SBF kelimesi
	unsigned long prevwrd; // Önceki kelimenin değerini saklamak için
	int nib; // Bilgi taşımayan bitler için bayrak

	// GPS zamanını 30 saniyelik çerçeveye hizala
	g0.hafta = g.hafta;
	g0.saniye = (double)(((unsigned long)(g.saniye + 0.5)) / 30UL) * 30.0; // Tam çerçeve uzunluğuna hizala
	chan->g0 = g0; // Veri bit referans zamanı

	// Hafta numarasını hesapla ve TOW'u ayarla
	wn = (unsigned long)(g0.hafta % 1024);
	tow = ((unsigned long)g0.saniye) / 6UL; // 6 saniyelik TOW

	if (init == 1) // Alt çerçeve 5'i başlat
	{
		prevwrd = 0UL; // Önceki kelimeyi sıfırla

		for (iwrd = 0; iwrd < N_DWRD_SBF; iwrd++) // SBF kelimelerini doldur
		{
			sbfwrd = chan->subframe[4][iwrd]; // Dördüncü alt çerçeveye eriş

			// TOW sayım mesajını HWO'ya ekle
			if (iwrd == 1)
				sbfwrd |= ((tow & 0x1FFFFUL) << 13); // TOW'u ekle

			// Kontrol toplamını hesapla
			sbfwrd |= (prevwrd << 30) & 0xC0000000UL; // Önceki iletilen kelimenin 2 LSB'si
			nib = ((iwrd == 1) || (iwrd == 9)) ? 1 : 0; // 2 ve 10 için bilgi taşımayan bitler
			chan->dwrd[iwrd] = checksum_hesapla(sbfwrd, nib); // Kontrol toplamını hesapla ve yaz

			prevwrd = chan->dwrd[iwrd]; // Önceki kelimeyi güncelle
		}
	}
	else // Alt çerçeve 5'i kaydet
	{
		for (iwrd = 0; iwrd < N_DWRD_SBF; iwrd++)
		{
			chan->dwrd[iwrd] = chan->dwrd[N_DWRD_SBF * N_SBF + iwrd]; // Önceki alt çerçeveden kelimeleri al

			prevwrd = chan->dwrd[iwrd]; // Önceki kelimeyi güncelle
		}
		/*
		// Sağlamlık kontrolü
		if (((chan->dwrd[1]) & (0x1FFFFUL << 13)) != ((tow & 0x1FFFFUL) << 13))
		{
			fprintf(stderr, "\nUYARI: Alt cerceve 5'te gecersiz TOW.\n");
			return(0); // Hata durumunda 0 döndür
		}
		*/
	}

	for (isbf = 0; isbf < N_SBF; isbf++) // Her alt çerçeve için
	{
		tow++; // TOW değerini arttır

		for (iwrd = 0; iwrd < N_DWRD_SBF; iwrd++) // SBF kelimelerini doldur
		{
			sbfwrd = chan->subframe[isbf][iwrd]; // Geçerli alt çerçeveye eriş

			// Alt çerçeve 1'e iletim hafta numarasını ekle
			if ((isbf == 0) && (iwrd == 2))
				sbfwrd |= (wn & 0x3FFUL) << 20; // Hafta numarasını ekle

			// TOW sayım mesajını HWO'ya ekle
			if (iwrd == 1)
				sbfwrd |= ((tow & 0x1FFFFUL) << 13); // TOW'u ekle

			// Kontrol toplamını hesapla
			sbfwrd |= (prevwrd << 30) & 0xC0000000UL; // Önceki iletilen kelimenin 2 LSB'si
			nib = ((iwrd == 1) || (iwrd == 9)) ? 1 : 0; // 2 ve 10 için bilgi taşımayan bitler
			chan->dwrd[(isbf + 1) * N_DWRD_SBF + iwrd] = checksum_hesapla(sbfwrd, nib); // Kontrol toplamını hesapla ve yaz

			prevwrd = chan->dwrd[(isbf + 1) * N_DWRD_SBF + iwrd]; // Önceki kelimeyi güncelle
		}
	}

	return(1); 
}
/*! \brief Ionosfer gecikmesini hesaplar
 *  \param[in] ionoutc Ionosfer UTC verileri
 *  \param[in] g GPS zamani
 *  \param[in] llh Enlem, boylam ve yukseklik dizisi
 *  \param[in] azel Aci dizisi (azimut, elevasyon)
 *  \returns Ionosfer gecikmesi
 */
double iyonosferik_gecikme_hesapla(const iyono_utc_t* ionoutc, gps_zamani_t g, double* llh, double* azel)
{
	double iono_delay = 0.0; // Iyonosferik gecikmeyi tutan değişken
	double E, phi_u, lam_u, F; // Değişkenler

	if (ionoutc->aktif == FALSE)
		return (0.0); // Ionosferik gecikme yoksa 0 döner

	E = azel[1] / PI; // Elevation açısını yarım daire cinsine çevir
	phi_u = llh[0] / PI; // Kullanıcının enlem değerini yarım daire cinsine çevir
	lam_u = llh[1] / PI; // Kullanıcının boylam değerini yarım daire cinsine çevir

	// Obliquity faktörü
	F = 1.0 + 16.0 * pow((0.53 - E), 3.0);

	if (ionoutc->gecerli_bayrak == FALSE)
		iono_delay = F * 5.0e-9 * ISIK_HIZI; // Iyonosferik gecikme hesapla
	else
	{
		double t, psi, phi_i, lam_i, phi_m, phi_m2, phi_m3; // Geçici değişkenler
		double AMP, PER, X, X2, X4; // Amplitude ve Periyot

		// Kullanıcı pozisyonu ile iyonosferik kesişim noktası arasındaki merkezi açı
		psi = 0.0137 / (E + 0.11) - 0.022;

		// İyonosferik kesişim noktasının geodezik enlemi
		phi_i = phi_u + psi * cos(azel[0]);
		if (phi_i > 0.416)
			phi_i = 0.416; // Enlem sınırı
		else if (phi_i < -0.416)
			phi_i = -0.416; // Enlem sınırı

		// İyonosferik kesişim noktasının geodezik boylamı
		lam_i = lam_u + psi * sin(azel[0]) / cos(phi_i * PI);

		// İyonosferik kesişim noktasının geomanyetik enlemi
		phi_m = phi_i + 0.064 * cos((lam_i - 1.617) * PI);
		phi_m2 = phi_m * phi_m; // Enlemin karesi
		phi_m3 = phi_m2 * phi_m; // Enlemin küpü

		// Amplitüd hesaplama
		AMP = ionoutc->iyon_alfa[0] + ionoutc->iyon_alfa[1] * phi_m
			+ ionoutc->iyon_alfa[2] * phi_m2 + ionoutc->iyon_alfa[3] * phi_m3;
		if (AMP < 0.0)
			AMP = 0.0; // Negatif amplitüdü sıfıra ayarla

		// Periyot hesaplama
		PER = ionoutc->iyon_beta[0] + ionoutc->iyon_beta[1] * phi_m
			+ ionoutc->iyon_beta[2] * phi_m2 + ionoutc->iyon_beta[3] * phi_m3;
		if (PER < 72000.0)
			PER = 72000.0; // Minimum periyot değeri

		// Yerel zaman (saniye)
		t = GUNDE_SANIYE / 2.0 * lam_i + g.saniye; // Yerel zaman hesapla
		while (t >= GUNDE_SANIYE)
			t -= GUNDE_SANIYE; // Günlük döngüyü sağla
		while (t < 0)
			t += GUNDE_SANIYE; // Günlük döngüyü sağla

		// Faz (radyan)
		X = 2.0 * PI * (t - 50400.0) / PER;

		if (fabs(X) < 1.57) // X'in mutlak değeri 1.57'den küçükse
		{
			X2 = X * X; // X'in karesi
			X4 = X2 * X2; // X'in dördüncü kuvveti
			iono_delay = F * (5.0e-9 + AMP * (1.0 - X2 / 2.0 + X4 / 24.0)) * ISIK_HIZI; // Iyonosfer gecikmesini hesapla
		}
		else
			iono_delay = F * 5.0e-9 * ISIK_HIZI; // Iyonosfer gecikmesi hesapla
	}

	return (iono_delay); // Hesaplanan iyonosfer gecikmesini döndür
}
/*! \brief Iki vektorin noktasal carpimini hesaplar
 *  \param[in] x1 Ilk carpan
 *  \param[in] x2 Ikinci carpan
 *  \returns Her iki carpannin noktasal carpimi
 */
double vektor_noktasal_carpim(const double* x1, const double* x2)
{
	return(x1[0] * x2[0] + x1[1] * x2[1] + x1[2] * x2[2]);
}

/*! \brief Uydu ile alici arasindaki mesafeyi hesaplar
 *  \param[out] rho Hesaplanan mesafe
 *  \param[in] eph Uyduya ait ephemeris verileri
 *  \param[in] ionoutc Iyonosfer ve UTC bilgileri
 *  \param[in] g Sinyalin alindigi anda GPS zamani
 *  \param[in] xyz Alicinin konumu
 */
void mesafe_hesapla(range_t* rho, efemeris_t eph, iyono_utc_t* ionoutc, gps_zamani_t g, double xyz[])
{
	double pos[3], vel[3], clk[2]; // Uydu konumu, hızı ve saat bilgileri
	double los[3]; // Uydudan alıcıya olan vektör
	double tau; // Işık süresi
	double range, rate; // Mesafe ve hız
	double xrot, yrot; // Dünyanın dönüş düzeltmesi için geçici değişkenler

	double llh[3], neu[3]; // Enlem, boylam, yükseklik ve NEU koordinatları
	double tmat[3][3]; // Dönüşüm matrisi

	// SV (Uydu) pozisyonunu ve hızını, sinyalin alındığı anda hesapla.
	uydu_hiz_konum_saat_hesapla(eph, g, pos, vel, clk);

	// Alıcıdan uyduya olan vektörü hesapla ve ışık süresini bul.
	vektor_cikar(los, pos, xyz); // Vektörü çıkar
	tau = vektor_norm_al(los) / ISIK_HIZI; // Işık süresi hesapla

	// Uydunun pozisyonunu, iletim zamanına kadar geri çek.
	pos[0] -= vel[0] * tau; // X koordinatı
	pos[1] -= vel[1] * tau; // Y koordinatı
	pos[2] -= vel[2] * tau; // Z koordinatı

	// Dünya dönüş düzeltmesi. Hız değişimi göz ardı edilebilir.
	xrot = pos[0] + pos[1] * DUNYA_ACISAL_HIZ * tau; // Yeni X konumu
	yrot = pos[1] - pos[0] * DUNYA_ACISAL_HIZ * tau; // Yeni Y konumu
	pos[0] = xrot; // X konumunu güncelle
	pos[1] = yrot; // Y konumunu güncelle

	// Yeni alıcıdan uyduya olan vektörü hesapla ve uydu mesafesini bul.
	vektor_cikar(los, pos, xyz); // Yeni vektör
	range = vektor_norm_al(los); // Mesafeyi hesapla
	rho->d = range; // Mesafeyi kaydet

	// Psödo mesafe hesapla.
	rho->range = range - ISIK_HIZI * clk[0]; // Psödo mesafe

	// Uydu ve alıcının göreceli hızını hesapla.
	rate = vektor_noktasal_carpim(vel, los) / range; // Hız hesaplama

	// Psödo mesafe hızı.
	rho->rate = rate; // Psödo mesafe hızı

	// Uygulama zamanı.
	rho->g = g; // Zaman bilgisini kaydet

	// Azimut ve yükseklik açılarını hesapla.
	xyz2llh(xyz, llh); // Koordinat dönüşümü
	ltc_matrisi(llh, tmat); // Dönüşüm matrisini hesapla
	ecef2neh(los, tmat, neu); // ECEF'den NEU'ya dönüşüm
	neu2azel(rho->azel, neu); // NEU'dan azimut ve yükseklik açısına dönüşüm

	// Iyonosferik gecikmeyi ekle
	rho->iono_delay = iyonosferik_gecikme_hesapla(ionoutc, g, llh, rho->azel); // Iyonosferik gecikmeyi hesapla
	rho->range += rho->iono_delay; // Mesafeye ekle

	return;
}

/*! \brief Kanal ayirir ve gorunur uydu sayisini hesaplar
 *  \param[out] chan Allocated channel array
 *  \param[in] eph Uydu ephemeris verisi
 *  \param[in] ionoutc Ionosfer ve UTC verisi
 *  \param[in] grx Alici GPS zamani
 *  \param[in] xyz Alici pozisyonu (ECEF formatinda)
 *  \param[in] elvMask Yukseklik esigi
 *  \returns Gorunur uydu sayisi
 */
int kanal_ayir(kanal_t* kanallar, efemeris_t* efemerisler, iyono_utc_t ionoutc, gps_zamani_t grx, double* xyz, double elvMask)
{
	int nsat = 0;  // Görünür uydu sayısını tutar
	int i, uydu;
	double azel[2]; // Azimut ve elevasyon değerleri

	range_t rho; // Mesafe verisi
	double ref[3] = { 0.0 }; // Referans pozisyonu
	double r_ref, r_xyz; // Referans ve alıcı mesafeleri
	double phase_ini; // Başlangıç fazı

	// Tüm uydular için görünürlük kontrolü
	for (uydu = 0; uydu < MAKSIMUM_UYDU; uydu++)
	{
		// Eğer uydu görünürse
		if (uydu_gorunurlugunu_kontrol_et(efemerisler[uydu], grx, xyz, 0.0, azel) == 1)
		{
			nsat++; // Görünür uydu sayısını artır

			// Eğer uydu henüz ayrılmamışsa
			if (ayrilmis_uydular[uydu] == -1)
			{
				// Yeni uydu tahsisi
				for (i = 0; i < MAKSIMUM_KANAL; i++)
				{
					// Eğer kanal boşsa
					if (kanallar[i].prn == 0)
					{
						// Kanalı başlat
						kanallar[i].prn = uydu + 1;
						kanallar[i].azel[0] = azel[0];
						kanallar[i].azel[1] = azel[1];

						// C/A kodu üretimi
						ca_kod_olustur(kanallar[i].ca, kanallar[i].prn);

						// Subframe oluştur
						ephemeris2subframe(efemerisler[uydu], ionoutc, kanallar[i].subframe);

						// Navigasyon mesajı oluştur
						navigasyon_mesaji_olustur(grx, &kanallar[i], 1);

						// Pseudorange başlat
						mesafe_hesapla(&rho, efemerisler[uydu], &ionoutc, grx, xyz);
						kanallar[i].rho0 = rho;

						// Taşıyıcı fazı başlat
						r_xyz = rho.range;

						mesafe_hesapla(&rho, efemerisler[uydu], &ionoutc, grx, ref);
						r_ref = rho.range;

						phase_ini = (2.0 * r_ref - r_xyz) / LAMBDA_L1;
#ifdef FLOAT_tasiyici_faz
						kanallar[i].tasiyici_faz = phase_ini - floor(phase_ini);
#else
						phase_ini -= floor(phase_ini);
						kanallar[i].tasiyici_faz = (unsigned int)(512.0 * 65536.0 * phase_ini);
#endif
						// Kanal tahsisi tamamlandı
						break;
					}
				}

				// Uydu tahsis kanalını ayarla
				if (i < MAKSIMUM_KANAL)
					ayrilmis_uydular[uydu] = i;
			}
		}
		// Eğer uydu görünmüyorsa ve tahsis edilmişse
		else if (ayrilmis_uydular[uydu] >= 0)
		{
			// Kanalı temizle
			kanallar[ayrilmis_uydular[uydu]].prn = 0;

			// Uydu tahsis bayrağını temizle
			ayrilmis_uydular[uydu] = -1;
		}
	}

	return(nsat); // Görünür uydu sayısını döndür
}

/*! \brief Verilen kanal (uydu) için kod fazını hesaplar.
 *  Bu fonksiyon, verilen kanal (uydu) için kod fazı, taşıyıcı frekansı ve veri bitini hesaplar.
 *  Hesaplamalar, mevcut mesafe (pseudorange) ve zaman farkı (dt) kullanılarak yapılır.
 *  \param chan İşlem yapılacak kanal (güncellenir).
 *  \param[in] rho1 Mevcut mesafe (pseudorange), \a dt sona erdikten sonra alınan değer.
 *  \param[in] dt Delta-t (zaman farkı) saniye cinsinden.
 */
void kod_fazi_hesapla(kanal_t* chan, range_t rho1, double dt)
{
	double ms;
	int ims;
	double rhorate;

	// Pseudorange hızını hesapla.
	rhorate = (rho1.range - chan->rho0.range) / dt;

	// Taşıyıcı ve kod frekanslarını hesapla.
	chan->tasiyici_frekansi = -rhorate / LAMBDA_L1;
	chan->kod_frekansi = CODE_FREQ + chan->tasiyici_frekansi * CARR_TO_CODE;

	// İlk kod fazı ve veri bit sayaçlarını ayarla.
	ms = ((gps_zaman_farki_hesapla(chan->rho0.g, chan->g0) + 6.0) - chan->rho0.range / ISIK_HIZI) * 1000.0;

	ims = (int)ms;
	chan->kod_fazi = (ms - (double)ims) * CA_DIZI_UZUNLUGU; // chip cinsinden

	chan->ilk_word = ims / 600; // 1 word = 30 bit = 600 ms
	ims -= chan->ilk_word * 600;

	chan->ilk_bit = ims / 20; // 1 bit = 20 kod = 20 ms
	ims -= chan->ilk_bit * 20;

	chan->ilk_kod = ims; // 1 kod = 1 ms

	// CA kodunu ve veri bitini belirle.
	chan->ca_kodu = chan->ca[(int)chan->kod_fazi] * 2 - 1;
	chan->veri_biti = (int)((chan->dwrd[chan->ilk_word] >> (29 - chan->ilk_bit)) & 0x1UL) * 2 - 1;

	// Geçerli pseudorange değerini kaydet.
	chan->rho0 = rho1;

	return;
}
/*! \brief Kullanici hareketleri listesini girdi dosyasindan okur
 *  \param[out] xyz Kullanici hareketi için ECEF vektörleri içeren çıktý dizisi
 *  \param[in] filename Metin girdi dosyasinin dosya adi
 *  \returns Okunan kullanici veri hareket kayitlari sayisi, hata durumunda -1
 */
int kullanici_haraketini_oku(double xyz[KULLANICI_HAREKET_BOYUTU][3], const char* filename)
{
	FILE* fp;
	int numd;
	char str[MAKSIMUM_KARAKTER];
	double t, x, y, z;

	if (NULL == (fp = fopen(filename, "rt")))
		return(-1);

	for (numd = 0; numd < KULLANICI_HAREKET_BOYUTU; numd++)
	{
		if (fgets(str, MAKSIMUM_KARAKTER, fp) == NULL)
			break;

		if (EOF == sscanf(str, "%lf,%lf,%lf,%lf", &t, &x, &y, &z)) // Read CSV line
			break;

		xyz[numd][0] = x;
		xyz[numd][1] = y;
		xyz[numd][2] = z;
	}

	fclose(fp);

	return (numd);
}
// GPS zamanını anlamlı bir formata dönüştüren fonksiyon
void yazdir_anlamli_gps_zamani(gps_zamani_t zaman)
{
	// Ocak 1980 tarihi (Unix epoch başlangıcı 1 Ocak 1970'dir)
	time_t gps_epoch = 315964800; // 1 Ocak 1980 00:00:00 UTC'nin Unix zaman damgası
	// Haftayı saniyeye dönüştür
	time_t total_seconds = gps_epoch + (zaman.hafta * 7 * 24 * 60 * 60) + (time_t)zaman.saniye;

	// time_t'tan struct tm'e dönüştür
	struct tm* tm_info;
	tm_info = gmtime(&total_seconds); // UTC zamanı

	// Anlamlı formatta yazdır
	char buffer[80];
	strftime(buffer, sizeof(buffer), "%Y-%m-%d %H:%M:%S", tm_info);
	fprintf(stderr, "\nGPS Tarihi: %s\t", buffer);
}


int main(int argc, char* argv[])
{

	//setlocale(LC_ALL, "Turkish");
	//=================================================================================================================
	// Bölüm-1:		Değişken Tanımlamaları 
	//=================================================================================================================
		
	/*-------------------------------------Program Değişkenleri------------------------------------------------------*/
	FILE* fp;
	int nmeaGGA = FALSE;
	char navfile[MAKSIMUM_KARAKTER];
	char outfile[MAKSIMUM_KARAKTER];
	char umfile[MAKSIMUM_KARAKTER];
	double xyz[KULLANICI_HAREKET_BOYUTU][3];
	double llh[3];
	int iumd;
	int numd;
	int result;
	int komut;
	const char* opsiyonlar = "e:u:g:c:l:o:s:b:T:t:d:iv";
	/*-------------------------------------Senaryo Değişkenleri------------------------------------------------------*/
	int uydu;
	int neph, efemeris_indeksi;
	efemeris_t efemerisler[EPHEMERIS_DIZI_UZUNLUGU][MAKSIMUM_UYDU];
	gps_zamani_t g0;
	int statik_konum_modu = FALSE;
	takvim_zamani_t t0, tmin, tmax;
	gps_zamani_t gmin, gmax;
	iyono_utc_t ionoutc;
	double dt;
	int igrx;
	double duration;
	int iduration;
	int verb;
	int timeoverwrite = FALSE; // Overwirte the TOC and TOE in the RINEX file
	int i;
	kanal_t kanallar[MAKSIMUM_KANAL];
	double elvmask = 0.0; // in degree
	clock_t tstart, tend;
	gps_zamani_t grx;
	/*-------------------------------------Sinyal Değişkenleri-------------------------------------------------------*/
	int ip, qp;
	int iTable;
	short* iq_buff = NULL;
	signed char* iq8_buff = NULL;
	double samp_freq;
	int iq_buff_size;
	int data_format;
	int gain[MAKSIMUM_KANAL];
	double path_loss;
	double ant_gain;
	double ant_pat[37];
	int ibs; // boresight angle index
	double delt;
	int isamp;
	/*-------------------------------------Varsayılan Atamalar-------------------------------------------------------*/
	navfile[0] = 0;
	umfile[0] = 0;
	strcpy(outfile, "gpssim.bin");
	//samp_freq = 5.2e6;
	samp_freq = 2.6e6;
	data_format = SC16;
	g0.hafta = -1; // Invalid start time
	iduration = KULLANICI_HAREKET_BOYUTU;
	duration = (double)iduration / 10.0; // Default duration
	verb = FALSE;
	ionoutc.aktif = TRUE;

	//=================================================================================================================
	//								Bölüm-2:	Kullanıcıdan Veri Oku-İşle
	//=================================================================================================================

	if (argc < 3)
	{
		printf("%s", talimatlar);
		exit(1);
	}
	/*-------------------------------------Kullanıcı Opsiyon ve Argümanlarını Al---------------------------------------*/
	while ((result = komut_getir(argc, argv, "e:u:g:c:l:o:s:b:T:t:d:iv")) != -1)
	{
		switch (result)
		{
		case 'e':/*--------Navigasyon Dosyası Dizini-----------------------------*/
			strcpy(navfile, opsiyon_argumani);
			break;

		case 'u':/*--------Dinamik Kullanıcı Hareketi ECEF Dosyası Dizini--------*/
			strcpy(umfile, opsiyon_argumani);
			nmeaGGA = FALSE;
			break;

		case 'g':/*--------Dinamik Kullanıcı Hareketi NMEA Dosyası Dizini--------*/
			strcpy(umfile, opsiyon_argumani);
			nmeaGGA = TRUE;
			break;

		case 'c':/*--------Statik Kullanıcı Hareketi ECEF Verisi-----------------*/
			// Static ECEF coordinates input mode
			statik_konum_modu = TRUE;
			sscanf(opsiyon_argumani, "%lf,%lf,%lf", &xyz[0][0], &xyz[0][1], &xyz[0][2]);
			break;

		case 'l':/*--------Statik Kullanıcı Hareketi NEU Verisi------------------*/
			// Static geodetic coordinates input mode
			// Added by scateu@gmail.com
			statik_konum_modu = TRUE;
			sscanf(opsiyon_argumani, "%lf,%lf,%lf", &llh[0], &llh[1], &llh[2]);
			llh[0] = llh[0] / R2D; // convert to RAD
			llh[1] = llh[1] / R2D; // convert to RAD
			llh2xyz(llh, xyz[0]); // Convert llh to xyz
			break;

		case 'o':/*--------IQ Örnekleme Çıktı Dosyası Dizini---------------------*/
			strcpy(outfile, opsiyon_argumani);
			break;

		case 's':/*--------Örnekleme Frekansı------------------------------------*/
			samp_freq = atof(opsiyon_argumani);
			if (samp_freq < 1.0e6)
			{
				fprintf(stderr, "HATA: Gecersiz ornegleme frekansi.\n");
				exit(1);
			}
			break;

		case 'b':/*--------I/Q veri formatı--------------------------------------*/
			data_format = atoi(opsiyon_argumani);
			if (data_format != SC01 && data_format != SC08 && data_format != SC16)
			{
				fprintf(stderr, "HATA: Gecersiz I/Q veri formati.\n");
				exit(1);
			}
			break;

		case 'T':/*--------Senaryo Başlangıcı Üstüne Yaz---------------------------*/
			timeoverwrite = TRUE;
			if (strncmp(opsiyon_argumani, "now", 3) == 0)
			{
				time_t timer;
				struct tm* gmt;

				time(&timer);
				gmt = gmtime(&timer);

				t0.yil = gmt->tm_year + 1900;
				t0.ay  = gmt->tm_mon + 1;
				t0.gun = gmt->tm_mday;
				t0.saat = gmt->tm_hour;
				t0.dakika = gmt->tm_min;
				t0.saniye = (double)gmt->tm_sec;
				printf("Sistem Zamanı: %04d-%02d-%02d %02d:%02d:%02.0f UTC\n",
					t0.yil,t0.ay, t0.gun, t0.saat, t0.dakika, t0.saniye);
				takvim2gps(&t0, &g0);
			}
			else {
				sscanf(opsiyon_argumani, "%d/%d/%d,%d:%d:%lf", &t0.yil, &t0.ay, &t0.gun, &t0.saat, &t0.dakika, &t0.saniye);
				if (t0.yil <= 1980 || t0.ay < 1 || t0.ay>12 || t0.gun < 1 || t0.gun>31 ||
					t0.saat < 0 || t0.saat>23 || t0.dakika < 0 || t0.dakika>59 || t0.saniye < 0.0 || t0.saniye >= 60.0)
				{
					fprintf(stderr, "HATA: Gecersiz tarih ve zaman.\n");
					exit(1);
				}
			}
			break;

		case 't':/*--------Senaryo Başlangıcı---------------------------------------*/
			sscanf(opsiyon_argumani, "%d/%d/%d,%d:%d:%lf", &t0.yil, &t0.ay, &t0.gun, &t0.saat, &t0.dakika, &t0.saniye);
			if (t0.yil <= 1980 || t0.ay < 1 || t0.ay>12 || t0.gun < 1 || t0.gun>31 ||
				t0.saat< 0 || t0.saat>23 || t0.dakika< 0 || t0.dakika>59 || t0.saniye < 0.0 || t0.saniye >= 60.0)
			{
				fprintf(stderr, "HATA: Gecersiz tarih ve zaman.\n");
				exit(1);
			}
			t0.saniye = floor(t0.saniye);
			takvim2gps(&t0, &g0);
			break;

		case 'd':/*--------Senaryo Süresi-------------------------------------------*/
			duration = atof(opsiyon_argumani);
			break;

		case 'i':/*--------İyonosferik Gecikme Seçeneği-----------------------------*/
			ionoutc.aktif = FALSE; // Disable ionospheric correction
			break;

		case 'v':/*--------Kanal Ayrıntısı Gösterme---------------------------------*/
			verb = TRUE;
			break;

		case ':':
		case '?':
			printf("%s", talimatlar);
			exit(1);
		default:
			break;
		}
	}
	/*----------------------Girdi Kontrolü-------------------------------------------*/
	if (navfile[0] == 0)
	{
		fprintf(stderr, "HATA: GPS ephemeris dosyasi belirtilmemis.\n");
		exit(1);
	}

	if (umfile[0] == 0 && !statik_konum_modu)
	{
		// Default static location; Tokyo
		statik_konum_modu = TRUE;
		llh[0] = 35.681298 / R2D;
		llh[1] = 139.766247 / R2D;
		llh[2] = 10.0;
	}

	if (duration < 0.0 || (duration > ((double)KULLANICI_HAREKET_BOYUTU) / 10.0 && !statik_konum_modu) || (duration > STATIK_SIMULASYON_SURESI && statik_konum_modu))
	{
		fprintf(stderr, "HATA: Senaryo süresi hatalı.\n");
		exit(1);
	}
	// Süreyi En Yakın Tam Sayıya Yuvarla
	iduration = (int)(duration * 10.0 + 0.5);

	//=================================================================================================================
	// Bölüm-3:		Simülasyon ve Senaryo Parametrelerini İşle
	//=================================================================================================================

	/*----------------------IQ Sinyali Bellek Alanı ve Örnekleme Adımı Hesabı--------------------------*/
	samp_freq = floor(samp_freq / 10.0);//*-----------------------------------------------------------------
	iq_buff_size = (int)samp_freq; // samples per 0.1sec
	samp_freq *= 10.0;

	delt = 1.0 / samp_freq;

	/*----------------------Kullanıcı Konum Verisi Kontrolü-------------------------------------------*/

	if (!statik_konum_modu) 
	{
		// NMEA veya ECEF Kullanıcı Verisi
		if (nmeaGGA == TRUE)
			numd = NmeaGGA_oku(xyz, umfile);
		else
			numd = kullanici_haraketini_oku(xyz, umfile);


		// Hata Kontrolü
		if (numd == -1)
		{
			fprintf(stderr, "HATA: Kullanici hareketi / NMEA GGA dosyasi acilamadi.\n");
			exit(1);
		}
		else if (numd == 0)
		{
			fprintf(stderr, "HATA: Kullanici hareketi / NMEA GGA verisi okunamadi.\n");
			exit(1);
		}

		// Simülasyon Zamanını Kur
		if (numd > iduration)
			numd = iduration;
	}
	else
	{
		fprintf(stderr, "Statik konum modu kullaniliyor.\n");
		numd = iduration; // Sabit Zaman
	}
	
	/*----------------------Uydu Efemerislerini Ayrıştır-------------------------------------------*/
	
	neph = rinex_dosya_okuma(navfile , &ionoutc, efemerisler);
	
	/*for (int i = 0; i < neph; i++) {
		printf("efemeris num %d\n", i + 1);
		printf("------------------------------------------------------\n");
		efemeris_yazdir(&efemerisler[i]);
		printf("------------------------------------------------------\n");
	}*/

	if (neph == 0)
	{
		fprintf(stderr, "HATA: Ephemeris mevcut degil.\n");
		exit(1);
	}
	/*----------------------Kullanıcı Bilgilendirmesi-------------------------------------------*/
	if ((verb == TRUE) && (ionoutc.gecerli_bayrak == TRUE))
	{
		fprintf(stderr, "  %12.3e %12.3e %12.3e %12.3e\n",
			ionoutc.iyon_alfa[0], ionoutc.iyon_alfa[1], ionoutc.iyon_alfa[2], ionoutc.iyon_alfa[3]);
		fprintf(stderr, "  %12.3e %12.3e %12.3e %12.3e\n",
			ionoutc.iyon_beta[0], ionoutc.iyon_beta[1], ionoutc.iyon_beta[2], ionoutc.iyon_beta[3]);
		fprintf(stderr, "   %19.11e %19.11e  %9d %9d\n",
			ionoutc.delta_utc_a[0], ionoutc.delta_utc_a[1], ionoutc.iletim_zamani, ionoutc.iletim_haftasi);
		fprintf(stderr, "%6d\n", ionoutc.delta_ls);
	}

	//=================================================================================================================
	// Bölüm-4:		Senaryo Zaman Parametrelerini İşle
	//=================================================================================================================
	/*----------------------Senaryo Başlangıcını-Bitişini Hesapla---------------------------------------*/
	for (uydu = 0; uydu < MAKSIMUM_UYDU; uydu++)
	{
		if (efemerisler[0][uydu].gecerli_bayrak == 1)
		{
			gmin = efemerisler[0][uydu].gps_zamani;
			tmin = efemerisler[0][uydu].takvim_zamani;
			break;
		}
	}

	gmax.saniye = 0;
	gmax.hafta = 0;
	tmax.saniye = 0;
	tmax.dakika= 0;
	tmax.saat= 0;
	tmax.gun = 0;
	tmax.ay = 0;
	tmax.yil = 0;
	for (uydu = 0; uydu < MAKSIMUM_UYDU; uydu++)
	{
		if (efemerisler[neph - 1][uydu].gecerli_bayrak == 1)
		{
			gmax = efemerisler[neph - 1][uydu].gps_zamani;
			tmax = efemerisler[neph - 1][uydu].takvim_zamani;
			break;
		}
	}
	/*----------------------Senaryo Zaman Kontrolü-------------------------------------------*/
	if (g0.hafta >= 0) // Senaryo başlangıç zamanı ayarlandı mı kontrol et
	{
		if (timeoverwrite == TRUE) // Eğer senaryo zamanı üstüne yazılacaksa
		{
			gps_zamani_t gtmp;
			takvim_zamani_t ttmp;
			double dsec;

			// Başlangıç zamanını en yakın 2 saatlik zaman aralığına yuvarla
			gtmp.hafta = g0.hafta;
			gtmp.saniye = (double)(((int)(g0.saniye)) / 7200) * 7200.0;

			// Başlangıç zamanı ile minimum GPS zamanı arasındaki farkı hesapla
			dsec = gps_zaman_farki_hesapla(gtmp, gmin);

			// UTC referans hafta numarasını güncelle
			ionoutc.iletim_haftasi = gtmp.hafta;
			ionoutc.iletim_zamani = (int)gtmp.saniye;

			// Ephemerislerin TOC ve TOE değerlerini senaryo başlangıç zamanına göre güncelle
			for (uydu = 0; uydu < MAKSIMUM_UYDU; uydu++)
			{
				for (i = 0; i < neph; i++)
				{
					if (efemerisler[i][uydu].gecerli_bayrak == 1) // Ephemeris geçerli mi kontrol et
					{
						// GPS zamanını yeni başlangıç zamanına göre güncelle
						gtmp = gps_zaman_arttir(efemerisler[i][uydu].gps_zamani, dsec);
						gps2zaman(&gtmp, &ttmp);
						efemerisler[i][uydu].gps_zamani = gtmp;
						efemerisler[i][uydu].takvim_zamani = ttmp;

						// Ephemeris zamanını yeni başlangıç zamanına göre güncelle
						gtmp = gps_zaman_arttir(efemerisler[i][uydu].efemeris_zamani, dsec);
						efemerisler[i][uydu].efemeris_zamani = gtmp;
					}
				}
			}
		}
		else // Eğer senaryo başlangıç zamanı belirtilmişse ama üstüne yazılmayacaksa
		{
			// Başlangıç zamanının geçerli aralıkta olup olmadığını kontrol et
			if (gps_zaman_farki_hesapla(g0, gmin) < 0.0 || gps_zaman_farki_hesapla(gmax, g0) < 0.0)
			{
				fprintf(stderr, "HATA: Baslangic zamani gecersiz.\n");
				fprintf(stderr, "tmin = %4d/%02d/%02d,%02d:%02d:%02.0f (%d:%.0f)\n",
					tmin.yil, tmin.ay, tmin.gun, tmin.saat, tmin.dakika, tmin.saniye,
					gmin.hafta, gmin.saniye);
				fprintf(stderr, "tmax = %4d/%02d/%02d,%02d:%02d:%02.0f (%d:%.0f)\n",
					tmax.yil, tmax.ay, tmax.gun, tmax.saat, tmax.dakika, tmax.saniye,
					gmax.hafta, gmax.saniye);
				exit(1); // Geçersiz zaman olduğunda programı sonlandır
			}
		}
	}
	else
	{
		// Eğer senaryo başlangıç zamanı ayarlanmamışsa, varsayılan başlangıç zamanını kullan
		g0 = gmin;
		t0 = tmin;
	}
	fprintf(stderr, "tmin = %4d/%02d/%02d,%02d:%02d:%02.0f (%d:%.0f)\n",
		tmin.yil, tmin.ay, tmin.gun, tmin.saat, tmin.dakika, tmin.saniye,
		gmin.hafta, gmin.saniye);
	fprintf(stderr, "tmax = %4d/%02d/%02d,%02d:%02d:%02.0f (%d:%.0f)\n",
		tmax.yil, tmax.ay, tmax.gun, tmax.saat, tmax.dakika, tmax.saniye,
		gmax.hafta, gmax.saniye);
	/*--------------efemeris güncelleme kontrolü----------------------*/
	/*for (i = 0; i < neph; i++) {
		for (uydu = 0; uydu < MAKSIMUM_UYDU; uydu++)
		{
			printf("\nuydu: %d  ,  neph : %d\n", uydu, neph);
			takvim_zamani_yazdir(&efemerisler[i][neph].takvim_zamani);
			gps_zamani_yazdir(&efemerisler[i][neph].gps_zamani);
		}
	}*/
	/*----------------------Geçerli Uydu Efemeris Kontrolü-------------------------------------------*/

	efemeris_indeksi = -1;

	for (i = 0; i < neph; i++) // Tüm efemeris setleri arasında dolaş
	{
		for (uydu = 0; uydu < MAKSIMUM_UYDU; uydu++) // Her bir uydu için efemeris kontrol et
		{
			// Eğer efemeris geçerli ise işlemlere başla
			if (efemerisler[i][uydu].gecerli_bayrak == 1)
			{
				// Mevcut GPS zamanı ile efemeris zamanı arasındaki farkı hesapla
				dt = gps_zaman_farki_hesapla(g0, efemerisler[i][uydu].gps_zamani);

				// Eğer zaman farkı -3600 saniye ile +3600 saniye arasında ise geçerli efemeris setini bulduk
				if (dt >= -SAATTE_SANIYE && dt < SAATTE_SANIYE)
				{
					efemeris_indeksi = i; // Geçerli efemeris setinin indeksini kaydet
					break; 
				}
			}
		}
		if (efemeris_indeksi >= 0)
			break;
	}

	if (efemeris_indeksi == -1)
	{
		fprintf(stderr, "HATA: Gecerli bir efemeris seti bulunamadi.\n");
		exit(1);
	}


	//=================================================================================================================
	// Bölüm-5:		Sinyal-Dosya Oluştur
	//=================================================================================================================
	/*----------------------IQ Sinyali Veri Yapısını Oluştur-------------------------------------------*/
	// I/Q tampon belleğini (buffer) ayır
	iq_buff = calloc(2 * iq_buff_size, 2); // iq_buff_size boyutunda 16-bit I/Q verisi için bellek ayır

	// Bellek ayırma başarısız olduysa hata mesajı ver ve çık
	if (iq_buff == NULL)
	{
		fprintf(stderr, "HATA: 16-bit I/Q tampon bellegi ayirirken hata olustu.\n");
		exit(1);
	}

	// Veri formatı 8-bit ise
	if (data_format == SC08)
	{
		// 8-bit I/Q tampon belleğini ayır
		iq8_buff = calloc(2 * iq_buff_size, 1);

		// Bellek ayırma başarısız olduysa hata mesajı ver ve çık
		if (iq8_buff == NULL)
		{
			fprintf(stderr, "HATA: 8-bit I/Q tampon bellegi ayirirken hata olustu.\n");
			exit(1);
		}
	}
	// Veri formatı sıkıştırılmış 1-bit ise
	else if (data_format == SC01)
	{
		// Sıkıştırılmış 1-bit I/Q tampon belleğini ayır
		iq8_buff = calloc(iq_buff_size / 4, 1); // Bu formatta veri {I0, Q0, I1, Q1, I2, Q2, I3, Q3} şeklinde düzenlenir

		// Bellek ayırma başarısız olduysa hata mesajı ver ve çık
		if (iq8_buff == NULL)
		{
			fprintf(stderr, "HATA: Sıkıştırılmış 1-bit I/Q tampon bellegi ayirirken hata olustu.\n");
			exit(1);
		}
	}
	/*----------------------Çıktı Dosayasını Oluştur/Kontrol Et-------------------------------------------*/

	// "-" karakteri stdout için dosya ismi olarak kullanılabilir
	if (strcmp("-", outfile)) {
		// Dosya açma başarısız olursa hata mesajı ver ve çık
		if (NULL == (fp = fopen(outfile, "wb")))
		{
			fprintf(stderr, "HATA: Çıktı dosyasını açarken hata oluştu.\n");
			exit(1);
		}
	}
	else {
		fp = stdout; // Dosya adı "-" ise, stdout'a yönlendir
	}


	/*----------------------Uydulara Göre Kanal Ayır-------------------------------------------*/

	// Tum kanallari temizle
	for (i = 0; i < MAKSIMUM_KANAL; i++)
		kanallar[i].prn = 0; // Her kanalin prn degerini 0 yaparak temizleme islemi yapiliyor

	// Uydu tahsis bayragini temizle
	for (uydu = 0; uydu < MAKSIMUM_UYDU; uydu++)
		ayrilmis_uydular[uydu] = -1; // Her uyduya tahsis edilen deger -1 yapilarak temizleniyor

	// Baslangic alici zamani ayarla
	grx = gps_zaman_arttir(g0, 0.0); // Simulasyon baslangic zamani g0'a 0 saniye eklenerek baslangic alici zamani belirleniyor

	// Gorunur uydulari belirleyerek kanallara tahsis ediyor
	kanal_ayir(kanallar, efemerisler[efemeris_indeksi], ionoutc, grx, xyz[0], elvmask); 

	// Tum kanallari goruntule
	for (i = 0; i < MAKSIMUM_KANAL; i++)
	{
		if (kanallar[i].prn > 0) // Kanalda tahsis edilmis bir uydu varsa
		{
			// PRN (uydu kimlik numarası), azimut açısı, yükseklik açısı, mesafe ve iyonosferik gecikmeyi yazdır
			fprintf(stderr, "PRN: %02d, Azimut: %6.1f, Yukseklik: %5.1f, Mesafe: %11.1f, Iyonosferik Gecikme: %5.1f\n",
				kanallar[i].prn,                     // Uydu kimlik numarasi (PRN)
				kanallar[i].azel[0] * R2D,           // Azimut acisi (radyan -> derece)
				kanallar[i].azel[1] * R2D,           // Yukseklik acisi (radyan -> derece)
				kanallar[i].rho0.d,                  // Uydu ile olan mesafe
				kanallar[i].rho0.iono_delay          // Iyonosferik gecikme miktari
			);
		}
	}


	/*----------------------Anten Kazancini Hesapla-------------------------------------------*/

		// Anten kazancını dB cinsinden ant_pat dizisine  aktararak değerleri hesapla.
	for (i = 0; i < 37; i++)
		ant_pat[i] = pow(10.0, -ant_pat_db[i] / 20.0); // Anten kazancını lineer ölçekte hesapla 


	//=================================================================================================================
	// Bölüm-5:		Anabant Sinyalini Oluştur
	//=================================================================================================================

	tstart = clock();

	// Update receiver time
	grx = gps_zaman_arttir(grx, 0.1);

	for (iumd = 1; iumd < numd; iumd++)
	{

		/*----------------------Kanalları Güncelle-------------------------------------------*/
		for (i = 0; i < MAKSIMUM_KANAL; i++)
		{
			if (kanallar[i].prn > 0)
			{
				// Kod fazı ve veri bit sayıcılarını yenile
				range_t rho;
				uydu = kanallar[i].prn - 1;

				// Mevcut pseudorange
				if (!statik_konum_modu)
					mesafe_hesapla(&rho, efemerisler[efemeris_indeksi][uydu], &ionoutc, grx, xyz[iumd]);
				else
					mesafe_hesapla(&rho, efemerisler[efemeris_indeksi][uydu], &ionoutc, grx, xyz[0]);

				kanallar[i].azel[0] = rho.azel[0];
				kanallar[i].azel[1] = rho.azel[1];

				// Kod fazı ve veri bit sayıcılarını güncelle
				kod_fazi_hesapla(&kanallar[i], rho, 0.1);
#ifndef FLOAT_tasiyici_faz
				kanallar[i].tasiyici_faz_adimi = (int)round(512.0 * 65536.0 * kanallar[i].tasiyici_frekansi * delt);
#endif
				// Yol kaybı
				path_loss = 20200000.0 / rho.d;

				// Alıcı anten kazancı
				ibs = (int)((90.0 - rho.azel[1] * R2D) / 5.0); // elevation'ı boresight'e dönüştür
				ant_gain = ant_pat[ibs];

				// Sinyal kazancı
				gain[i] = (int)(path_loss * ant_gain * 128.0); // 2^7 ile ölçeklendi
			}
		}

		/*----------------------IQ Bitlerini Oluştur-------------------------------------------*/
		for (isamp = 0; isamp < iq_buff_size; isamp++) // Her örnek için döngü
		{
			int i_acc = 0; // I bileşeni toplamı
			int q_acc = 0; // Q bileşeni toplamı

			for (i = 0; i < MAKSIMUM_KANAL; i++) // Her kanal için döngü
			{
				if (kanallar[i].prn > 0) // Kanal aktifse
				{
#ifdef FLOAT_tasiyici_faz
					// Taşıyıcı fazı için 512.0 ile ölçeklenmiş tam sayı indeksi hesapla
					iTable = (int)floor(kanallar[i].tasiyici_faz * 512.0);
#else
					// Taşıyıcı fazı için 9-bit indeks hesapla
					iTable = (kanallar[i].tasiyici_faz >> 16) & 0x1ff; // 9-bit index
#endif
					// I ve Q sinyal bileşenlerini hesapla
					ip = kanallar[i].veri_biti * kanallar[i].ca_kodu * cosTable512[iTable] * gain[i];
					qp = kanallar[i].veri_biti * kanallar[i].ca_kodu * sinTable512[iTable] * gain[i];

					// Tüm görünür uydular için toplamları güncelle
					i_acc += ip; // I bileşenini topla
					q_acc += qp; // Q bileşenini topla

					// Kod fazını güncelle
					kanallar[i].kod_fazi += kanallar[i].kod_frekansi * delt;

					if (kanallar[i].kod_fazi >= CA_DIZI_UZUNLUGU) // Kod fazı dizinin uzunluğunu aştıysa
					{
						kanallar[i].kod_fazi -= CA_DIZI_UZUNLUGU; // Fazı sıfırla

						kanallar[i].ilk_kod++; // İlk kodu artır

						if (kanallar[i].ilk_kod >= 20) // 20 C/A kodu 1 navigasyon verisi biti
						{
							kanallar[i].ilk_kod = 0; // İlk kodu sıfırla
							kanallar[i].ilk_bit++; // İlk bit sayısını artır

							if (kanallar[i].ilk_bit >= 30) // 30 navigasyon verisi biti 1 kelime
							{
								kanallar[i].ilk_bit = 0; // İlk biti sıfırla
								kanallar[i].ilk_word++; // İlk kelime sayısını artır
								/*
								if (kanallar[i].ilk_word >= N_DWRD)
									fprintf(stderr, "\nWARNING: Subframe word buffer overflow.\n");
								*/
							}

							// Yeni navigasyon verisi bitini ayarla
							kanallar[i].veri_biti = (int)((kanallar[i].dwrd[kanallar[i].ilk_word] >> (29 - kanallar[i].ilk_bit)) & 0x1UL) * 2 - 1;
						}
					}

					// Mevcut kod chip'ini ayarla
					kanallar[i].ca_kodu = kanallar[i].ca[(int)kanallar[i].kod_fazi] * 2 - 1;

					// Taşıyıcı fazı güncelle
#ifdef FLOAT_tasiyici_faz
					kanallar[i].tasiyici_faz += kanallar[i].f_carr * delt;

					// Taşıyıcı fazının 0 ile 1 arasında kalmasını sağla
					if (kanallar[i].tasiyici_faz >= 1.0)
						kanallar[i].tasiyici_faz -= 1.0;
					else if (kanallar[i].tasiyici_faz < 0.0)
						kanallar[i].tasiyici_faz += 1.0;
#else
					kanallar[i].tasiyici_faz += kanallar[i].tasiyici_faz_adimi; // Taşıyıcı fazı adımını ekle
#endif
				}
			}

			// I/Q toplamlarını 2^7 ile ölçeklendir ve örnek tamponuna kaydet
			i_acc = (i_acc + 64) >> 7; // 2^7 ölçekleme
			q_acc = (q_acc + 64) >> 7; // 2^7 ölçekleme

			// I/Q örneklerini tamponda sakla
			iq_buff[isamp * 2] = (short)i_acc; // I bileşeni
			iq_buff[isamp * 2 + 1] = (short)q_acc; // Q bileşeni
		}


		/*----------------------IQ Verilerini Uygun Formatta Dosyaya Yaz-------------------------------------------*/
		// Veri formatına göre IQ verilerini dosyaya yazma işlemi
		if (data_format == SC01) // SC01 formatı kontrolü
		{
			for (isamp = 0; isamp < 2 * iq_buff_size; isamp++) // Her örnek için döngü
			{
				if (isamp % 8 == 0) // Her 8. örnek için yeni bir bayt başlat
					iq8_buff[isamp / 8] = 0x00; // Baytı sıfırla

				// IQ değerini 1 bit ile temsil et ve ilgili bayta ekle
				iq8_buff[isamp / 8] |= (iq_buff[isamp] > 0 ? 0x01 : 0x00) << (7 - isamp % 8);
			}

			// 8-bit IQ verilerini dosyaya yaz
			fwrite(iq8_buff, 1, iq_buff_size / 4, fp); // Her bayt 4 örnek içerir
		}
		else if (data_format == SC08) // SC08 formatı kontrolü
		{
			for (isamp = 0; isamp < 2 * iq_buff_size; isamp++) // Her örnek için döngü
				iq8_buff[isamp] = iq_buff[isamp] >> 4; 

			// 8-bit IQ verilerini dosyaya yaz
			fwrite(iq8_buff, 1, 2 * iq_buff_size, fp);
		}
		else // SC16 formatı
		{
			// 16-bit IQ verilerini dosyaya yaz
			size_t written_bytes = fwrite(iq_buff, 2, 2 * iq_buff_size, fp); // Her örnek 2 byte (16 bit) içerir = fwrite(iq_buff, 2, 2 * iq_buff_size, fp);
			// printg
		}


		/*----------------------Navigasyon Verilerini 30s'de 1 Güncelle------------------------------------------*/

		// IQ verilerinin saniye cinsinden sayısını hesapla
		igrx = (int)(grx.saniye * 10.0 + 0.5);

		// Her 30 saniyede bir güncelleme yapmak için kontrol et
		if (igrx % 300 == 0) // 300, 30 saniyeye denk gelir
		{
			// Navigasyon mesajını güncelle
			for (i = 0; i < MAKSIMUM_KANAL; i++)
			{
				if (kanallar[i].prn > 0) // Kanal geçerli ise
					navigasyon_mesaji_olustur(grx, &kanallar[i], 0); // Navigasyon mesajını oluştur
			}

			// Ephemeris ve alt çerçeveleri yenile
			// Hızlı ve basit bir çözüm. Daha zarif bir yol bulmalıyız.
			for (uydu = 0; uydu < MAKSIMUM_UYDU; uydu++)
			{
				if (efemerisler[efemeris_indeksi + 1][uydu].gecerli_bayrak == 1) // Geçerli bir ephemeris kontrolü
				{
					// GPS zaman farkını hesapla
					dt = gps_zaman_farki_hesapla(efemerisler[efemeris_indeksi + 1][uydu].gps_zamani, grx);
					if (dt < SAATTE_SANIYE) // 1 saatten azsa
					{
						efemeris_indeksi++; // Ephemeris indeksini güncelle

						for (i = 0; i < MAKSIMUM_KANAL; i++)
						{
							// Atanmışsa yeni alt çerçeveler üret
							if (kanallar[i].prn != 0)
								ephemeris2subframe(efemerisler[efemeris_indeksi][kanallar[i].prn - 1], ionoutc, kanallar[i].subframe);
						}
					}

					break;
				}
			}

			// Kanal tahsisini güncelle
			if (!statik_konum_modu) // Statik konum modu değilse
				kanal_ayir(kanallar, efemerisler[efemeris_indeksi], ionoutc, grx, xyz[iumd], elvmask); // Kanal ayır
			else // Statik konum modu ise
				kanal_ayir(kanallar, efemerisler[efemeris_indeksi], ionoutc, grx, xyz[0], elvmask); // İlk konumu kullanarak kanal ayır

			//// Simüle edilen kanallar hakkında detayları göster
			//if (verb == TRUE) // Verbose mod aktifse
			//{
			//	fprintf(stderr, "\n"); // Yeni bir satır yazdır
			//	yazdir_anlamli_gps_zamani(grx);
			//	for (i = 0; i < MAKSIMUM_KANAL; i++)
			//	{

			//		if (kanallar[i].prn > 0) // Geçerli kanal varsa
			//			fprintf(stderr, "\nPRN: %02d, Azimut: %6.1f, Yukseklik: %5.1f, Mesafe: %11.1f, Iyonosferik Gecikme: %5.1f\n",
			//				kanallar[i].prn,                     // Uydu kimlik numarasi (PRN)
			//				kanallar[i].azel[0] * R2D,           // Azimut acisi (radyan -> derece)
			//				kanallar[i].azel[1] * R2D,           // Yukseklik acisi (radyan -> derece)
			//				kanallar[i].rho0.d,                  // Uydu ile olan mesafe
			//				kanallar[i].rho0.iono_delay          // Iyonosferik gecikme miktari
			//			);
			//	}
			//	
			//}
			fprintf(stderr, "\n"); // Yeni bir satır yazdır
			yazdir_anlamli_gps_zamani(grx);
			for (i = 0; i < MAKSIMUM_KANAL; i++)
			{

				if (kanallar[i].prn > 0) // Geçerli kanal varsa
					fprintf(stderr, "\nPRN: %02d, Azimut: %6.1f, Yukseklik: %5.1f, Mesafe: %11.1f, Iyonosferik Gecikme: %5.1f\n",
						kanallar[i].prn,                     // Uydu kimlik numarasi (PRN)
						kanallar[i].azel[0] * R2D,           // Azimut acisi (radyan -> derece)
						kanallar[i].azel[1] * R2D,           // Yukseklik acisi (radyan -> derece)
						kanallar[i].rho0.d,                  // Uydu ile olan mesafe
						kanallar[i].rho0.iono_delay          // Iyonosferik gecikme miktari
					);
			}
		}


		// Update receiver time
		grx = gps_zaman_arttir(grx, 0.1); // Alıcının zamanını 0.1 saniye arttır //10Hz

		// Update time counter
		fprintf(stderr, "\rGecen Sure = %4.1f", gps_zaman_farki_hesapla(grx, g0)); 
		fflush(stdout); // Çıktının hemen gösterilmesi için tamponu boşalt

	}

	// Zamanı sonlandır
	tend = clock(); // İşlemin sonlandığı zamanı al

	fprintf(stderr, "\nTamam!\n"); // İşlemin tamamlandığını bildir

	// I/Q tamponunu serbest bırak
	free(iq_buff);

	// Dosyayı kapat
	fclose(fp); 

	// İşlem süresini yazdır
	fprintf(stderr, "Islem sure = %.1f [sn]\n", (double)(tend - tstart) / CLOCKS_PER_SEC); // Islem süresini hesapla ve ekrana yazdir
	fprintf(stderr, "Bitti");

	return(0);
}


