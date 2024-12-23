#pragma once

#include "parameters.h"
#include "channel.h"

/* todo :  rx-tx icin essiz olacak sekilde duzenle*/

#define RXTX_ORNEK_UZUNLUGU					(32768)
#define RXTX_TAMPON_BOYUTU					(32768)
#define RXTX_TAMPON_SAYISI					(32)
#define RXTX_VERI_TRANSFER_SAYISI			(16)
#define RXTX_ZAMAN_ASIMI					(1000)
#define RXTX_ORNEK_ALMA_GONDERME_SAYISI		(100000)		// todo :  0 ise program sonlandirilana kadar  // todo : program suresi boyutu ayari eklenecek


typedef enum {
	DURUM_BEKLIYOR,
	DURUM_TAMAMLANDI
} islem_durumu_t;

typedef enum {
	VERI_YOK,
	VERI_VAR
} veri_durumu_t;


typedef struct
{
	uint16_t			ornek_uzunlugu_u16;
	uint8_t				tampon_sayisi_u8;	
	uint32_t			tampon_boyutu_u32; /* Must be a multiple of 1024 */
	uint8_t				veri_transfer_sayisi_u8;
	uint16_t			zaman_asimi_16t;
	uint32_t			ornek_alma_gonderme_sayisi_u32; // todo : interrupt mod icin 0 
}rxtx_parametreleri_t;



bool do_work(rxtx_parametreleri_t* rxtx_parametreleri_st, int16_t* rx, unsigned int rx_len, bool* have_tx_data, int16_t* tx, unsigned int tx_len); // not : duruma gore bunu kaldir
void mod_rxtx(struct bladerf* cihaz_st, rxtx_parametreleri_t* rxtx_parametreleri_st, kanal_t* tx_kanal_st, kanal_t* rx_kanal_st);
