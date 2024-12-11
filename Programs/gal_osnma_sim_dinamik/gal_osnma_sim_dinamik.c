
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

	satData_t satData		= INIT_SATDATA_T; // Galileo Constellation data
	receiver_t receiver		= { 0 };   // receiver status
	outputConf_t outputConf = INIT_OUTPUT_CONF; // output data configuration
	satList_t sat; // list of active channel



	readOption(argc, argv, &satData, &receiver, &outputConf); /*////////////////////////////*/


	printf("\nInitialized satellites in view:");
	initSatList(&satData, &receiver, &sat,&xyz[0]);/*////////////////////////////*/

	//void* upDateFrame(void* arg)

	galileotime_t galtime = getTime(receiver);

	readTestvectToEph(satData.eph, satData.testvectFile, &galtime, &receiver.tmax);


	// update sat list
	printf("sat update\n");
	updateSatList(&sat, satData, &receiver, 0,&xyz[0]); /*////////////////////////////*/
	

	for (int isat = 0; isat < sat.n; isat++) {


		channel_t* chan = sat.list[isat];

		if (chan != NULL) {

			if (chan->eph == NULL) { 
				initChan(chan, &satData, &receiver,&xyz[0]);
			}

			if (chan->Nframe == NULL) {
				sat.updateCmpt -= 2;
				chan->Nframe = genNavData(&satData, chan);
		
			}
		}
	}
	
	printf("Nb Sat in view %i\n", sat.n);


	// Initial reception time
	clock_t tstart = clock(); // system time

	for (int iumd = 1; iumd < receiver.numd; iumd++)
	{
		/*while (!signalExit() && (receiver.txtime * DELTA_T < receiver.tmax)) {*/


			for (int i = 0; i < sat.n; i++) {
				updateChan(sat.list[i], &receiver);
			}

			genSampl(outputConf, &sat);

			printf("\rTime = %4.1f", receiver.txtime * DELTA_T);


			for (int isat = 0; isat < sat.n; isat++) {


				if (sat.list[isat] != NULL) {

					if (sat.list[isat]->eph == NULL) {
						printf("-----------------------------------------------------------------------------------------------");
						
						initChan(sat.list[isat], &satData, &receiver, xyz[iumd]);
					}

					if (sat.list[isat]->Nframe == NULL) {
						printf("------****************************************************************---\n");
						sat.updateCmpt -= 2;
						sat.list[isat]->Nframe = genNavData(&satData, sat.list[isat]);

					}
				}
			}

			printf("Nb Sat in view %i\n", sat.n);
			fflush(stdout);
			


			printf(" \n iumd  = %d  \n", iumd);

			if ((int)(receiver.txtime * DELTA_T * 10) % 300 == 0)
			{
				printf("\t eph update\n");
				readTestvectToEph(satData.eph, satData.testvectFile, &galtime, &receiver.tmax);

				if (receiver.type == DYNAMIC)
				{
					updateSatList(&sat, satData, &receiver, 1, xyz[iumd]);

				}
				else
				{
					updateSatList(&sat, satData, &receiver, 0, xyz[0]);
				}
			}

			if (receiver.txtime * DELTA_T == receiver.tmax)
				break;
			receiver.txtime++;
		//}
	}
	

	clock_t tend = clock();


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

