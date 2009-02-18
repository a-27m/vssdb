// LabTestDlg.cpp : implementation file
//

#include "stdafx.h"
#include "LabTest.h"
#include "LabTestDlg.h"

#include <math.h>
#define _USE_MATH_DEFINES

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CLabTestDlg dialog




CLabTestDlg::CLabTestDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CLabTestDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CLabTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LABACTIVECTRL1, m_labctrl);
}

BEGIN_MESSAGE_MAP(CLabTestDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDOK, &CLabTestDlg::OnBnClickedOk)
END_MESSAGE_MAP()


// CLabTestDlg message handlers

BOOL CLabTestDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CLabTestDlg::OnPaint()
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
HCURSOR CLabTestDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

float f(float x, float t)
{
	return sin(x/2)*5+20;
}

float mju1(float t)
{
	return 20;
}

float mju2(float t)
{
	return 20;
}

float k = 1;

void CLabTestDlg::OnBnClickedOk()
{
	float x1 = 0;
	float x2 = 2;
	float h = 0.05;

	float t1 = 0;
	float t2 = 0.8;
	float tau = 0.1;

	int T = (t2-t1)/tau;
	int N = (x2-x1)/h;

	// if (T <= 0 blah blah blah

	float ** u = new float*[T];
	for(int i = 0; i< T;i++)
		u[i] = new float[N];

	float xx, tt;
	xx = x1;
	tt = t1;
	for(int t = 0; t < T; t++, tt+=tau)
		for(int n = 0; n < N; n++, xx+=h)
	{
		u[t][n] = f(xx, tt);
	}

	// рассчитываем границы
	float* m1 = new float[T];
	float* m2 = new float[T];

	tt = t1;
	for(int t = 0; t < T; t++)
	{
		m1[t] = mju1(tt);
		m2[t] = mju2(tt);
	}

	this->m_labctrl.Рассчитать(
		x1, x2,  // x
		t1, t2, // t
		u, m1, m2,
		h, tau
		);
	//OnOK();
}
