#pragma once


#ifdef _WIN32
#include <io.h>
#define access _access

#else
#include <unistd.h>
#endif
#define ARRAY_SIZE(n) (sizeof(n) / sizeof(n[0]))
