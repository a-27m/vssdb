// ComicTestDlg.cpp : implementation file
//

#include "stdafx.h"
#include "ComicTest.h"
#include "ComicTestDlg.h"
#include <initguid.h>
#include "..\ComicSrv1\imath.h"
//#include "MyList.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

IMath* pMath;


// CComicTestDlg dialog


CComicTestDlg::CComicTestDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CComicTestDlg::IDD, pParent)
	, m_x(0)
	, m_y(0)
	, m_x1(0)
	, m_x2(1)
	, m_step((float)0.1)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	pMath = NULL;
}

CComicTestDlg::~CComicTestDlg()
{
	CoUninitialize();
}

void CComicTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST1, m_list);
	DDX_Text(pDX, IDC_EDIT4, m_x);
	DDX_Text(pDX, IDC_EDIT5, m_y);
	DDX_Text(pDX, IDC_EDIT1, m_x1);
	DDX_Text(pDX, IDC_EDIT2, m_x2);
	DDX_Text(pDX, IDC_EDIT3, m_step);
	DDX_Control(pDX, IDC_ANIMATE1, m_pic);
}

BEGIN_MESSAGE_MAP(CComicTestDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDOK, &CComicTestDlg::OnBnClickedOk)
	ON_BN_CLICKED(IDC_BUTTON1, &CComicTestDlg::OnBnClickedButtonSet)
	ON_BN_CLICKED(IDCANCEL, &CComicTestDlg::OnBnClickedCancel)
END_MESSAGE_MAP()


void CComicTestDlg::Cout(LPCTSTR msg)
{
	this->SetWindowTextW(msg);
}

// CComicTestDlg message handlers
BOOL CComicTestDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// COM initialization here
	pMath = NULL;

	Cout(L"Initializing COM");

	if ( FAILED( CoInitialize( NULL )))
	{
		Cout(L"Unable to initialize COM");
		ExitProcess(-1);
	}

   WCHAR* szProgID = L"Math.Component.1";
//   WCHAR  szWideProgID[128];
   CLSID  clsid;

   HRESULT hr = ::CLSIDFromProgID( szProgID, &clsid );
   if ( FAILED( hr ))
   {
      //cout.setf( ios::hex, ios::basefield );
	  Cout(L"Unable to get CLSID from ProgID.");// HR = " << hr << endl;
	  ExitProcess(-1);
   }

   IClassFactory* pCF;
   // Получить фабрику классов для класса Math
   hr = CoGetClassObject( clsid,
                          CLSCTX_INPROC,
                          NULL,
                          IID_IClassFactory,
                          (void**) &pCF );
   if ( FAILED( hr ))
   {
      //cout.setf( ios::hex, ios::basefield );
      Cout(L"Failed to GetClassObject server instance.");// HR = " << hr << endl;
	  ExitProcess(-1);
   }

   // с помощью фабрики классов создать экземпляр
   // компонента и получить интерфейс IUnknown.
   IUnknown* pUnk;
   hr = pCF->CreateInstance( NULL, IID_IUnknown, (void**) &pUnk );

   // Release the class factory
   pCF->Release();

   if ( FAILED( hr ))
   {
      //cout.setf( ios::hex, ios::basefield );
      Cout(L"Failed to create server instance.");// HR = " << hr << endl;
   	  ExitProcess(-1);
   }

   Cout(L"Instance created");

   hr = pUnk->QueryInterface( IID_IMath, (LPVOID*)&pMath );
   pUnk->Release();
   if ( FAILED( hr ))
   {
	   Cout(L"QueryInterface() for IMath failed");
	   ExitProcess(-1);
   }

   l_x = new CMyList<float>();
   l_y = new CMyList<float>();

   return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CComicTestDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CComicTestDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CComicTestDlg::UpdateList()
{
	m_list.ResetContent();

	CString str;
	CMyList<float>::Iterator ix(l_x);
	CMyList<float>::Iterator iy(l_y);
	for(;!ix.EOL && !iy.EOL;)
	{
		str.Format(L"Pt #%.2d: (%.2f, %.2f)",\
			ix.GetOffset()+1,
			ix.GetCurrentValue(),
			iy.GetCurrentValue()
			);

		m_list.AddString(str);

		ix.GoNext();
		iy.GoNext();
	}
}

void CComicTestDlg::OnBnClickedOk()
{
	UpdateData(TRUE); // from controls to variables

	l_x->AddLast(m_x);
	l_y->AddLast(m_y);

	UpdateList();
}

void CComicTestDlg::OnBnClickedButtonSet()
{
	UpdateData(TRUE);

	CDC* pdc = m_pic.GetDC();
	if (!pdc)
		return;
	CRect rcBounds(0,0,0,0);
	m_pic.GetClientRect(&rcBounds);

	int ox = 10;
	int oy = 120;
	float mx = 50;
	float my = 50;
	int N = int((m_x2 - m_x1) / m_step);

	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));

	pdc->MoveTo(ox, oy);pdc->LineTo(int(10*mx + ox), oy);
	pdc->MoveTo(ox, oy);pdc->LineTo(ox, int(-10*my + oy));
	
//	if (xx == NULL) return;

//	int maxy = u[snapshotTimeIndex][0] * (-my) + oy;
//	int miny = u[snapshotTimeIndex][0] * (-my) + oy;

	//pdc->MoveTo(xx[0] * mx + ox, u[snapshotTimeIndex][0] * (-my) + oy);
	pdc->MoveTo(int(m_x1 * mx + ox), int(f(m_x1) * (-my) + oy));
	for(int i = 1; i <= N; i++)
	{
		float x = m_x1 + i*m_step;
		pdc->LineTo(
			int(x * mx + ox),
			int(f(x) * (-my) + oy));
/*
		if (maxy < u[snapshotTimeIndex][i] * (-my) + oy)
			maxy = u[snapshotTimeIndex][i] * (-my) + oy;

		if (miny > u[snapshotTimeIndex][i] * (-my) + oy)
			miny = u[snapshotTimeIndex][i] * (-my) + oy;
*/
	}

/*	int h = rcBounds.Height()/20;
	int oy2 = rcBounds.Height()>>1;

	for(int i = 1; i < N; i++)
	{
		float percent = (u[snapshotTimeIndex][i] * (-my) + oy - miny) / (maxy - miny);
		CPen pen1(0, 1, RGB(int(255-255*percent), 0, int(255*percent)));
		pdc->SelectObject(&pen1);
		pdc->MoveTo(xx[i] * mx + ox, oy2 - h);
		pdc->LineTo(xx[i] * mx + ox, oy2 + h);
	}
*/
}

void CComicTestDlg::OnBnClickedCancel()
{
	if (l_x == NULL) return;
	if (l_y == NULL) return;
	if (l_x->GetCount() == 0) return;
	if (l_y->GetCount() == 0) return;

	int pre = m_list.GetCurSel()-1;
	CMyList<float>::Node* tmp;

	CMyList<float>::Iterator ix(l_x);
	ix.GoNext(pre); // get predcessor
	tmp = ix.GetCurrent()->next;
	ix.GetCurrent()->next = ix.GetCurrent()->next->next;
	delete tmp;

	CMyList<float>::Iterator iy(l_y);
	iy.GoNext(pre); // get predcessor
	tmp = iy.GetCurrent()->next;
	iy.GetCurrent()->next = iy.GetCurrent()->next->next;
	delete tmp;

	this->UpdateList();
}

float CComicTestDlg::f(float x)
{
	float result;

	float* xi = new float[l_x->GetCount()];
	float* yi = new float[l_y->GetCount()];

	CMyList<float>::Iterator ix(l_x);
	for(int i = 0; !ix.EOL; i++)
	{
		xi[i] = ix.GetCurrentValue();
		ix.GoNext();
	}

	CMyList<float>::Iterator iy(l_y);
	for(int i = 0; !iy.EOL; i++)
	{
		yi[i] = iy.GetCurrentValue();
		iy.GoNext();
	}

	pMath->Interpol(l_x->GetCount(), xi, yi, x, &result);
	TRACE("%.5f;%.5f\n", x, result);
	return result;
}