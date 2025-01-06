#pragma once

#include <signal.h>
#include <time.h>
#include "parameters.h"
#include "channel.h"
#include <pthread.h>

#define RXTX_ORNEK_UZUNLUGU					(32768)
#define RXTX_TAMPON_BOYUTU					(32768)
#define RXTX_TAMPON_SAYISI					(32)
#define RXTX_VERI_TRANSFER_SAYISI			(16)
#define RXTX_ZAMAN_ASIMI					(1000)
#define RXTX_ORNEK_ALMA_GONDERME_SAYISI		(100000)		



typedef enum 
{
	DURUM_BEKLIYOR,
	DURUM_TAMAMLANDI
} islem_durumu_t;

typedef enum 
{
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
	uint32_t			ornek_alma_gonderme_sayisi_u32;
}rxtx_parametreleri_t;


void mod_rxtx(struct bladerf* cihaz_st, rxtx_parametreleri_t* rxtx_parametreleri_st, kanal_t* tx_kanal_st, kanal_t* rx_kanal_st, program_t* program_st);
void handle_signal(int signal);
