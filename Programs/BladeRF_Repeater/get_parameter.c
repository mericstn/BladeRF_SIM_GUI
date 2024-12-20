
#include "get_parameter.h"



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