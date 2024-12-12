/*****************************************************************************
   Include
 *****************************************************************************/
#include  "../include/conversion.h"
#include "../include/gal-sdr-sim.h"
#include "../include/constants.h"
#include "../include/signalControl.h"
#include "../include/PRN_CODE.h"
#include "../include/fifoBuffer.h"
#include "../include/readTestvectors.h"
#include "../include/uc_birim.h"
#include <math.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <time.h>





/*****************************************************************************
   Global variable
 *****************************************************************************/
int verbose = 0;

/* This table was defined in line with our setup:
 * HackRF with 30dB of attenuation
 * and STM Teseo 5 */
float agc_gain_nsat[MAX_SAT] = {
	0,
	3.245,
	3.0425,
	2.84,
	2.6375,
	2.5,
	2.15,
	2,
	1.875,
	1.72,
	1.65,
	1.52,
	1.42,
	1.32,
	1.22,
	1.12
};



/*****************************************************************************
   Function prototypes
 *****************************************************************************/
void usage(void) {
    printf("Specify at least -v <testvector>\n"
            "Usage:\n"
            "  -v <testvector>	Test vector file.\n"
            "  -l <location>    	Lat,Lon,Alt (default. 48.8435155,2.4297700,60).\n"
            "  -o <output>      	I/Q sampling data file (default: osnma.bin).\n"
            "  -s <frequency>   	Sampling frequency [Hz] (default: 2600000).\n"
            "  -b <iq_bits>     	I/Q data format [8/16] (default: 8).\n"

#ifdef HACKRFLINKED
            "  -k               	HackRF transfer.\n"
#endif
            "  -d <duration>   	Scenario duration [s] (default : 0 -> whole scenario duration).\n"
			"  -h			Help.\n\n"
    		"Example:\n"
    		"./gal-osnma-sim -l 48.8435155,2.4297700,60 -t ./tv/configuration_A/13_DEC_2020_GST_09_00_01_fixed.csv -k\n\n"
			"Copyright \u00A9 2023 FDC\n\n");
    return;
}
/*! \brief Read the list of user motions from the input file
 *  \param[out] xyz Output array of ECEF vectors for user motion
 *  \param[[in] filename File name of the text input file
 *  \returns Number of user data motion records read, -1 on error
 */
int readUserMotion(double xyz[KULLANICI_HAREKET_BOYUTU][3], const char* filename)
{
	FILE* fp;
	int numd;
	char str[MAX_CHAR];
	double t, x, y, z;

	if (NULL == (fp = fopen(filename, "rt")))
		return(-1);

	for (numd = 0; numd < KULLANICI_HAREKET_BOYUTU; numd++)
	{
		if (fgets(str, MAX_CHAR, fp) == NULL)
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

void readOption(int argc, char** argv, satData_t* satData, receiver_t* receiver, outputConf_t* outputConf) {

	receiverINIT(receiver);
    ecef_t p0 = {0, 0, 0};
    char testvectPath[MAX_CHAR]  = {0};
    char outfile[MAX_CHAR]		 = {0};
	char umfile[MAX_CHAR]		 = {0}; //**********************
	double xyz[KULLANICI_HAREKET_BOYUTU][3]; //*********************


//    int timeoverwrite = false; // Overwrite the TOC and TOE in the RINEX file
    double llh[3] = {48.8435155,2.4297700,60};
    // Default options
    outputConf->samp_freq = 2.6e6;
    outputConf->format = SC16;
    outputConf->dataType = IQ_dataType;

    if (argc < 3) {
        usage();
        exit(1);
    }
    int result;

    initInteruptionSignal();
    while ((result = komut_getir(argc, argv, "b:l:o:s:u:i:d:hkv:")) != -1) {
        switch (result) {
            case 'v':
				sprintf(testvectPath, "%s",opsiyon_argumani);
				break;
            case 'l':

				sscanf(opsiyon_argumani, "%lf,%lf,%lf", &llh[0], &llh[1], &llh[2]);
				llh[0] = llh[0] / R2D;	// convert to RAD
				llh[1] = llh[1] / R2D;	// convert to RAD
				llh2xyz(llh, p0);		// Convert llh to xyz


				receiver->type = STATIC;
				receiver->mt->numd = 1;
				free(receiver->mt->pList);
				free(receiver->mt->tList);
				receiver->mt->tList = NULL;
				receiver->mt->pList = (ecef_t*)malloc(sizeof(ecef_t));
				ecefCp(receiver->mt->pList[0], p0);

                break;
			case 'u'://****************
				
				strcpy(umfile, opsiyon_argumani);  // Kullanýcý dosya adýný kopyala

				receiver->type = DYNAMIC;							// Hareket tipi dinamik olarak ayarlanýr
				receiver->mt->numd = readUserMotion(xyz, umfile);	// Kullanýcý hareket verilerini oku

				free(receiver->mt->pList);
				free(receiver->mt->tList);
			
				receiver->mt->pList = (ecef_t*)malloc(receiver->mt->numd * sizeof(ecef_t));
				receiver->mt->tList = (double*)malloc(receiver->mt->numd * sizeof(double));

				if (receiver->mt->pList == NULL || receiver->mt->tList == NULL) {
					fprintf(stderr, "Memory allocation failed for motion lists.\n");
					exit(EXIT_FAILURE);
				}

				for (int i = 0; i < receiver->mt->numd; i++) {
					ecefCp(receiver->mt->pList[i], xyz[i]); // Pozisyon kopyala
					receiver->mt->tList[i] = i * DELTA_T;  // Zaman kopyala
				}
				printf("dinamik mod kullaniliyor  !!! \n ");

				break;			
            case 'o':
            	sprintf(outfile, "%s", opsiyon_argumani);
                break;
            case 's':
                outputConf->samp_freq = atof(opsiyon_argumani);
                if (outputConf->samp_freq < 1.0e6) {
                    printf("Invalid sampling frequency.\n");
                    exit(1);
                }
                break;
            case 'b':
                if (atoi(opsiyon_argumani) == 8) outputConf->format = SC08;
                else if (atoi(opsiyon_argumani) == 16) outputConf->format = SC16;
                else {
                    printf("Invalid data format.\n");
                    exit(1);
                }
                break;
            case 'i':
                if (strncmp(opsiyon_argumani, "iq", 2)) {
                    outputConf->dataType = IQ_dataType;
                } else if (strncmp(opsiyon_argumani, "i", 1)) {
                    outputConf->dataType = I_dataType;
                } else {
                    printf("Invalid data format of the output file.\n");
                    exit(1);
                }
                break;

            case 'k': // transpher data to HackRf
#ifdef HACKRFLINKED
                outputConf->hackrf.hackrf_transfer = true;
#else
                printf("Hackrf lib not found\n");
                exit(1);
#endif
                break;
            case 'd':
                receiver->tmax = atof(opsiyon_argumani);
                break;
            case 'V':
				verbose++;
				break;
            case ':':
            case '?':
            case 'h':
                usage();
                exit(1);
            default:
                break;
        }
    }

    /* Test option -v test vectors is set */
    if ( testvectPath[0] != 0)
    {
		satData->testvectFile = fopen(testvectPath ,"r");
		if (satData->testvectFile == NULL)
		{
			printf("Error to open test vectors file\n");
			exit(1);
		}
		else
		{
			printf("Test vector file:\t%s\n",testvectPath);
		}
    }
    else
    {
    	printf("Error testvector file is missing\n");
    	exit(1);
    }

    /* Set receiver position */
    printf("Replay position:\tlat:%lf lon:%lf alt:%.2lf\n", llh[0], llh[1], llh[2]);
   

    receiverUpdate(receiver);
	



	satData->neph = readTestvectToEph(satData->eph, satData->testvectFile, &receiver->gal0, &receiver->tmax);
	for (int i = 0; i < satData->neph; i++)
	{
		ephemgal_t eph = satData->eph[i];
		datetime_t toc_utc, toe_utc;

		/*
		printf("\n--- Ephemeris Data for Satellite ID: %d ---\n", eph.svId);
		printf("Valid Flag (vflg): %d\n", eph.vflg);

		printf("TOC (Time of Clock):\n");
		printf("  Galileo Time: Week: %d, TOW: %.3f seconds\n", eph.toc.wn, eph.toc.tow);


		printf("TOE (Time of Ephemeris):\n");
		printf("  Galileo Time: Week: %d, TOW: %.3f seconds\n", eph.toe.wn, eph.toe.tow);


		printf("IODNav: %d\n", eph.iodnav);
		printf("Delta-N: %.8e radians/sec\n", eph.deltan);
		printf("Cuc: %.8e radians\n", eph.cuc);
		printf("Cus: %.8e radians\n", eph.cus);
		printf("Cic: %.8e radians\n", eph.cic);
		printf("Cis: %.8e radians\n", eph.cis);
		printf("Crc: %.8e meters\n", eph.crc);
		printf("Crs: %.8e meters\n", eph.crs);
		printf("Eccentricity (e): %.8e\n", eph.ecc);
		printf("sqrt(A): %.8e sqrt(m)\n", eph.sqrta);
		printf("Mean Anomaly (m0): %.8e radians\n", eph.m0);
		printf("Longitude of Ascending Node (omg0): %.8e radians\n", eph.omg0);
		printf("Inclination (inc0): %.8e radians\n", eph.inc0);
		printf("Argument of Perigee (aop): %.8e radians\n", eph.aop);
		printf("Omega Dot (omgdot): %.8e radians/sec\n", eph.omgdot);
		printf("Inclination Rate (idot): %.8e radians/sec\n", eph.idot);
		printf("Clock Bias (af0): %.8e sec\n", eph.af0);
		printf("Clock Drift (af1): %.8e sec/sec\n", eph.af1);
		printf("Clock Drift Rate (af2): %.8e sec/sec^2\n", eph.af2);
		printf("BGDE5a: %.8e\n", eph.bgde5a);
		printf("BGDE5b: %.8e\n", eph.bgde5b);
		printf("Semi-major Axis (A): %.8e meters\n", eph.A);
		printf("Mean Motion (n): %.8e radians/sec\n", eph.n);
		printf("sqrt(1-e^2): %.8e\n", eph.sq1e2);
		printf("OmegaKDot: %.8e radians/sec\n", eph.omgkdot);
		printf("------------------------------------------\n");*/
	}
	printf("Galileo start Time:\twn:%4d, tow:%.0f\n %d adet \n", receiver->gal0.wn, receiver->gal0.tow,satData->neph);
	printf("Replay duration:\t%d s\n", receiver->tmax);

    if (satData->neph == -1)
    {
        printf("Error no sat in testvector file.\n");
        exit(1);
    }







    ////////////////////////////////////////////////////////////
    // Baseband signal buffer and output file
    ////////////////////////////////////////////////////////////

    // Buffer size
	outputConf->delt = 1.0 / outputConf->samp_freq;
	outputConf->samp_freq = floor(outputConf->samp_freq / 10.0);
	outputConf->maxSize = (int) outputConf->samp_freq; // Samples per 0.1sec (DELTA_T??)
	outputConf->samp_freq *= 10.0;

    // Allocate I/Q buffer
    if (outputConf->format == SC08) {
        outputConf->iq_buff = calloc(2 * outputConf->maxSize, 2);
    } else {
        outputConf->iq_buff = (short *) calloc(2 * outputConf->maxSize, 2);
    }

    if (outputConf->iq_buff == NULL) {
        printf("Failed to allocate IQ buffer.\n");
        exit(1);
    }

    initBuffer(8 * outputConf->maxSize * sizeof (fifoData_t));

    // Open output file
    if (outfile[0] == 0) {
        printf("Output data not recorded\n");
        outputConf->fp = NULL;
    } else if (NULL == (outputConf->fp = fopen(outfile, "wb"))) {
        printf("Failed to open output file.\n");
        exit(1);
    }
    else
    {
    	printf("Ouput data file:\t%s\n", outfile);
    }

    printf("sample rate = %lf\n", outputConf->samp_freq);

#ifdef HACKRFLINKED
    outputConf->hackrf.sample_rate_hz = outputConf->samp_freq;
#endif

}

void genSampl(const outputConf_t outputConf, struct satList_t* sat) {
    int length = 0;
    tS8 *iqBuff8;

    for (int iSamp = 0; iSamp < outputConf.maxSize; iSamp++) {// buffer is full or end of frame


        int i_acc = 0;
        int q_acc = 0;
        pthread_mutex_lock(&sat->listLock);

        for (int isat = 0; isat < sat->n; isat++) {
            channel_t* chan = sat->list[isat];

			// if ( isat == 2)
			// {
				// printf("ibit %d\n", chan->ibit);
			// }
            if (chan->code_phase >= GAL_SEQ_LEN) { // next bit
                chan->code_phase -= GAL_SEQ_LEN; // code is GAL_SEQ_LEN periodic
                chan->ibit++;

#if TEST_NAN
                if (chan->code_phase!=chan->code_phase){
                    printf("error NAN in -= GAL_SEC_LEN codephase= %f",chan->code_phase);
                    exit(TEST_NAN);
                }
#endif
                if (chan->ibit >= N_SYM_PAGE) { // 250 symbols = 120 navigation data bits + 10 preamble bits = 1 page
                    chan->ibit = 0;
                    chan->ipage++;
                    newPage(chan);
                }
            }


            int cosPh = cosTable512[((int) (511 * chan->carr_phase)) & 511];
            int sinPh = sinTable512[((int) (511 * chan->carr_phase)) & 511];

            // Set current code chip
            int icode = (int) (chan->code_phase * 2);

            int E1B_carr = chan->boccode_E1B[icode];
            int E1C_carr = chan->boccode_E1C[icode];

            int dataBit = (chan->Cframe[chan->ibit]) > 0 ? -1 : 1;
            int secCode = GalSecondaryCode[chan->ibit % GAL_SEC_CODE_LEN] > 0 ? -1 : 1;

            int signal = E1B_carr * dataBit - E1C_carr * secCode;

#if TEST_BIT

            if (signal != 2 && signal != -2 && signal != 0) {
                printf("%i page: %i, bit: %i = %i\n", chan->svId, chan->ipage, chan->ibit, signal);
            }
#endif

            i_acc += signal*cosPh;
            q_acc += signal*sinPh;

            // Update code phase
            chan->code_phase += chan->f_code * outputConf.delt;

            // Update carrier phase

            chan->carr_phase += chan->fDoppler * outputConf.delt;
            chan->carr_phase -= (long) chan->carr_phase; // (carr_phase %1)
            }

        pthread_mutex_unlock(&sat->listLock);
        
		// Store I/Q samples into buffer
		outputConf.iq_buff[length] = (short) (i_acc * agc_gain_nsat[sat->n] );
		outputConf.iq_buff[length + 1] = (short) (q_acc * agc_gain_nsat[sat->n] );
        
		length += 2;
        if (length > 2 * outputConf.maxSize) {
            printf(" error buffer size len:%i / %i\n", length, 2 * outputConf.maxSize);
            exit(24);
        }
    }

    ////////////////////////////////////////////////////////////////////////
    // save sample
    ////////////////////////////////////////////////////////////////////////
    //printf("size :%d length: %d\n", outputConf.maxSize, length);

    if (outputConf.dataType == IQ_dataType) {
        if ((outputConf.format == SC08)) {
        	iqBuff8 = (tS8 *) calloc( length, sizeof(tS8));

            for (int isamp = 0; isamp < length; isamp++) {
                iqBuff8[isamp]=outputConf.iq_buff[isamp]>>4;
						
#if TEST_ADC
                int samp16 = outputConf.iq_buff[isamp];
                int samp8 = outputConf.iq_buff[isamp] >> 4;
                if (samp16 >= (1 << 11) | samp16 < -(1 << 11)) {
                    printf("\n __erreur_16___  ");
                    exit(-1);
                    printf("%5i\t%d", samp16, samp16);
                } else if (samp8 >= (1 << 7) | samp8 < -(1 << 7)) {
                    printf("\n ___erreur_8___ ");
                    (*erreur_ADC) += 1;
                }
#endif //TEST_ADC

            }
#ifdef HACKRFLINKED
            if (outputConf.hackrf.hackrf_transfer) { // transfer data to hackRF
                hackfrPush(length, outputConf.iq_buff);
            }
#endif

        	// write data in file
            if (outputConf.fp != NULL) {
				//Write hackRF format
				fwrite(iqBuff8, 1, length, outputConf.fp);
            }

            free(iqBuff8);

        } else { // If format == SC16
            if (outputConf.fp != NULL) { // write data in file
                
               // if(!fwrite(outputConf.iq_buff, 2, length, outputConf.fp)) quit(); // 12-bit bladeRF
				size_t bytes = fwrite(outputConf.iq_buff, 2, length, outputConf.fp);
				printf(" written bytes %d", bytes);
            }
        }

    } else {
        printf("I_DATA_TYPE\n");
        exit(1);
    }
}
