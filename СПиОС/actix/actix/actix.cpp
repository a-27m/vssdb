// actix.cpp : Implementation of CactixApp and DLL registration.

#include "stdafx.h"
#include "actix.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CactixApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xBE2BBEE1, 0xAF50, 0x4AF7, { 0xBF, 0x15, 0xE7, 0x11, 0xAB, 0xD5, 0x77, 0x9F } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CactixApp::InitInstance - DLL initialization

BOOL CactixApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: Add your own module initialization code here.
	}

	return bInit;
}



// CactixApp::ExitInstance - DLL termination

int CactixApp::ExitInstance()
{
	// TODO: Add your own module termination code here.

	return COleControlModule::ExitInstance();
}



// DllRegisterServer - Adds entries to the system registry

STDAPI DllRegisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleRegisterTypeLib(AfxGetInstanceHandle(), _tlid))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(TRUE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}



// DllUnregisterServer - Removes entries from the system registry

STDAPI DllUnregisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleUnregisterTypeLib(_tlid, _wVerMajor, _wVerMinor))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(FALSE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}
