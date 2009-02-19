// LabTest2Dlg.cpp : implementation file
//

#include "stdafx.h"
#include "LabTest2.h"
#include "LabTest2Dlg.h"

#include <math.h>
#define _USE_MATH_DEFINES

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CLabTest2Dlg dialog




CLabTest2Dlg::CLabTest2Dlg(CWnd* pParent /*=NULL*/)
	: CDialog(CLabTest2Dlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CLabTest2Dlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LABACTIVECTRL1, m_labctct);
}

BEGIN_MESSAGE_MAP(CLabTest2Dlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDOK, &CLabTest2Dlg::OnBnClickedOk)
END_MESSAGE_MAP()


// CLabTest2Dlg message handlers

BOOL CLabTest2Dlg::OnInitDialog()
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

void CLabTest2Dlg::OnPaint()
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
HCURSOR CLabTest2Dlg::OnQueryDragIcon()
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

void CLabTest2Dlg::OnBnClickedOk()
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

	m_labctct.Animate(0);
	//this->m_labctct.Рассчитать(
	//	x1, x2,  // x
	//	t1, t2, // t
	//	u, m1, m2,
	//	h, tau
	//	);
	//OnOK();
}
