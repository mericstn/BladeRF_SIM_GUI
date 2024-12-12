
/**
 * @file main.c
 * @brief gal-osnma-sim Main fonction
 *
**/

#include "include/gal-sdr-sim.h"
#include "include/updateThread.h"
#include "include/signalControl.h"
#include <stdlib.h>
#include <time.h>

int main(int argc, char* argv[]) {

	satData_t satData = INIT_SATDATA_T; // Galileo Constellation data
	receiver_t receiver = { 0 };   // receiver status
	outputConf_t outputConf = INIT_OUTPUT_CONF; // output data configuration
	satList_t sat = INIT_CHANLIST_T; // list of active channel

	readOption(argc, argv, &satData, &receiver, &outputConf);


	// init satList
	printf("\nInitialized satellites in view:");

	initSatList(&satData, &receiver, &sat);

	/**
	 * @defgroup upDateThread nav data thread
	 * secondary thread update update navigation data régulary
	 * @see newPage()
	 *
	 */
	creatUpDateFrameThead(&sat, &satData, &receiver);



	printf("Nb Sat in view %i\n", sat.n);


	// Initial reception time
	clock_t tstart = clock(); // system time



	while (!signalExit()) {
		//    while (!signalExit() && (receiver.txtime * DELTA_T < 720)) {
				// Update receiver time
		if (receiverUpdate(&receiver) != RECEIVER_UPDATED) {
			break; // stop programe if receiverUpdate() return erreur
		}
		// update satList
		pthread_mutex_lock(&sat.listLock);
		for (int i = 0; i < sat.n; i++) {
			updateChan(sat.list[i], &receiver);
		}
		pthread_mutex_unlock(&sat.listLock);
		// make sample
		genSampl(outputConf, &sat);
		// print time
		printf("\rTime = %4.1f", receiver.txtime * DELTA_T);
		fflush(stdout);
		//      if(receiver.txtime * DELTA_T == 0.2)
		//      	break;
	}


	clock_t tend = clock();

	//close up date Frame thread
	joinUpDateFrameThead();

	printf("\nDone!\n");

	// Close file
	if (outputConf.fp != NULL)
	{
		fclose(outputConf.fp);
	}

	if (satData.testvectFile != NULL)
	{
		fclose(satData.testvectFile);
	}



	// Process time
	printf("Process time = %.3f[sec]\n", (double)(tend - tstart) / CLOCKS_PER_SEC);

	// Free I/Q buffer
	free(outputConf.iq_buff);

	return (0);
}

