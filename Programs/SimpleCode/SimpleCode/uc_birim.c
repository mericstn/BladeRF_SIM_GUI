#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "uc_birim.h"

char* opsiyon_argumani = NULL; // Opsiyon argümaný
int arguman_dizi_indeks = 1;      // Argüman dizisi indeksi
int gecerli_opsiyon = 0;      // Geçerli opsiyon


int komut_getir(int argc, char* const argv[], const char* options) {
	if (arguman_dizi_indeks >= argc) {
		return -1; 
	}

	char* gecerli_arguman = argv[arguman_dizi_indeks];

	if (gecerli_arguman[0] != '-') {
		return -1;
	}

	gecerli_opsiyon = gecerli_arguman[1];

	const char* opsiyon_indeks = strchr(options, gecerli_opsiyon);
	if (opsiyon_indeks == NULL) {
		return '?';
	}

	if (*(opsiyon_indeks + 1) == ':') {
		if (arguman_dizi_indeks + 1 < argc && argv[arguman_dizi_indeks + 1][0] != '-') {
			opsiyon_argumani = argv[++arguman_dizi_indeks];
		}
		else {
			return '?';
		}
	}

	arguman_dizi_indeks++;
	return gecerli_opsiyon; 
}
