// actixCtrl.cpp : Implementation of the CactixCtrl ActiveX Control class.

#include "stdafx.h"
#include "actix.h"
#include "actixCtrl.h"
#include "actixPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CactixCtrl, COleControl)



// Message map

BEGIN_MESSAGE_MAP(CactixCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// Dispatch map

BEGIN_DISPATCH_MAP(CactixCtrl, COleControl)
END_DISPATCH_MAP()



// Event map

BEGIN_EVENT_MAP(CactixCtrl, COleControl)
END_EVENT_MAP()



// Property pages

// TODO: Add more property pages as needed.  Remember to increase the count!
BEGIN_PROPPAGEIDS(CactixCtrl, 1)
	PROPPAGEID(CactixPropPage::guid)
END_PROPPAGEIDS(CactixCtrl)



// Initialize class factory and guid

IMPLEMENT_OLECREATE_EX(CactixCtrl, "ACTIX.actixCtrl.1",
	0xf8ab0d7, 0xcefb, 0x46b9, 0x99, 0x8, 0xda, 0x7, 0x4f, 0x7a, 0xb1, 0x16)



// Type library ID and version

IMPLEMENT_OLETYPELIB(CactixCtrl, _tlid, _wVerMajor, _wVerMinor)



// Interface IDs

const IID BASED_CODE IID_Dactix =
		{ 0x5F2FDA10, 0xB7FB, 0x4B87, { 0x8B, 0x4F, 0x5C, 0xCE, 0x3D, 0x64, 0xAC, 0xBC } };
const IID BASED_CODE IID_DactixEvents =
		{ 0xD0E40FC3, 0xA24A, 0x4738, { 0xB4, 0xD1, 0xFC, 0xCF, 0x1C, 0x8F, 0x1E, 0xB1 } };



// Control type information

static const DWORD BASED_CODE _dwactixOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CactixCtrl, IDS_ACTIX, _dwactixOleMisc)



// CactixCtrl::CactixCtrlFactory::UpdateRegistry -
// Adds or removes system registry entries for CactixCtrl

BOOL CactixCtrl::CactixCtrlFactory::UpdateRegistry(BOOL bRegister)
{
	// TODO: Verify that your control follows apartment-model threading rules.
	// Refer to MFC TechNote 64 for more information.
	// If your control does not conform to the apartment-model rules, then
	// you must modify the code below, changing the 6th parameter from
	// afxRegApartmentThreading to 0.

	if (bRegister)
		return AfxOleRegisterControlClass(
			AfxGetInstanceHandle(),
			m_clsid,
			m_lpszProgID,
			IDS_ACTIX,
			IDB_ACTIX,
			afxRegApartmentThreading,
			_dwactixOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CactixCtrl::CactixCtrl - Constructor

CactixCtrl::CactixCtrl()
{
	InitializeIIDs(&IID_Dactix, &IID_DactixEvents);
	// TODO: Initialize your control's instance data here.
}



// CactixCtrl::~CactixCtrl - Destructor

CactixCtrl::~CactixCtrl()
{
	// TODO: Cleanup your control's instance data here.
}



// CactixCtrl::OnDraw - Drawing function

void CactixCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: Replace the following code with your own drawing code.
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CactixCtrl::DoPropExchange - Persistence support

void CactixCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Call PX_ functions for each persistent custom property.
}



// CactixCtrl::OnResetState - Reset control to default state

void CactixCtrl::OnResetState()
{
	COleControl::OnResetState();  // Resets defaults found in DoPropExchange

	// TODO: Reset any other control state here.
}



// CactixCtrl message handlers
