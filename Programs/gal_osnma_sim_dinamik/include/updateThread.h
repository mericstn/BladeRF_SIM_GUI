/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * @file:   updateThread.h

 * @brief secondary thread managment function
 * 
 * 
 * this file containt fonction to manage thread. 
 * @see main thread fonction upDateFrame()
 * @section updateThread_usage usage
 * @pre singnalControl.h
 * 
 * @code
 * // usage:
 *  creatUpDateFrameThead(satList, satData, receiver)
 * while(1){
 *      if(requestUpDate){ // send signal to unlock thread
 *          unlockUpDateFrameThread()
 *      }
 *      if (WaitForUpdate){ // fonction stay block until update completed
 *          waitUpDateFrameThread()
 *      }
 *  }
 * joinUpDateFrameThead()
 * 
 * @endcode         
 * 
 * @author: FDC
 * 
 * Created on 24 mai 2018, 16:48
 */

#ifndef UPDATETHREAD_H
#define UPDATETHREAD_H

#include "satListType.h"
#include "receiver.h"
#include "satDataType.h"


/**
 * @brief creat thread
 * @param sat point to main satList_t struct
 * @param satData point to main satData_t struct
 * @param receiver point to main receiver_t struct
 */



#endif /* UPDATETHREAD_H */
