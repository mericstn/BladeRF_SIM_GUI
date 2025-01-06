#pragma once

#include "libbladeRF.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <windows.h>
#include <assert.h>
#include"bladeRF2.h" 

#define TOPLAM_PARAMETRE_SAYISI    (26)




#define TX_CHANNEL_NAME			  "TX"
#define TX_FREQ			(uint64_t)(1575420000)	//Hz
#define TX_SAMPLE_RATE			  (12000000)	//Hz
#define TX_BANDWIDTH		      (50000000)	//Hz
#define TX_GAIN					  (45)			//Db45
#define TX_TIMEOUT				  (1000)			//ms

#define RX_CHANNEL_NAME			  "RX"
#define RX_FREQ		    (uint64_t)(1575420000)	//Hz
#define RX_SAMPLE_RATE			  (12000000)	//Hz
#define RX_BANDWIDTH			  (50000000)	//Hz
#define RX_GAIN					  (45)			//Db40
#define RX_TIMEOUT			      (1000)			//ms

#define PROG_SURE_SANIYE		  (600)			//sn

#define HATA_KONTROL(fonksiyon, mesaj_u8a) \
    do { \
        uint8_t durum_u8 = (fonksiyon); \
        if (durum_u8 != 0) { \
            printf("Hata: %s -> %s\n", (mesaj_u8a), bladerf_strerror(durum_u8)); \
            exit(EXIT_FAILURE); \
        } \
    } while (0)



typedef enum
{
	TX1 = BLADERF_CHANNEL_TX(0),
	TX2 = BLADERF_CHANNEL_TX(1),
}tx_port_t;

typedef enum
{
	RX1 = BLADERF_CHANNEL_RX(0),
	RX2 = BLADERF_CHANNEL_RX(1),
}rx_port_t;

typedef enum
{
	BIAS_TEE_KAPALI = false,
	BIAS_TEE_AKTIF = true,
} bias_tee_t;

typedef struct
{
	char					channel_name[255];
	bladerf_channel         channel_i32;
	bladerf_sample_rate		sample_rate_u32;
	bladerf_frequency		frequency_u64;
	bladerf_gain		    gain_i32;
	bladerf_bandwidth		bandwidth_u32;
	bias_tee_t				bias_tee_et;
	uint32_t				timeout_u32;

}kanal_t;


typedef enum
{
	BLADERF_V1,
	BLADERF_V2,
}cihaz_versiyon_t;

typedef enum
{
	RX,
	TX,
	RXTX,
}mod_t;


typedef struct
{
	cihaz_versiyon_t cihaz_versiyon_et;
	mod_t			 mod_et;
	uint32_t		 program_sure_saniye_u32; // 0 ise sonsuz
}program_t;


