#pragma once
#include "libbladeRF.h"
#include "bladeRF2.h"
#include <stdlib.h>
#include <stdio.h>
#include <inttypes.h>
#include <string.h>
#include <pthread.h>


struct buf_mgmt
{
    int rx_idx;         /* Next sample buffer to RX into. < 0 indicates stop */
    int tx_idx;         /* Next sample buffer to TX from. < 0 indicates stop */
    size_t num_filled;  /* Number of buffers filled with RX data awaiting TX */

    size_t prefill_count;   /* Since the initial set of TX callbacks will look
                               to fill all available transfers, we must
                               ensure that the RX task has prefilled a
                               sufficient number of buffers */

    void** samples;         /* Sample buffers */
    size_t num_buffers;     /* # of sample buffers */

    /* Used to signal the TX thread when a few samplse have been buffered up */
    pthread_cond_t  samples_available;

    pthread_mutex_t lock;
};

struct repeater
{
    struct bladerf* device;

    pthread_t rx_task;
    struct bladerf_stream* rx_stream;

    pthread_t tx_task;
    struct bladerf_stream* tx_stream;

    pthread_mutex_t stderr_lock;

    struct buf_mgmt buf_mgmt;

    int gain_tx;                /**< TX gain */
    int gain_rx;                /**< RX gain */

    struct bladerf_range gain_range_rx;
    struct bladerf_range gain_range_tx;
};

/**
 * Application configuration
 */
struct repeater_config
{
    char* device_str;           /**< Device to use */

    int tx_freq;                /**< TX frequency */
    int rx_freq;                /**< RX frequency */
    int sample_rate;            /**< Sampling rate */
    int bandwidth;              /**< Bandwidth */

    int num_buffers;            /**< Number of buffers to allocate and use */
    int num_transfers;          /**< Number of transfers to allocate and use */
    int samples_per_buffer;     /**< Number of SC16Q11 samples per buffer */


    bladerf_log_level verbosity;    /** Library verbosity */
};
