// PiChat.h : main header file for the PiChat application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CPiChatApp:
// See PiChat.cpp for the implementation of this class
//

class CPiChatApp : public CWinApp
{
public:
	CPiChatApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CPiChatApp theApp;