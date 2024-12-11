
/* 
 * @file   fifoBuffer.c
 * 
 * @author: FDC
 * 
 * Created on 19 février 2020, 15:34
 * 
 * @brief @copybrief fifoBuffer.h
 */

#include "../include/fifoBuffer.h"
#include "../include/constants.h"
#include "time.h"
#include <stdlib.h>
#include <stdbool.h>

typedef struct fifo_t fifo_t;
/** @brief "first in, first out" buffer.
 * used for syncronisation beatween genSampl and hackRF transfer
 */
struct fifo_t{
    fifoData_t* buffer; ///<@brief pointer tomemory space
    int maxLength;      ///<@brief size of memory
    volatile int length; ///<@brief memory used
    volatile int origin; ///<@brief indice of head of buffer

};

/// @todo put fifo struct in outputConf_t or hackRF struct
fifo_t fifo;


int bufferHaveSpace(int nsamp){

    
    if ((fifo.maxLength - fifo.length) < nsamp){
        //wait for bufferPull or 1s 
        struct timespec time_to_wait={0,0};
        time_to_wait.tv_sec = time(NULL)+ 1;

    }
    
    int result = (fifo.maxLength - fifo.length )> nsamp;
    

    
    return result;              
}

void bufferPush(int nsamp, fifoData_t inBuffer[]){
    
     while (!bufferHaveSpace(nsamp)); // wait for space      
             

    
    for (int isamp = 0; isamp < nsamp; isamp++) {
        
        
        int iHackrf=(fifo.origin+fifo.length+isamp)%fifo.maxLength;
        fifo.buffer[iHackrf]=inBuffer[isamp];
        
    }
    
    fifo.length=fifo.length+nsamp;

}


void bufferPull(int nBytes, uint8_t buffer[]){
    

    
        while (fifo.length < nBytes) {
#if TEST_HACKRFBUFFER >0
            printf("buffer empty: length %i / nByte %i\n", length, nBytes);
#endif
            struct timespec time_to_wait={0,0};
            time_to_wait.tv_sec = time(NULL)+ 1;  
            
       
            
        }
    
#if TEST_HACKRFBUFFER    
    if (fifo.maxLength < nBytes) {
        printf(" \n buffer size\n%i:\t%i\n", fifo.maxLength, nBytes);
    }
 #endif
        
    for(int i=0; i < nBytes; i++){
        buffer[i]=fifo.buffer[(fifo.origin+i)%fifo.maxLength]>> 4;
    }
    
    
    fifo.origin = (fifo.origin+nBytes)%fifo.maxLength;
    fifo.length -= nBytes;

    
}


void initBuffer(int length){

    
    fifo.length=0;
    fifo.origin=0;
    fifo.maxLength=length;
    fifo.buffer =  malloc(fifo.maxLength*sizeof(fifoData_t));

    
}
