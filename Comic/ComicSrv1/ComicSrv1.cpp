// ComicSrv1.cpp : Defines the initialization routines for the DLL.
//

#include "stdafx.h"
#include "ComicSrv1.h"
#include "math.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif

const GUID CDECL BASED_CODE _tlid =
		{ 0xC44A188E, 0xBB19, 0x43E9, { 0xA5, 0xE5, 0x6B, 0x9E, 0x31, 0xEB, 0xF2, 0xA1 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;

// DllRegisterServer - Adds entries to the system registry

STDAPI DllRegisterServer(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if (!AfxOleRegisterTypeLib(AfxGetInstanceHandle(), _tlid))
		return SELFREG_E_TYPELIB;

	if (!COleObjectFactory::UpdateRegistryAll())
		return SELFREG_E_CLASS;

	return S_OK;
}


// DllUnregisterServer - Removes entries from the system registry

STDAPI DllUnregisterServer(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if (!AfxOleUnregisterTypeLib(_tlid, _wVerMajor, _wVerMinor))
		return SELFREG_E_TYPELIB;

	if (!COleObjectFactory::UpdateRegistryAll(FALSE))
		return SELFREG_E_CLASS;

	return S_OK;
}


long    g_lObjs = 0;
long    g_lLocks = 0;

// DllGetClassObject - Returns class factory
STDAPI DllGetClassObject( REFCLSID rclsid, REFIID riid, void** ppv )
{
   HRESULT             hr;
   MathClassFactory    *pCF;
   pCF = 0;

   AFX_MANAGE_STATE(AfxGetStaticModuleState());

   // Make sure the CLSID is for our Expression component
   if ( rclsid != CLSID_Math )
      return( E_FAIL );

   pCF = new MathClassFactory;

   if ( pCF == 0 )
      return( E_OUTOFMEMORY );

   hr = pCF->QueryInterface( riid, ppv );

   // Check for failure of QueryInterface
   if ( FAILED( hr ) )
   {
      delete pCF;
      pCF = 0;
   }

   return hr;
}

// DllCanUnloadNow - Allows COM to unload DLL
STDAPI DllCanUnloadNow(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
    if ( g_lObjs || g_lLocks )
       return( S_FALSE );

	return( S_OK );
}
