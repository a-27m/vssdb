// DlgProp.cpp : implementation file
//

#include "stdafx.h"
#include "actix.h"
#include "DlgProp.h"


// CDlgProp dialog

IMPLEMENT_DYNAMIC(CAddCityDlg, CDialog)

CAddCityDlg::CAddCityDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CAddCityDlg::IDD, pParent)
	, m_name(_T("Unnamed"))
{

}

CAddCityDlg::~CAddCityDlg()
{
}

void CAddCityDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDIT1, m_edit);
	DDX_Text(pDX, IDC_EDIT1, m_name);
	DDV_MaxChars(pDX, m_name, 50);
}


BEGIN_MESSAGE_MAP(CAddCityDlg, CDialog)
	ON_BN_CLICKED(IDOK, &CAddCityDlg::OnBnClickedOk)
END_MESSAGE_MAP()


// CDlgProp message handlers

void CAddCityDlg::OnBnClickedOk()
{
	// TODO: Add your control notification handler code here
	OnOK();
}
// DlgProp.cpp : implementation file
//

#include "stdafx.h"
#include "actix.h"
#include "DlgProp.h"


// CPropDlg dialog

IMPLEMENT_DYNAMIC(CPropDlg, CDialog)

CPropDlg::CPropDlg(GRAPHPROPS _props, CWnd* pParent /*=NULL*/)
	: CDialog(CPropDlg::IDD, pParent)
	, m_fnt_name(_T(""))
	, m_r(0)
{
props = _props;
}

CPropDlg::~CPropDlg()
{
}

void CPropDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT1, m_fnt_name);
	DDX_Text(pDX, IDC_EDIT2, m_r);
	DDV_MinMaxInt(pDX, m_r, 1, 200);
}


BEGIN_MESSAGE_MAP(CPropDlg, CDialog)
	ON_BN_CLICKED(IDC_BUTTON1, &CPropDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDOK, &CPropDlg::OnBnClickedOk)
	ON_WM_PAINT( )
	ON_BN_CLICKED(IDC_BUTTON2, &CPropDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON3, &CPropDlg::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON5, &CPropDlg::OnBnClickedButton5)
END_MESSAGE_MAP()


// CPropDlg message handlers

void CPropDlg::OnPaint()
{
#define h	5
#define a	20
#define ax0	15
#define ay0 13
#define LTRB(i)	ax0,ay0+i*(a+h),ax0+a,ay0+i*(a+h)+a

	CDialog::OnPaint();
	CDC* dc = GetDC();

	CBrush* pBr = new CBrush;
	pBr->CreateSolidBrush(props.bkColor);
	dc->SelectObject(pBr);
	dc->FillRect(CRect(LTRB(0)),pBr);
	dc->Rectangle(CRect(LTRB(0)));
	delete pBr;

	pBr = new CBrush;
	pBr->CreateSolidBrush(props.ctyColor);
	dc->SelectObject(pBr);
	dc->FillRect(CRect(LTRB(1)),dc->GetCurrentBrush());
	dc->Rectangle(CRect(LTRB(1)));
	delete pBr;

	pBr = new CBrush;
	pBr->CreateSolidBrush(props.pipeColor);
	dc->SelectObject(pBr);
	dc->FillRect(CRect(LTRB(2)),dc->GetCurrentBrush());
	dc->Rectangle(CRect(LTRB(2)));
	delete pBr;
	
#undef h
#undef a
#undef ax0
#undef ay0
#undef LTRB
}

void CPropDlg::OnBnClickedButton1()
{
	CColorDialog dlg;
	if ( dlg.DoModal() == IDOK )
	{
		props.bkColor = dlg.GetColor();
		RedrawWindow();
	}
}

void CPropDlg::OnBnClickedOk()
{
	UpdateData();
	props.radius = m_r;
	OnOK();
}

void CPropDlg::OnBnClickedButton2()
{
	CColorDialog dlg;
	if ( dlg.DoModal() == IDOK )
	{	props.ctyColor = dlg.GetColor();
		RedrawWindow();
	}
}

void CPropDlg::OnBnClickedButton3()
{
	CColorDialog dlg;
	if ( dlg.DoModal() == IDOK )
	{	props.pipeColor = dlg.GetColor();
		RedrawWindow();
	}
}

void CPropDlg::OnBnClickedButton5()
{
	CFontDialog dlg;
	if (dlg.DoModal()==IDOK)
	{AfxMessageBox(LPCTSTR("Not used yet"));}
	return;
}
// DlgProp.cpp : implementation file
//

#include "stdafx.h"
#include "actix.h"
#include "DlgProp.h"


// CPipDlg dialog

IMPLEMENT_DYNAMIC(CPipDlg, CDialog)

CPipDlg::CPipDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CPipDlg::IDD, pParent)
	, m_cost(0)
{

}

CPipDlg::~CPipDlg()
{
}

void CPipDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT1, m_cost);
	DDV_MinMaxDouble(pDX, m_cost, 0, 999999999);
}


BEGIN_MESSAGE_MAP(CPipDlg, CDialog)
END_MESSAGE_MAP()


// CPipDlg message handlers
