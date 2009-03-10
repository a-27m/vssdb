// ComicSrv.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ComicSrv.h"


// This is an example of an exported variable
COMICSRV_API int nComicSrv=0;

// This is an example of an exported function.
COMICSRV_API int fnComicSrv(void)
{
	return 42;
}

// This is the constructor of a class that has been exported.
// see ComicSrv.h for the class definition
CComicSrv::CComicSrv()
{
	return;
}
