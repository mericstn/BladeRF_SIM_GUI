/**
 * @file  receiver.c
 * @author: FDC
 * 
 * Created on 6 avril 2020, 18:08
 */

#include "../include/conversion.h"
#include "../include/receiver.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "../include/constants.h"
#include "../include/timeType.h"

receiver_t* receiverINIT(receiver_t* receiver){
    pthread_mutex_init(&receiver->lock, NULL);
    receiver->gal0 = INIT_GALILEOTIME_T;
    receiver->numd=0;
    receiver->tmax=0;
    receiver->type=STATIC;
    receiver->txtime=0;        
         receiver->mt=motionTypeInit();
    
    return receiver;
}

void getPos_n(ecef_t pos, double tx, const motionStr_t* mt) {
	// Eðer sadece bir pozisyon varsa, sabit olarak döner
	if (mt->numd == 1) {
		ecefCp(pos, mt->pList[0]);
		return;
	}

	// Zaman aralýðýný kontrol et
	for (int i = 0; i < mt->numd - 1; i++) {
		double t1 = mt->tList[i];
		double t2 = mt->tList[i + 1];
		if (tx >= t1 && tx <= t2) {
			// Lineer interpolasyon yap
			double alpha = (tx - t1) / (t2 - t1);
			for (int j = 0; j < 3; j++) {
				pos[j] = mt->pList[i][j] + alpha * (mt->pList[i + 1][j] - mt->pList[i][j]);
			}
			return;
		}
	}

	// Eðer tx, tList'in aralýðýnda deðilse, en yakýn deðeri döner
	if (tx < mt->tList[0]) {
		ecefCp(pos, mt->pList[0]);
	}
	else {
		ecefCp(pos, mt->pList[mt->numd - 1]);
	}
}

enum receiverUpdateReturn receiverUpdate(receiver_t* receiver){
    receiver->txtime++;

    if(receiver->tmax>0&&receiver->txtime*DELTA_T>=receiver->tmax){
        return TIME_OVER;
    }


    double tx =receiver->txtime*DELTA_T;
	getPos_n(receiver->currentPosition, tx, receiver->mt);
    printf(" current ppose   x:%f,Y: %f, z:%f tx %lf\n",receiver->currentPosition[0], receiver->currentPosition[1], receiver->currentPosition[2],tx);

    return RECEIVER_UPDATED;
}


galileotime_t getTime(receiver_t receiver){
    double dt = receiver.txtime*DELTA_T;
    double t =receiver.gal0.wn*SECONDS_IN_WEEK+ receiver.gal0.tow + dt;
    galileotime_t time={0,0};
    time.wn=t/SECONDS_IN_WEEK;
    time.tow=t-time.wn*SECONDS_IN_WEEK;
    return time;
}
