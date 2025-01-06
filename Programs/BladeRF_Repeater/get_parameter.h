#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "parameters.h"
#include "mod_rxtx.h"
#include "mod_tx.h"
#include "channel.h"

void kullanim_talimati(const char* program_adi);
int  satir_ayristir(const char* satir, char* parametre, char* deger);
void parametre_oku_csv(FILE* dosya, rxtx_parametreleri_t* rxtx_parametreleri_st, tx_parametreleri_t* tx_parametreleri_st, kanal_t* tx_kanal_st, kanal_t* rx_kanal_st, program_t* program_st,uint16_t* parametre_sayisi_u16);
