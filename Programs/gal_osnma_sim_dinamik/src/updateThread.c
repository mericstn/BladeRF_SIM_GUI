
/* 
 * @file   updateThread.c
 * @author: FDC
 * 
 * Created on 24 mai 2020, 16:48
 */

#include "../include/updateThread.h"
#include "../include/signalControl.h"
#include "../include/readTestvectors.h"
/** @brief struct for upDateFame thread argument 
    @todo rm -> use gobal var*/
struct upDateFeameArg_t {
    satList_t* sat; ///< @brief point to main satList_t struct
    satData_t* satData; ///< @brief point to main satData_t struct
    receiver_t* receiver;///< @brief point to main receiver_t struct
};

/**
 * @brief secondary thread main fonction
 * update navigation date, check visible sat and update ephemris
 * @param arg void* to upDateFeameArg_t structur
 * @return NULL
 */
void* upDateFrame(void* arg) {
    struct upDateFeameArg_t *a = (struct upDateFeameArg_t*) arg;
    satList_t* sat = a->sat;
    satData_t* satData = a->satData;
    receiver_t* receiver = a->receiver;
    while (!signalExit()) {


		// printf("sat->updateCmpt %d satData->iodCmpt %d\n",sat->updateCmpt, satData->iodCmpt);
		if (sat->updateCmpt <= 0) {
#if UPDATE_EPH_TIME>0            
			galileotime_t galtime = getTime(*receiver);
			readTestvectToEph(satData->eph, satData->testvectFile, &galtime, &receiver->tmax);
#endif
			// update sat list
			// printf("sat update\n");
			// bakýolacak
			//updateSatList(sat, *satData, receiver, 0);
		}

        for (int isat = 0; isat < sat->n; isat++) {			
            channel_t* chan = sat->list[isat];
            if (chan != NULL) {
                if (chan->eph == NULL) { // chan not initalise
                    initChan(chan, satData, receiver,xyz[0]);
                }
                if (chan->Nframe == NULL) {
                    sat->updateCmpt -= 2;
                    chan->Nframe = genNavData(satData, chan);
                    //chan->Nframe = chan->page[chan->ipage+1];

                }
            }
        }


    }
    return NULL;
}







