#pragma once


/*---------------------------------------------------Program Sabitleri------------------------------------------------*/
#define MAKSIMUM_KARAKTER (255)												/*! \brief Bir metin dosyasindaki satir icin maksimum uzunluk (RINEX, hareket) */
#define MAKSIMUM_UYDU (32)													/*! \brief RINEX dosyasindaki maksimum uydu sayisi */
#define EPHEMERIS_DIZI_UZUNLUGU (13)										/*! \brief Gunluk GPS yayin ephemeris dosyasi icin maksimum parametre sayisi (brdc) */									   
#define SATIR (8)															/*! \brief RINEX baþlýk satýr sayýsý  */ 
#define KULLANICI_HAREKET_BOYUTU (3000)										/*! \brief Kullanici hareket noktalarinin maksimum sayisi-10Hz'de maksimum */
#define STATIK_SIMULASYON_SURESI (86400)									/*! \brief Statik mod icin maksimum sure */
#define TRUE    (1)
#define FALSE   (0)


/*---------------------------------------------------Sinyal Sabitleri------------------------------------------------*/
#define MAKSIMUM_KANAL (16)													/*! \brief Simule ettigimiz maksimum kanal sayisi */
#define CA_DIZI_UZUNLUGU (1023)												/*! \brief C/A kodu dizisi uzunlugu */
#define N_SBF (5)															/*! \brief Subframe sayisi */
#define N_DWRD_SBF (10)														/*! \brief Her subframe icin kelime sayisi */
#define N_DWRD ((N_SBF+1)*N_DWRD_SBF)										/*! \brief Subframe kelime tampon boyutu*/ 
#define SC01 (1)															/*! \brief 1 bit Ornekleme veri formati */
#define SC08 (8)															/*! \brief 8 bit Ornekleme veri formati */
#define SC16 (16)															/*! \brief 16 bit Ornekleme veri formati */
#define CODE_FREQ (1.023e6)
#define CARR_TO_CODE (1.0/1540.0)



/*---------------------------------------------------Matematiksel Sabitler------------------------------------------------*/
#define DUNYA_YER_CEKIMI_SABITI (3.986005e14)							    /*!< \brief Dünya'nýn yer çekimi sabiti (m^3/s^2) */
#define DUNYA_ACISAL_HIZ (7.2921151467e-5)									/*!< \brief Dünya'nýn açýsal hýzý (radyan/saniye) */
#define PI_SAYISI (3.1415926535898)											/*!< \brief Pi sayýsý */
#define HAFTADA_SANIYE (604800.0)									        /*!< \brief Bir haftada toplam saniye sayýsý. */
#define YARIM_HAFTADA_SANIYE (302400.0)								        /*!< \brief Bir yarým haftada toplam saniye sayýsý. */
#define GUNDE_SANIYE (86400.0)											    /*!< \brief Bir günde toplam saniye sayýsý. */
#define SAATTE_SANIYE (3600.0)										        /*!< \brief Bir saatte toplam saniye sayýsý. */
#define DAKIKADA_SANIYE (60.0)											    /*!< \brief Bir dakikada toplam saniye sayýsý. */
#define WGS84_YARICAP    (6378137.0)											/*!< \brief World Geodetic System-WGS84 modeline göre Dünya'nýn yarýçapý (m)*/
#define WGS84_EKSANTRIKLIK (0.0818191908426)									/*!< \brief World Geodetic System-WGS84 modelinde Dünya'nýn eksantrikliði*/
#define R2D (57.2957795131)												    /*!< \brief Rad2Deg*/
#define LAMBDA_L1 (0.190293672798365)
#define ISIK_HIZI (2.99792458e8)
#define PI (3.1415926535898)

#define POW2_M5  (0.03125)
#define POW2_M19 (1.907348632812500e-6)
#define POW2_M29 (1.862645149230957e-9)
#define POW2_M31 (4.656612873077393e-10)
#define POW2_M33 (1.164153218269348e-10)
#define POW2_M43 (1.136868377216160e-13)
#define POW2_M55 (2.775557561562891e-17)
#define POW2_M50 (8.881784197001252e-016)
#define POW2_M30 (9.313225746154785e-010)
#define POW2_M27 (7.450580596923828e-009)
#define POW2_M24 (5.960464477539063e-008)


/*---------------------------------------------------Program Deðiþkenleri------------------------------------------------*/
char talimatlar[] = "Kullanim: gps-sdr-sim [secenekler]\n"
"Secenekler:\n"
"  -e <gps_nav>     GPS ephemeris verileri icin RINEX navigasyon dosyasi (gerekli)\n"
"  -u <kullanici_hareketi> ECEF x, y, z formatinda kullanici hareket dosyasi (dinamik mod)\n"
"  -g <nmea_gga>    NMEA GGA akisi (dinamik mod)\n"
"  -c <konum>       ECEF X,Y,Z cinsinden (statik mod) ornegin 3967283.15,1022538.18,4872414.48\n"
"  -l <konum>       Enlem,Boylam,Yukseklik (statik mod) ornegin 30.286502,120.032669,100\n"
"  -L <wnslf,dn,dtslf> Kullanici leap gelecekteki olay icin GPS hafta numarasi, gun numarasi, bir sonraki leap saniye ornegin 2347,3,19\n"
"  -t <tarih,saat>  Senaryo baslangic zamani YYYY/MM/DD,hh:mm:ss\n"
"  -T <tarih,saat>  TOC ve TOE'yi senaryo baslangic zamani ile gecersiz kil\n"
"  -d <sure>       Sure [sn] (dinamik mod max: 300, statik mod max: 86400)\n"
"  -o <cikis>      I/Q ornekleme veri dosyasi (varsayilan: gpssim.bin ; stdout icin - kullanin)\n"
"  -s <frekans>    Ornekleme frekansi [Hz] (varsayilan: 2600000)\n"
"  -b <iq_bits>    I/Q veri formati [1/8/16] (varsayilan: 16)\n"
"  -i               Uzay araci senaryosu icin iyonosfer gecikmesini devre disi birak\n"
"  -p [sabit_guc]  Yolda kayiplari devre disi birak ve guc seviyesini sabit tut\n"
"  -v               Simule edilen kanallar hakkinda ayrintilari goster\n";


char rinex_navigasyon_dosya_yolu[MAKSIMUM_KARAKTER];
char kullanici_hareket_dosya_yolu[MAKSIMUM_KARAKTER];
char cikis_dosya_yolu[MAKSIMUM_KARAKTER];
int statik_konum_modu = false;
int nmeaGGA = false;
int zaman_ustune_yaz = false;/*!< \brief RINEX dosyasýndaki TOC ve TOE deðerlerini üzerine yaz */ 

double enlem_boylam_yukseklik[3]; 
double xyz[KULLANICI_HAREKET_BOYUTU][3];
double ornekleme_frekansi;
int veri_formati;
int ayrilmis_uydular[MAKSIMUM_UYDU];


/*! \brief GPS zamanini temsil eden yapi */
typedef struct
{
	int hafta;   /*!< Ocak 1980'den itibaren GPS hafta numarasi */
	double saniye; /*!< GPS haftasi icindeki saniye */
} gps_zamani_t;

/*! \brief UTC zamanini temsil eden yapi */
typedef struct
{
	int yil;      /*!< Takvim yili */
	int ay;      /*!< Takvim ayi */
	int gun;      /*!< Takvim gunu */
	int saat;     /*!< Takvim saati */
	int dakika;     /*!< Takvim dakikalari */
	double saniye; /*!< Takvim saniyeleri */
} takvim_zamani_t;


/*! \brief Tek bir uydunun efemerisini temsil eden yapý */
typedef struct
{
	int gecerli_bayrak;														/*!< vflg: Valid flag – Uydu verisinin gecerli olup olmadigini belirtir. */
	takvim_zamani_t takvim_zamani;										    /*!< t: Time – Uydu verisinin zaman bilgilerini icerir. */
	gps_zamani_t gps_zamani;												/*!< toc: Time of Clock – Uydunun saat zamanini belirtir. */
	gps_zamani_t efemeris_zamani;											/*!< toe: Time of Ephemeris – Uydunun konum bilgilerini icerdigi zaman. */
	int veri_versiyonu_saat;										        /*!< iodc: Issue of Data, Clock – Saat verisinin surum numarasi. */
	int veri_versiyonu_efemeris;											/*!< iode: Issue of Data, Ephemeris – Efemeris verisinin surum numarasi. */
	double delta_n;															/*!< deltan: Delta-N – Uydunun yörüngesindeki degisiklik (Radyan/Saniye). */
	double yorunge_konum_kosinus_duzeltmesi;								/*!< cuc: Correction for UGPS (radians) – Yörüngedeki konum duzeltmesi (cosine correction). */
	double yorunge_konum_sinus_duzeltmesi;									/*!< cus: Correction for UGPS (radians) – Yörüngedeki konum duzeltmesi (sine correction). */
	double egilim_kosinus_duzeltmesi;										/*!< cic: Correction for inclination (radians) – Egilim duzeltmesi (cosine correction). */
	double egilim_sinus_duzeltmesi;											/*!< cis: Correction for inclination (radians) – Egilim duzeltmesi (sine correction). */
	double yorunge_yaricap_kosinus_duzeltmesi;								/*!< crc: Correction for orbit radius (metre) – Yorunge yaricapý duzeltmesi (cosine correction). */
	double yorunge_yaricap_sinus_duzeltmesi;								/*!< crs: Correction for orbit radius (metre) – Yorunge yaricapý duzeltmesi (sine correction). */
	double eksantriklik;													/*!< ecc: Eccentricity – Yörüngenin eksantrikliðini ifade eder. */
	double buyuk_eksen_A_karekok;											/*!< sqrta: Square root of A (m) – Yarý buyuk eksenin karekoku. */
	double ortalama_anomalilik;												/*!< m0: Mean anomaly (radians) – Ortalama anomalilik acisi. */
	double yukselen_dugum_boylami;											/*!< omg0: Longitude of ascending node (radians) – Yukselen dugumun boylamý. */
	double egilim;															/*!< inc0: Inclination (radians) – Yörüngenin egilimini belirtir. */
	double perige_acisi;												    /*!< aop: Argument of perigee – Perige (en yakin nokta) acisi. */
	double yukselen_dugum_degisim_orani;									/*!< omgdot: Rate of right ascension (radians/second) – Yukselen dugumun degisim orani. */
	double egiklik_acisi_degisim_orani;										/*!< idot: Rate of inclination angle (radians/second) – Egiklik acisinin degisim orani. */
	double saat_ofseti;														/*!< af0: Clock offset (seconds) – Uydu saatinin zaman kaymasi. */
	double saat_kaymasi;													/*!< af1: Clock drift (seconds/second) – Saat kaymasi oraný. */
	double saat_hizlanmasi;													/*!< af2: Clock acceleration (seconds/second^2) – Saat hizlanmasi oraný. */
	double grup_gecikmesi;													/*!< tgd: Group delay L2 bias – L2 sinyali icin grup gecikmesi. */
	int uydu_saglik;													    /*!< svhlth: Health status of satellite – Uydunun saglik durumunu gosterir. */
	int L2_sinyal_kodu;														/*!< codeL2: L2 signal code – L2 sinyalinin kodu. */
	// Calisma degiskenleri
	double ortalama_acisal_hiz;											    /*!< n: Mean motion – Uydunun ortalama hareketi (ortalama acisal hiz). */
	double eksantriklik_karekok;											/*!< sq1e2: Square root of (1-e^2) – Eksantrikliðin karekoku. */
	double buyuk_yaricap;													/*!< A: Semi-major axis – Yörüngenin yari buyuk ekseni. */
	double omega_dot;														/*!< omgkdot: Rate of argument of perigee (radians/second) – Perige acisinin degisim orani. */
} efemeris_t;

/*! \brief RINEX navigasyon dosyasýnýn içeriðini temsil eden yapý */
typedef struct {
	int aktif;
	int gecerli_bayrak;														/*!< vflg: Valid flag – Düzeltme verisinin gecerli olup olmadigini belirtir. */
	double iyon_alfa[4];													/*!< ION ALPHA parametreleri (iyonosfer modellemesi için katsayýlar) */
	double iyon_beta[4];												    /*!< ION BETA parametreleri (iyonosfer modellemesi için katsayýlar) */
	double delta_utc_a[2];													/*!< Delta UTC: A0-A1 - UTC ile GPS zamanlarý arasýndaki farkýn ilk düzeltme katsayýsý */ 
	int delta_ls ;															/*!< dtls - Delta Time Leap Seconds - UTC ile GPS zamaný arasýndaki fark (artýk saniye) */
	int iletim_zamani;														/*!< tot - Time of Transmission - UTC düzeltmesinin geçerli olduðu aný belirtir */
	int iletim_haftasi;													    /*!< wnt - Week Number of Transmission - UTC düzeltmesinin geçerli olduðu hafta numarasý (GPS haftasý) */
	int sonraki_delta_ls;													/*!< dtlsf - Future Delta Time Leap Seconds - Bir sonraki artýk saniye düzeltmesinden sonra UTC ile GPS zamaný arasýndaki fark */
	int sonraki_gun;														/*!< dn - Day Number for the next leap second correction - Bir sonraki artýk saniye düzeltmesinin yapýlacaðý gün numarasý */
	int sonraki_hafta;													    /*!< wnlsf - Week Number for the next leap second correction - Bir sonraki artýk saniye düzeltmesinin yapýlacaðý hafta numarasý */
} iyono_utc_t;



typedef struct
{
	gps_zamani_t g;
	double range; // pseudo mesafe
	double rate;
	double d; // geometrik mesafe
	double azel[2];
	double iono_delay;
} range_t;


/*! \brief Bir kanalý temsil eden yapý*/
typedef struct
{
	int prn;																/*!< prn: PRN Numarasý (Pseudo-Random Noise numarasý) */
	int ca[CA_DIZI_UZUNLUGU];												/*!< ca: C/A Dizisi (Code/Acquisition dizisi) */
	double tasiyici_frekansi;												/*!< f_carr: Taþýyýcý frekansý (Taþýyýcý sinyal frekansý) */
	double kod_frekansi;												    /*!< f_code: Kod frekansý (Kod sinyal frekansý) */

#ifdef FLOAT_CARR_PHASE
	double tasiyici_faz; /*!< carr_phase: Taþýyýcý fazý (Taþýyýcý sinyal fazý) */
#else
	unsigned int tasiyici_faz;												/*!< carr_phase: Taþýyýcý fazý (Taþýyýcý sinyal fazý) */
	int tasiyici_faz_adimi;													/*!< carr_phasestep: Taþýyýcý faz adýmý (Taþýyýcý fazýndaki deðiþim) */
#endif

	double kod_fazi;														/*!< code_phase: Kod fazý (C/A kodunun faz bilgisi) */
	gps_zamani_t g0;														/*!< g0: Baþlangýçta GPS zamaný (GPS zaman baþlangýcý) */
	unsigned long subframe[5][N_DWRD_SBF];									/*!< Þu anki subframe (Subframe verileri) */
	unsigned long dwrd[N_DWRD];												/*!< Subframe'in veri kelimeleri (Subframe içerisindeki veri kelimeleri) */

	int ilk_word;														    /*!< iword: Ýlk kelime indeksi (Subframe'deki ilk kelime) */
	int ilk_bit;															/*!< ibit: Ýlk bit indeksi (Subframe'deki ilk bit) */
	int ilk_kod;															/*!< icode: Ýlk kod indeksi (C/A kodundaki ilk kod) */
	int veri_biti;															/*!< dataBit: Þu anki veri biti (Alýnan verinin bit deðeri) */
	int ca_kodu;															/*!< codeCA: Þu anki C/A kodu (Alýnan C/A kodu deðeri) */
	double azel[2];															/*!< azel: Su anki C/A kodu azimut ve elevasyon (C/A kodu için azimut ve elevasyon açýsý) */
	range_t rho0;															/*!< rho0: Su anki C/A kodu mesafe (C/A kodunun mesafe bilgisi) */
} kanal_t;



int sinTable512[] = {
	   2,   5,   8,  11,  14,  17,  20,  23,  26,  29,  32,  35,  38,  41,  44,  47,
	  50,  53,  56,  59,  62,  65,  68,  71,  74,  77,  80,  83,  86,  89,  91,  94,
	  97, 100, 103, 105, 108, 111, 114, 116, 119, 122, 125, 127, 130, 132, 135, 138,
	 140, 143, 145, 148, 150, 153, 155, 157, 160, 162, 164, 167, 169, 171, 173, 176,
	 178, 180, 182, 184, 186, 188, 190, 192, 194, 196, 198, 200, 202, 204, 205, 207,
	 209, 210, 212, 214, 215, 217, 218, 220, 221, 223, 224, 225, 227, 228, 229, 230,
	 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 241, 242, 243, 244, 244, 245,
	 245, 246, 247, 247, 248, 248, 248, 249, 249, 249, 249, 250, 250, 250, 250, 250,
	 250, 250, 250, 250, 250, 249, 249, 249, 249, 248, 248, 248, 247, 247, 246, 245,
	 245, 244, 244, 243, 242, 241, 241, 240, 239, 238, 237, 236, 235, 234, 233, 232,
	 230, 229, 228, 227, 225, 224, 223, 221, 220, 218, 217, 215, 214, 212, 210, 209,
	 207, 205, 204, 202, 200, 198, 196, 194, 192, 190, 188, 186, 184, 182, 180, 178,
	 176, 173, 171, 169, 167, 164, 162, 160, 157, 155, 153, 150, 148, 145, 143, 140,
	 138, 135, 132, 130, 127, 125, 122, 119, 116, 114, 111, 108, 105, 103, 100,  97,
	  94,  91,  89,  86,  83,  80,  77,  74,  71,  68,  65,  62,  59,  56,  53,  50,
	  47,  44,  41,  38,  35,  32,  29,  26,  23,  20,  17,  14,  11,   8,   5,   2,
	  -2,  -5,  -8, -11, -14, -17, -20, -23, -26, -29, -32, -35, -38, -41, -44, -47,
	 -50, -53, -56, -59, -62, -65, -68, -71, -74, -77, -80, -83, -86, -89, -91, -94,
	 -97,-100,-103,-105,-108,-111,-114,-116,-119,-122,-125,-127,-130,-132,-135,-138,
	-140,-143,-145,-148,-150,-153,-155,-157,-160,-162,-164,-167,-169,-171,-173,-176,
	-178,-180,-182,-184,-186,-188,-190,-192,-194,-196,-198,-200,-202,-204,-205,-207,
	-209,-210,-212,-214,-215,-217,-218,-220,-221,-223,-224,-225,-227,-228,-229,-230,
	-232,-233,-234,-235,-236,-237,-238,-239,-240,-241,-241,-242,-243,-244,-244,-245,
	-245,-246,-247,-247,-248,-248,-248,-249,-249,-249,-249,-250,-250,-250,-250,-250,
	-250,-250,-250,-250,-250,-249,-249,-249,-249,-248,-248,-248,-247,-247,-246,-245,
	-245,-244,-244,-243,-242,-241,-241,-240,-239,-238,-237,-236,-235,-234,-233,-232,
	-230,-229,-228,-227,-225,-224,-223,-221,-220,-218,-217,-215,-214,-212,-210,-209,
	-207,-205,-204,-202,-200,-198,-196,-194,-192,-190,-188,-186,-184,-182,-180,-178,
	-176,-173,-171,-169,-167,-164,-162,-160,-157,-155,-153,-150,-148,-145,-143,-140,
	-138,-135,-132,-130,-127,-125,-122,-119,-116,-114,-111,-108,-105,-103,-100, -97,
	 -94, -91, -89, -86, -83, -80, -77, -74, -71, -68, -65, -62, -59, -56, -53, -50,
	 -47, -44, -41, -38, -35, -32, -29, -26, -23, -20, -17, -14, -11,  -8,  -5,  -2
};

int cosTable512[] = {
	 250, 250, 250, 250, 250, 249, 249, 249, 249, 248, 248, 248, 247, 247, 246, 245,
	 245, 244, 244, 243, 242, 241, 241, 240, 239, 238, 237, 236, 235, 234, 233, 232,
	 230, 229, 228, 227, 225, 224, 223, 221, 220, 218, 217, 215, 214, 212, 210, 209,
	 207, 205, 204, 202, 200, 198, 196, 194, 192, 190, 188, 186, 184, 182, 180, 178,
	 176, 173, 171, 169, 167, 164, 162, 160, 157, 155, 153, 150, 148, 145, 143, 140,
	 138, 135, 132, 130, 127, 125, 122, 119, 116, 114, 111, 108, 105, 103, 100,  97,
	  94,  91,  89,  86,  83,  80,  77,  74,  71,  68,  65,  62,  59,  56,  53,  50,
	  47,  44,  41,  38,  35,  32,  29,  26,  23,  20,  17,  14,  11,   8,   5,   2,
	  -2,  -5,  -8, -11, -14, -17, -20, -23, -26, -29, -32, -35, -38, -41, -44, -47,
	 -50, -53, -56, -59, -62, -65, -68, -71, -74, -77, -80, -83, -86, -89, -91, -94,
	 -97,-100,-103,-105,-108,-111,-114,-116,-119,-122,-125,-127,-130,-132,-135,-138,
	-140,-143,-145,-148,-150,-153,-155,-157,-160,-162,-164,-167,-169,-171,-173,-176,
	-178,-180,-182,-184,-186,-188,-190,-192,-194,-196,-198,-200,-202,-204,-205,-207,
	-209,-210,-212,-214,-215,-217,-218,-220,-221,-223,-224,-225,-227,-228,-229,-230,
	-232,-233,-234,-235,-236,-237,-238,-239,-240,-241,-241,-242,-243,-244,-244,-245,
	-245,-246,-247,-247,-248,-248,-248,-249,-249,-249,-249,-250,-250,-250,-250,-250,
	-250,-250,-250,-250,-250,-249,-249,-249,-249,-248,-248,-248,-247,-247,-246,-245,
	-245,-244,-244,-243,-242,-241,-241,-240,-239,-238,-237,-236,-235,-234,-233,-232,
	-230,-229,-228,-227,-225,-224,-223,-221,-220,-218,-217,-215,-214,-212,-210,-209,
	-207,-205,-204,-202,-200,-198,-196,-194,-192,-190,-188,-186,-184,-182,-180,-178,
	-176,-173,-171,-169,-167,-164,-162,-160,-157,-155,-153,-150,-148,-145,-143,-140,
	-138,-135,-132,-130,-127,-125,-122,-119,-116,-114,-111,-108,-105,-103,-100, -97,
	 -94, -91, -89, -86, -83, -80, -77, -74, -71, -68, -65, -62, -59, -56, -53, -50,
	 -47, -44, -41, -38, -35, -32, -29, -26, -23, -20, -17, -14, -11,  -8,  -5,  -2,
	   2,   5,   8,  11,  14,  17,  20,  23,  26,  29,  32,  35,  38,  41,  44,  47,
	  50,  53,  56,  59,  62,  65,  68,  71,  74,  77,  80,  83,  86,  89,  91,  94,
	  97, 100, 103, 105, 108, 111, 114, 116, 119, 122, 125, 127, 130, 132, 135, 138,
	 140, 143, 145, 148, 150, 153, 155, 157, 160, 162, 164, 167, 169, 171, 173, 176,
	 178, 180, 182, 184, 186, 188, 190, 192, 194, 196, 198, 200, 202, 204, 205, 207,
	 209, 210, 212, 214, 215, 217, 218, 220, 221, 223, 224, 225, 227, 228, 229, 230,
	 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 241, 242, 243, 244, 244, 245,
	 245, 246, 247, 247, 248, 248, 248, 249, 249, 249, 249, 250, 250, 250, 250, 250
};

/*! \brief Alici anteninin 0 ile 180 derece arasindaki boresight acisi icin dB cinsinden zayiflama degerleri
 *  \details Bu dizi, 0'dan 180'e kadar olan boresight acisi icin alici antena zayiflamasi degerlerini
 *  5 derece araliklarla tutmaktadir. Her bir eleman, ilgili aci icin zayiflama degerini temsil eder.
 */
double ant_pat_db[37] = {
	 0.00,  0.00,  0.22,  0.44,  0.67,  1.11,  1.56,  2.00,  2.44,  2.89,  3.56,  4.22,
	 4.89,  5.56,  6.22,  6.89,  7.56,  8.22,  8.89,  9.78, 10.67, 11.56, 12.44, 13.33,
	14.44, 15.56, 16.67, 17.78, 18.89, 20.00, 21.33, 22.67, 24.00, 25.56, 27.33, 29.33,
	31.56
};