// actixCtrl.cpp : Implementation of the CactixCtrl ActiveX Control class.

#include "stdafx.h"
#include "actix.h"
#include "actixCtrl.h"
#include "actixPropPage.h"
#include "MyList.h"
#include "DlgProp.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define dijkstra_msg (WM_USER + 1)
//UINT dijkstra_msg = RegisterWindowMessage(L"dmsg");


IMPLEMENT_DYNCREATE(CactixCtrl, COleControl)



// Message map

BEGIN_MESSAGE_MAP(CactixCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)

//	ON_COMMAND(ID_BUTTON32771, CPathMakerView::OnPropertyBn )
//	ON_WM_ERASEBKGND( )
//	ON_MESSAGE( dijkstra_msg, CPathMakerView::OnDijkstra )
//	ON_WM_SETCURSOR()

ON_WM_LBUTTONDOWN()
ON_WM_LBUTTONUP()
ON_WM_RBUTTONDOWN()
ON_WM_RBUTTONUP()
END_MESSAGE_MAP()



// Dispatch map

BEGIN_DISPATCH_MAP(CactixCtrl, COleControl)
END_DISPATCH_MAP()



// Event map

BEGIN_EVENT_MAP(CactixCtrl, COleControl)

	EVENT_STOCK_MOUSEDOWN()
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
	// TODO: Initialize your control's instance data here
	// GDI+
	ULONG_PTR gdiplusToken; 
	GdiplusStartupInput gdiplusStartupInput; 
	GdiplusStartup(&gdiplusToken, &gdiplusStartupInput, NULL);

	this->m_graph = new CGraph;
	this->m_t_graph = new CGraph;
	//this->m_chain = new CMyList<CCity>;
}



// CactixCtrl::~CactixCtrl - Destructor

CactixCtrl::~CactixCtrl()
{
	// TODO: Cleanup your control's instance data here.
	delete m_graph;
	delete m_t_graph;
	//delete m_chain;
}



// CactixCtrl::OnDraw - Drawing function

void CactixCtrl::OnDraw(
			CDC* pDC, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pDC)
		return;

	// TODO: Replace the following code with your own drawing code.
	//pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	//pdc->Ellipse(rcBounds);

	CRect rc, rc_client;
	HDC hdcMem;
	HBITMAP hbmMem;
	HGDIOBJ hbmOld;
	HBRUSH hbrBkGnd;

	// Get the size of the client rectangle.
	GetClientRect(&rc_client);
	rc = CRect(CPoint(0,0), GetGraph()->GetSize() );
	rc.UnionRect(&rc_client,&rc);
	// Create a compatible DC.
	hdcMem = CreateCompatibleDC(pDC->GetSafeHdc());
	// Create a bitmap big enough for our client rectangle.
	hbmMem = CreateCompatibleBitmap(pDC->GetSafeHdc(),
		rc.right-rc.left,
		rc.bottom-rc.top);
	// Select the bitmap into the off-screen DC.
	hbmOld = SelectObject(hdcMem, hbmMem);

	// Erase the back&gound.
	hbrBkGnd = CreateSolidBrush(GetGraph()->GetProps().bkColor);
	FillRect(hdcMem, &rc, hbrBkGnd);
	DeleteObject(hbrBkGnd);

	// Render the image into the offscreen DC.
	Graphics g(hdcMem);
	g.SetPageUnit(UnitPixel);

					    GetGraph()    ->ShowPipes(&g);
	if (dijkstra_mode)  GetTempGraph()->ShowPipes(&g);

					    GetGraph()    ->ShowLabels(&g);
	if (dijkstra_mode)  GetTempGraph()->ShowLabels(&g);

					    GetGraph()	  ->ShowCities(&g);
	if (dijkstra_mode)	GetTempGraph()->ShowCities(&g);

	GetGraph()->ShowAnchor(&g);
	//pDoc->GetGraph()->ShowChain(&g,pDoc->GetChain());
	
	// Blt the changes to the screen DC.
	BitBlt(pDC->GetSafeHdc(),
		rc.left, rc.top,
		rc.right-rc.left, rc.bottom-rc.top,
		hdcMem,
		0, 0,
		SRCCOPY);
	// Done with off-screen bitmap and DC.
	SelectObject(hdcMem, hbmOld);
	DeleteObject(hbmMem);
	DeleteDC(hdcMem);
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


void CactixCtrl::OnLButtonDown(UINT nFlags,CPoint point)
{
	dijkstra_mode = false;

	if (nFlags&MK_CONTROL)
	{

		double d=0;CString s;
		CGraph * pGraph = GetGraph();
		int R = pGraph->GetProps().radius;
		CCity* cty = pGraph->Nearest(point,d);
		if (d>R) { pGraph->SetAnchor(NULL);RedrawWindow();return; }
		if (pGraph->GetAnchor() == cty)
			{pGraph->SetAnchor(NULL); RedrawWindow(); return;}
		if (pGraph->GetAnchor() == NULL)
			{pGraph->SetAnchor(cty ); RedrawWindow(); return;}
		//	go Dijkstra()
		s.Format(
			L"Find way between \"%s\" and \"%s\" ?",
			pGraph->GetAnchor()->GetName(),
			cty->GetName());

		if (AfxMessageBox(
			s,
			MB_ICONINFORMATION|MB_YESNO) == IDYES)
		{
			dijkstra_mode = true;
			pGraph->Dijkskra(
				pGraph->GetAnchor(),
				cty,
				GetTempGraph(),
				GetSafeHwnd(),
				dijkstra_msg
				);
		}
		pGraph->SetAnchor(NULL);
		RedrawWindow();
	}
	else
	{
		button_down_point = point;
		SetCapture();
	}

	COleControl::OnLButtonDown(nFlags, point);
}

void CactixCtrl::OnLButtonUp(UINT nFlags,CPoint point)
{
	if (GetCapture()!=this) return;
	ReleaseCapture();

	if (nFlags&MK_CONTROL)	return;

	double d = 0; // distance to the nearest city
	CGraph * pGraph = GetGraph();
	int radius = pGraph -> GetProps().radius;
	//point += GetScrollPosition();
	//button_down_point += GetScrollPosition();

	if (point == button_down_point)
	{
//		no dragin' occurs
		CAddCityDlg dlg;
		CCity * cty = pGraph -> Nearest (point, d);
		SetModifiedFlag();
		if (( d <= radius) && (cty!=NULL))
		{// change name
			dlg.m_name = cty->GetName();
			int old_l = dlg.m_name.GetLength();
			if (dlg.DoModal() == IDOK)
			{
				cty->SetName(dlg.m_name);
				RedrawWindow(
					/*CRect(
					cty->coord,
					cty->coord+CPoint(max(dlg.m_name.GetLength(),old_l)*FONT_WIDTH,2*radius)
					)*/);
			}
			else return;
		}
		else
		{
			if (dlg.DoModal() == IDOK)
			{// add city
				pGraph->AddCity(CCity( point,dlg.m_name ));
//				SetScrollSizes(MM_TEXT, pGraph->GetSize());
//				point -= GetScrollPosition();
				RedrawWindow(
/*					CRect(
					point + CPoint(-radius,-radius),
					point + CPoint(dlg.m_name.GetLength()*FONT_WIDTH+radius, 2*radius)
					)*/);
			}
			else return;
		}
	}
	else
	{//	movin the choosen city
		CCity * cty1 = pGraph -> Nearest (button_down_point, d);
		if (( d > radius ) || (cty1==NULL)) return;
		cty1->coord = point;
		pGraph->UpdateSize(cty1);
//		SetScrollSizes(MM_TEXT, pGraph->GetSize());

		RedrawWindow();
	}

	COleControl::OnLButtonUp(nFlags, point);
}
void CactixCtrl::OnRButtonDown(UINT nFlags,CPoint point)
{
	dijkstra_mode = false;

	CGraph* pGraph	= GetGraph();
	double min_r = 0;
//	point += GetScrollPosition();
	CCity* cty1 = pGraph->Nearest(point, min_r);
	if (pGraph->props->radius < min_r) return;
	pGraph->SetAnchor(cty1);
	RedrawWindow();
	SetCapture();

	COleControl::OnRButtonDown(nFlags, point);
}

void CactixCtrl::OnRButtonUp(UINT nFlags,CPoint point)
{
	if (GetCapture()!=this) return;
	ReleaseCapture();
	CGraph* pGraph = GetGraph();
	CCity* anch = pGraph->GetAnchor();	pGraph->SetAnchor(NULL);
	double min_r = 0;
//	point += GetScrollPosition();
	CCity* cty2 = pGraph->Nearest(point, min_r);

	if (anch == NULL) return;
	
	if (anch == cty2)
	{
		RedrawWindow();
		return;
	}
	
	if (pGraph->props->radius < min_r)
	{
		RedrawWindow();
		return;
	}

	CPipDlg dlg;
	if (dlg.DoModal() != IDOK)
	{
		RedrawWindow();
		return;
	}

	pGraph->AddPipe(anch, cty2, dlg.m_cost);
	RedrawWindow();

	COleControl::OnRButtonUp(nFlags, point);
}

