/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   signalControle.c
 * @author: FDC
 * 
 * Created on 16 février 2020, 10:26
 */

#include "../include/signalControl.h"
#include <stdio.h>
#include <signal.h>
#include <stdbool.h>

static volatile sig_atomic_t do_exit= false;


void quit(){
    do_exit = 1;
}

void sigint_callback_handler(int signum) {
    fprintf(stdout, "Caught signal %d, %i\n", signum,do_exit);
    do_exit = 1;
}

void initInteruptionSignal(){

    signal(SIGINT, &sigint_callback_handler);

}
    



int signalExit (){
    return do_exit;
}


