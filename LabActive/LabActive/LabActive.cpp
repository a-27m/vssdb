// LabActive.cpp : Implementation of CLabActiveApp and DLL registration.

#include "stdafx.h"
#include "LabActive.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CLabActiveApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x692CA497, 0xD0C7, 0x44AA, { 0x82, 0xB7, 0x49, 0x7E, 0x46, 0xB5, 0xFB, 0xF7 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CLabActiveApp::InitInstance - DLL initialization

BOOL CLabActiveApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: Add your own module initialization code here.
	}

	return bInit;
}



// CLabActiveApp::ExitInstance - DLL termination

int CLabActiveApp::ExitInstance()
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
