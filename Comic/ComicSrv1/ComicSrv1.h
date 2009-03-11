// ComicSrv1.h : main header file for the ComicSrv1 DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CComicSrv1App
// See ComicSrv1.cpp for the implementation of this class
//

class CComicSrv1App : public CWinApp
{
public:
	CComicSrv1App();

// Overrides
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
