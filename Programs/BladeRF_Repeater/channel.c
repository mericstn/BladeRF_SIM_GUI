
#include "channel.h"


// todo : printf ler duzeltilecel
void kanal_baslat(struct bladerf* cihaz_st, kanal_t* kanal_st)
{
	printf("Kanal (%s) parametreleri ayarlaniyor.\n", kanal_st->channel_name);

	HATA_KONTROL(
		bladerf_set_sample_rate(cihaz_st, kanal_st->channel_i32, kanal_st->sample_rate_u32, NULL),
		"Kanal ornekleme hizi ayarlanamadi ! "
	);

	HATA_KONTROL(
		bladerf_set_frequency(cihaz_st, kanal_st->channel_i32, kanal_st->frequency_u64),
		"Kanal frekansi ayarlanamadi ! "
	);

	HATA_KONTROL(
		bladerf_set_gain_mode(cihaz_st, kanal_st->channel_i32, BLADERF_GAIN_MGC),
		"Kanal kazanc modu ayarlanamadi ! "
	);

	HATA_KONTROL(
		bladerf_set_gain(cihaz_st, kanal_st->channel_i32, kanal_st->gain_i32),
		"Kanal kazanci ayarlanamadi ! "
	);

	HATA_KONTROL(
		bladerf_set_bandwidth(cihaz_st, kanal_st->channel_i32, kanal_st->bandwidth_u32, 0),
		"Kanal bant genisligi ayarlanamadi ! "
	);


	printf("Kanal (%s) basariyla baslatildi.\n", kanal_st->channel_name);

}

void kanal_bilgi_yazdir(struct bladerf* cihaz_st, kanal_t* kanal_st)
{
	bladerf_sample_rate sample_rate;
	bladerf_frequency	frequency;
	bladerf_gain		gain;
	bladerf_bandwidth	bandwidth;

	HATA_KONTROL(
		bladerf_get_sample_rate(cihaz_st, kanal_st->channel_i32, &sample_rate),
		"Ornekleme hizi alinamadi"
	);
	printf("Kanal: %s - Ornekleme Hizi: %d Hz\n", kanal_st->channel_name, sample_rate);

	HATA_KONTROL(
		bladerf_get_frequency(cihaz_st, kanal_st->channel_i32, &frequency),
		"Frekans alinamadi"
	);
	printf("Kanal: %s - Frekans: %ld Hz\n", kanal_st->channel_name, frequency);

	HATA_KONTROL(
		bladerf_get_gain(cihaz_st, kanal_st->channel_i32, &gain),
		"Kazanc alinamadi"
	);
	printf("Kanal: %s - Kazanc: %d dB\n", kanal_st->channel_name, gain);

	HATA_KONTROL(
		bladerf_get_bandwidth(cihaz_st, kanal_st->channel_i32, &bandwidth),
		"Bant Genisligi alinamadi"
	);
	printf("Kanal: %s - Bant Genisligi: %d Hz\n", kanal_st->channel_name, bandwidth);

}