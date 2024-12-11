
/*
 * @file   readTestvectors.c
 * @author fdc
 * 
 * Created on 16.02.2023
 */

/*****************************************************************************
   Include
 *****************************************************************************/
#include "../include/conversion.h"
#include "../include/constants.h"
#include "../include/readTestvectors.h"
#include "../include/galWord.h"
#include <stdint.h>
#include <string.h>
#include <math.h>
#include <stdlib.h>
/*****************************************************************************
   Typedefs and define
 *****************************************************************************/

/*****************************************************************************
   Global variable
 *****************************************************************************/

/*****************************************************************************
   Function declaration
 *****************************************************************************/

/*****************************************************************************
   Function prototypes
 *****************************************************************************/
void testvect_update_ephword( ephemgal_t * eph, int * nsat, const tU8 * navmbin, const tU32 wordtype)
{
	tU8		word_data[SIZEOF_GAL_DATA] = {0};
	tU32 	tU32_two_complements;
	tU16 	tU16_two_complements;
	int 	res;
	int		offsetIn, datalen;

	data_extract ( word_data, navmbin, 0, 2, SIZEOF_GAL_DATA_K*8);
	data_extract ( word_data, navmbin, SIZEOF_GAL_DATA_K*8, SIZEOF_NAV_PAGE_BITS+2, SIZEOF_GAL_DATA_J*8);
						
	switch (wordtype)
	{
		case W1:
			/* Wordtype, IODnav*/
			offsetIn = 16;

			/* t0e len */
			datalen = 14;
			eph->toe.tow = (double)data_extract_tU32(word_data, offsetIn, datalen);
			eph->toe.tow *= GAL_EPH_SCALE_FACTOR_TOE;
//				printf("W%d toe.tow[%d]: %.2f\n",wordtype, satid, eph->toe.tow);
			offsetIn += datalen;

			/* M0 len */
			datalen = 32;
			tU32_two_complements = data_extract_tU32(word_data, offsetIn, datalen);
			eph->m0 = (double)((tS32)tU32_two_complements)*EPH_SCALE_FACTOR_M0*PI;
			offsetIn += datalen;

			/* Eccentricity len */
			datalen = 32;
			eph->ecc = (double)data_extract_tU32(word_data, offsetIn, datalen);
			eph->ecc *= EPH_SCALE_FACTOR_E;
			offsetIn += datalen;

			/* A1/2 len */
			datalen = 32;
			eph->sqrta = (double)data_extract_tU32(word_data, offsetIn, datalen);
			eph->sqrta *= EPH_SCALE_FACTOR_ROOT_A;

			break;

		case W2:

			/*Wordtype */
			offsetIn = 6;

			/* IODnav len */
			datalen = 10;
			eph->iodnav = (int)data_extract_tU32(word_data, offsetIn, datalen);
			offsetIn += datalen;

			/* Omega0 len */
			datalen = 32;
			tU32_two_complements = data_extract_tU32(word_data, offsetIn, datalen);
			eph->omg0 = (double)((tS32)tU32_two_complements)*EPH_SCALE_FACTOR_OMEGA0*PI;
			offsetIn += datalen;

			/* i0 ken*/
			datalen = 32;
			tU32_two_complements = data_extract_tU32(word_data, offsetIn, datalen);
			eph->inc0 = (double)((tS32)tU32_two_complements)*EPH_SCALE_FACTOR_I0*PI;
			offsetIn += datalen;

			/* Argument of perigee len=32 */
			datalen = 32;
			tU32_two_complements = data_extract_tU32(word_data, offsetIn, datalen);
			eph->aop = (double)((tS32)tU32_two_complements)*EPH_SCALE_FACTOR_PERIGEE*PI;
			offsetIn += datalen;

			/* i dot Rate of change of incluation angle */
			datalen = 14;
			res = data_extract_tU32(word_data, offsetIn, datalen);
			res = two_complements(datalen, res);
			eph->idot = (double)res*GPS_EPH_SCALE_FACTOR_IDOT*PI;
			break;

		case W3:
			/*Wordtype, IODnav*/
			offsetIn = 16;

			/* omega dot len*/
			datalen = 24;
			res = data_extract_tU32(word_data, offsetIn, datalen);
			res = two_complements(datalen, res);
			eph->omgdot = (double)res*EPH_SCALE_FACTOR_OMEGA_DOT*PI;
			offsetIn += datalen;

			/* Delta n len*/
			datalen = 16;
			tU16_two_complements = (tU16)data_extract_tU32(word_data, offsetIn, datalen);
			eph->deltan = (double)((tS16)tU16_two_complements)*EPH_SCALE_FACTOR_DELTAN*PI;
			offsetIn += datalen;

			/* Cuc len*/
			datalen = 16;
			tU16_two_complements = (tU16)data_extract_tU32(word_data, offsetIn, datalen);
			eph->cuc = (double)(tS16)tU16_two_complements*EPH_SCALE_FACTOR_CUC;
			offsetIn += datalen;

			/* Cus len*/
			datalen = 16;
			tU16_two_complements = (tU16)data_extract_tU32(word_data, offsetIn, datalen);
			eph->cus = (double)(tS16)tU16_two_complements*EPH_SCALE_FACTOR_CUS;
			offsetIn += datalen;

			/* Crc len*/
			datalen = 16;
			tU16_two_complements = (tU16)data_extract_tU32(word_data, offsetIn, datalen);
			eph->crc = (double)(tS16)tU16_two_complements*EPH_SCALE_FACTOR_CRC;
			offsetIn += datalen;

			/* Crs len*/
			datalen = 16;
			tU16_two_complements = (tU16)data_extract_tU32(word_data, offsetIn, datalen);
			eph->crs = (double)(tS16)tU16_two_complements*EPH_SCALE_FACTOR_CRS;

			break;

		case W4:
			/* Wordtype, IODnav, SVID*/
			offsetIn = 16;

			/* SVID already set */
			datalen=6;
			eph->svId = data_extract_tU32(word_data, offsetIn, datalen);
			eph->svId--; /* @note svId = PRN-1 */
			// printf("W%d svID: %d\n",wordtype, eph->svId);
			offsetIn += datalen;

			/* Cic len*/
			datalen = 16;
			tU16_two_complements = (tU16)data_extract_tU32(word_data, offsetIn, datalen);
			eph->cic = (double)(tS16)tU16_two_complements*EPH_SCALE_FACTOR_CIC;
			offsetIn += datalen;

			/* Cis len*/
			datalen = 16;
			tU16_two_complements = (tU16)data_extract_tU32(word_data, offsetIn, datalen);
			eph->cis = (double)(tS16)tU16_two_complements*EPH_SCALE_FACTOR_CIS;
			offsetIn += datalen;

			/* T0c */
			datalen=14;
			eph->toc.tow = (double)data_extract_tU32(word_data, offsetIn, datalen);
			eph->toc.tow *= GAL_EPH_SCALE_FACTOR_TOC;
//				printf("W%d toc.tow[%d]: %.2f\n",wordtype, satid, eph->toc.tow);
			offsetIn += datalen;

			/* Af0 */
			datalen=31;
			res = data_extract_tU32(word_data, offsetIn, datalen);
			res = two_complements(datalen, res);
			eph->af0 = (double)res*GAL_EPH_SCALE_FACTOR_AF0;
			offsetIn += datalen;

			/* Af1 */
			datalen=21;
			res = data_extract_tU32(word_data, offsetIn, datalen);
			res = two_complements(datalen, res);
			eph->af1 = (double)res*GAL_EPH_SCALE_FACTOR_AF1;
			// printf("W%d af1[%d]: %e\n",wordtype, satid, eph->af1);
			offsetIn += datalen;

			/* Af2 */
			datalen=6;
			res = data_extract_tU32(word_data, offsetIn, datalen);
			res = two_complements(datalen, res);
			eph->af2 = (double)res*GAL_EPH_SCALE_FACTOR_AF2;

			break;

		case W5:
			/* offset BGD */
			offsetIn = 47;

			/* BGD(E1,E5a) E1-E5a Broadcast Group Delay */
			datalen=10;
			res = data_extract_tU32(word_data, offsetIn, datalen);
			res = two_complements(datalen, res);
			eph->bgde5a = (double)res*GAL_EPH_SCALE_FACTOR_BDGE1E5;
			offsetIn += datalen;

			/* BGD(E1,E5b) E1-E5b Broadcast Group Delay */
			datalen=10;
			res = data_extract_tU32(word_data, offsetIn, datalen);
			res = two_complements(datalen, res);
			eph->bgde5b = (double)res*GAL_EPH_SCALE_FACTOR_BDGE1E5;

			if ( verbose)
			{
				offsetIn += datalen;
				datalen=6;
				offsetIn += datalen;
				
				datalen=12;
				res = data_extract_tU32(word_data, offsetIn, datalen);
				printf("WN %d\n",res);
				offsetIn += datalen;
				
				datalen=20;
				res = data_extract_tU32(word_data, offsetIn, datalen);
				printf("TOW %d\n",res);
			}
			
			/* Update the working variables */
			eph->A = pow(eph->sqrta,2);
			eph->n = sqrt(GM_EARTH / pow(eph->A,3)) + eph->deltan;
			eph->sq1e2 = sqrt(1.0 - pow(eph->ecc,2) );
			eph->omgkdot = eph->omgdot - OMEGA_EARTH;
			
			/* Eph sat complete */
			eph->vflg = true;

			*nsat = *nsat + 1;
			break;
	}
}
 
/* Main function: Extract eph data from test vectors file */
/* Main function: Extract eph data from test vectors file */
int readTestvectToEph(ephemgal_t* eph, FILE* fp, galileotime_t* gal, int* tmax)
{
	static int f_initeph = false;
	static int f_inittime = false;
	char str[MAX_CHAR];

	long			fpos_reset;
	static long		fpos = 0;
	tU32 			wordtype;
	tU32			tmp;
	int 			nsat = 0;
	int 			satid;
	int				f_startSub = false;
	galileotime_t 	galtime = { 0 };
	char 			navm[MAX_CHAR] = { 0 };
	tU8				navmbin[SIZEOF_NAV_MSG_TU8] = { 0 };
	double 			tow_end;
	double			delta_time;
	double 			galtime_secs_a;
	double 			galtime_secs_b;

	// Save initial position of the file for later reset
	fpos_reset = ftell(fp);
	fseek(fp, fpos, SEEK_SET);

	// Read lines from the file
	while ((fgets(str, MAX_CHAR, fp) != NULL))
	{
		if (strlen(str) == 0 || str[0] == '\n') continue;  // Skip empty lines

		/* Debug: Print the line to see what is being read */
		// printf("Reading line: %s\n", str);

		/* Extract data from test vectors */
		if (sscanf(str, "%lf,%d,%d,%99s", &galtime.tow, &galtime.wn, &satid, navm) != 4)
		{
			// printf("Error: Invalid data format in line: %s\n", str);
			continue;  // Skip line if data extraction fails
		}

		/* Test valid navm length */
		if (strlen(navm) != SIZEOF_NAV_MSG_CHAR)
		{
			// printf("Invalid navm length: %zu\n", strlen(navm));  // Hatalý length kontrolü
			continue;
		}

		/* Convert to tU8 format */
		chartotU8(navmbin, navm, SIZEOF_NAV_MSG_TU8);

		/* Check if navm starts with the correct page type (0) */
		tmp = data_extract_tU32(navmbin, 0, 2);
		if (tmp != 0)
		{
			// printf("tmp value not zero: %u\n", tmp);  // tmp deðeri kontrolü
			continue;
		}

		/* Extract wordtype */
		wordtype = data_extract_tU32(navmbin, 2, 6);
		// printf("wordtype: %u\n", wordtype);  // wordtype kontrolü

		/* Initialize time for replay */
		if (!f_inittime)
		{
			// Check if start time is set in the 'gal' struct
			if (gal->wn == -1 && gal->tow == -1)
			{
				gal->wn = galtime.wn;
				gal->tow = galtime.tow - 1; // Adjust time as needed for the test vectors
				// printf("Initial time set: wn = %d, tow = %.2f\n", gal->wn, gal->tow);
			}
			else
			{
				// Compare test vector and user start times
				galtime_secs_a = (double)(gal->wn * SECONDS_IN_WEEK) + gal->tow;
				galtime_secs_b = (double)(galtime.wn * SECONDS_IN_WEEK) + galtime.tow - 1;

				if (galtime_secs_a < galtime_secs_b)
				{
					// printf("Read test vector file: Error user start time is lower than test vector start time\n");
					return -1;  // Return error if times don't match
				}
			}
			f_inittime = true;
		}

		// Sync to start of subframe
		if (!f_startSub)
		{
			if (!f_initeph)
			{
				if (wordtype != W2)
				{
					// printf("Skipping line, not W2 wordtype: %u\n", wordtype);  // W2 kontrolü
					continue;
				}
				else
				{
					f_startSub = true;
					// printf("Started subframe sync.\n");
				}
			}
			else
			{
				// Sync condition for W2 wordtype
				if (wordtype == W2 && galtime.tow >= gal->tow)
				{
					f_startSub = true;
					tow_end = galtime.tow + 30;
					// printf("Sync to start of subframe: tow_end = %.2f\n", tow_end);
				}
				else
				{
					// printf("Skipping line, conditions not met for sync.\n");
					continue;
				}
			}
		}

		// Satellite identifier check
		satid--;
		// printf("satid: %d\n", satid);  // satid kontrolü

		// Update ephemeris data for the satellite
		if (!f_initeph)
		{
			// If ephemeris data is complete for this satellite
			if (eph[satid].vflg == true)
			{
				// printf("Satellite %d eph complete\n", satid);
				continue;
			}
		}
		else
		{
			// After initial update, check if time has passed for the current subframe
			if (tow_end <= galtime.tow)
			{
				// Save file position for later processing
				fpos = ftell(fp) - (strlen(str) + 1);
				// printf("Position saved at: %ld\n", fpos);  // Dosya pozisyonu kontrolü
				break;
			}
		}

		// Update ephemeris data with current navigation message
		testvect_update_ephword(&eph[satid], &nsat, navmbin, wordtype);
	endwhile:
		;
	}

	// Final time adjustment after reading
	if (!f_initeph)
	{
		galtime_secs_a = (double)(gal->wn * SECONDS_IN_WEEK) + gal->tow;
		galtime_secs_b = (double)(galtime.wn * SECONDS_IN_WEEK) + galtime.tow;

		delta_time = (int)(galtime_secs_b - galtime_secs_a);

		if (delta_time < 0)
		{
			// printf("Read test vector file: Error user start time is greater than test vector end time\n");
			return -1;  // Return error if the time interval is invalid
		}

		if (*tmax == 0 || *tmax > delta_time)
		{
			*tmax = delta_time;
		}

		f_initeph = true;
	}

	// Reset file pointer to its initial position
	fseek(fp, fpos_reset, SEEK_SET);

	return nsat;
}





void testvect_update_navm( tU8 navm_testvect[MAX_SAT][SIZEOF_NAV_MSG_TU8], FILE* fp, unsigned long tow)
{
	char 			str[MAX_CHAR] = {0};
	int 			satid;
	galileotime_t 	galtime = {0};
	char 			navm[MAX_CHAR] = {0};
	static size_t	str_len = 0;
	static unsigned long tow_prec = 0;
	int				field_count;

	if ( (tow != tow_prec) )
	{
		tow_prec = tow;

		while ( (fgets(str, MAX_CHAR, fp) != NULL) )
		{
			/* Get len of line to go back on previous line */
			str_len = strlen( str);

			/* Extract data from test vectors */
			field_count = sscanf(str, "%lf,%d,%d,%99s", &galtime.tow, &galtime.wn, &satid, navm);

			if ( field_count == 4)
			{

				// DEBUG
				if ( verbose)
				{
					printf("satid %d galtime.tow %f tow %lu str_len %zu: ",satid, galtime.tow, tow, str_len);
					for (int j = 0; j < SIZEOF_NAV_MSG_CHAR; j++)
						printf("%c",navm[j]);
					printf("\n");
				}


				if ( galtime.tow > tow)
				{					
					/* Go back to previous line, with +1 for \n*/
					fseek(fp, ((str_len+1)*-1), SEEK_CUR);
					break;
				}
				chartotU8( navm_testvect[satid-1], navm, SIZEOF_NAV_MSG_TU8);
			}
		}

	}
}
