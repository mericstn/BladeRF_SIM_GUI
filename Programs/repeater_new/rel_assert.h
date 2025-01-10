#pragma once


#ifdef NDEBUG
#define NDEBUG_UNDEF
#endif
#undef NDEBUG
#include <assert.h>
#ifdef NDEBUG_UNDEF
#define NDEBUG
#undef NDEBUG_UNDEF
#endif
