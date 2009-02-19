// LabActiveCtrl.cpp : Implementation of the CLabActiveCtrl ActiveX Control class.

#include "stdafx.h"
#include "LabActive.h"
#include "LabActiveCtrl.h"
#include "LabActivePropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CLabActiveCtrl, COleControl)



// Message map

BEGIN_MESSAGE_MAP(CLabActiveCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// Dispatch map

BEGIN_DISPATCH_MAP(CLabActiveCtrl, COleControl)
	DISP_FUNCTION_ID(CLabActiveCtrl, "Animate", 14, Animate, VT_EMPTY, VTS_R4)
	DISP_FUNCTION_ID(CLabActiveCtrl, "Рассчитать", 15, Рассчитать, VT_EMPTY, VTS_R4 VTS_R4 VTS_R4 VTS_R4 VTS_UNKNOWN VTS_PR4 VTS_PR4 VTS_R4 VTS_R4)
	DISP_FUNCTION_ID(CLabActiveCtrl, "SetSnapshotIndex", 16, SetSnapshotIndex, VT_EMPTY, VTS_I4)

END_DISPATCH_MAP()



// Event map

BEGIN_EVENT_MAP(CLabActiveCtrl, COleControl)
END_EVENT_MAP()



// Property pages

// TODO: Add more property pages as needed.  Remember to increase the count!
BEGIN_PROPPAGEIDS(CLabActiveCtrl, 1)
PROPPAGEID(CLabActivePropPage::guid)
END_PROPPAGEIDS(CLabActiveCtrl)



// Initialize class factory and guid

IMPLEMENT_OLECREATE_EX(CLabActiveCtrl, "LABACTIVE.LabActiveCtrl.1",
					   0xcf4deaef, 0xf3cd, 0x4e00, 0x94, 0x25, 0x46, 0xce, 0x35, 0xf6, 0xbc, 0xde)



					   // Type library ID and version

					   IMPLEMENT_OLETYPELIB(CLabActiveCtrl, _tlid, _wVerMajor, _wVerMinor)



					   // Interface IDs

					   const IID BASED_CODE IID_DLabActive =
{ 0xCE2537D5, 0x2F5A, 0x4D95, { 0x81, 0x48, 0x0, 0x31, 0x6D, 0x30, 0x2B, 0x6B } };
const IID BASED_CODE IID_DLabActiveEvents =
{ 0x88BFBC5E, 0xD807, 0x42C5, { 0x83, 0x9D, 0x13, 0x11, 0xFB, 0x20, 0x89, 0x74 } };



// Control type information

static const DWORD BASED_CODE _dwLabActiveOleMisc =
OLEMISC_ACTIVATEWHENVISIBLE |
OLEMISC_SETCLIENTSITEFIRST |
OLEMISC_INSIDEOUT |
OLEMISC_CANTLINKINSIDE |
OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CLabActiveCtrl, IDS_LABACTIVE, _dwLabActiveOleMisc)



// CLabActiveCtrl::CLabActiveCtrlFactory::UpdateRegistry -
// Adds or removes system registry entries for CLabActiveCtrl

BOOL CLabActiveCtrl::CLabActiveCtrlFactory::UpdateRegistry(BOOL bRegister)
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
		IDS_LABACTIVE,
		IDB_LABACTIVE,
		afxRegApartmentThreading,
		_dwLabActiveOleMisc,
		_tlid,
		_wVerMajor,
		_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CLabActiveCtrl::CLabActiveCtrl - Constructor

CLabActiveCtrl::CLabActiveCtrl()
{
	InitializeIIDs(&IID_DLabActive, &IID_DLabActiveEvents);
	// TODO: Initialize your control's instance data here.

	xx = NULL;
}



// CLabActiveCtrl::~CLabActiveCtrl - Destructor

CLabActiveCtrl::~CLabActiveCtrl()
{
	// TODO: Cleanup your control's instance data here.
	delete xx;
}


void CLabActiveCtrl::Рассчитать(float x1,
								float x2,
								float t1,
								float t2,
								float** f,// u(x, t1) = f(x, t)
								float* mju1,// u(x1, t) = mju1(t)
								float* mju2,// u(x2, t) = mju1(t)
								float h, float tau)
{
	T = (t2-t1)/tau;
	N = (x2-x1)/h;

	float k = 1;

	// if (T <= 0 blah blah blah

	u = new float*[T];
	for(int i = 0; i< T;i++)
		u[i] = new float[N];
	xx = new float[N];

	// init 1st row (t=0) with f(x)
	for(int n = 0; n < N; n++)
	{
		u[0][n] = f[0][n];
		xx[n] = x1 + h*n;
	}

	// рассчитываем границы
	float tt = t1;
	for(int t = 0; t < T; t++)
	{
		u[t][0] = mju1[t];
		u[t][N-1] = mju2[t];
	}

	for(int t = 1; t < T; )
	{
		for(int n = 1; n < N-1; n++)
		{
			u[t][n] = k*tau / (h*h+k*tau) * (u[t][n-1] - u[t-1][n] + u[t-1][n+1]) +
				h*h / (h*h + k*tau) * u[t-1][n] +
				h*h / (h*h + k*tau) * tau * (f[t-1][n] + f[t][n]) * 0.5;
		}

		if (++t >= T) continue;

		for(int n = N-1 - 1; n > 0; n--)
		{
			u[t][n] = k*tau / (h*h+k*tau) * (u[t][n+1] - u[t-1][n] + u[t-1][n-1]) +
				h*h / (h*h + k*tau) * u[t-1][n] +
				h*h / (h*h + k*tau) * tau * (f[t-1][n] + f[t][n]) * 0.5;
		}

		++t;
	}
	snapshotTimeIndex = 0;
}

// CLabActiveCtrl::OnDraw - Drawing function

void CLabActiveCtrl::OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	int ox = 10;
	int oy = 300;
	float mx = 50;
	float my = 50;

	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));

	pdc->MoveTo(ox, oy);pdc->LineTo(10*mx + ox, oy);
	pdc->MoveTo(ox, oy);pdc->LineTo(ox, -10*my + oy);
	
	if (xx == NULL) return;
	pdc->MoveTo(xx[0] * mx + ox, u[snapshotTimeIndex][0] * (-my) + oy);
	for(int i = 1; i < N; i++)
	{
		pdc->LineTo(
			xx[i] * mx + ox,
			u[snapshotTimeIndex][i] * (-my) + oy);
	}
}



// CLabActiveCtrl::DoPropExchange - Persistence support

void CLabActiveCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Call PX_ functions for each persistent custom property.
}



// CLabActiveCtrl::OnResetState - Reset control to default state

void CLabActiveCtrl::OnResetState()
{
	COleControl::OnResetState();  // Resets defaults found in DoPropExchange

	// TODO: Reset any other control state here.
}



// CLabActiveCtrl message handlers

void CLabActiveCtrl::Animate(float speed)
{

}

void CLabActiveCtrl::SetSnapshotIndex(int index)
{
	snapshotTimeIndex = (index >= T ? T-1 : index);	
}