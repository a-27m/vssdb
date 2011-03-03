
// parallelDlg.cpp : implementation file
//

#include "stdafx.h"
#include "parallel.h"
#include "parallelDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CParallelDlg dialog


CParallelDlg::CParallelDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CParallelDlg::IDD, pParent)
	, m_Threads(1)
	, m_N(100)
	, m_Eps(1e-5)
	, m_Sum(0)
	, m_Precise(0)
	, m_X(0)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CParallelDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDITThreads, m_Threads);
	DDV_MinMaxInt(pDX, m_Threads, 1, 50000);
	DDX_Text(pDX, IDC_EDITN, m_N);
	DDX_Text(pDX, IDC_EDITN2, m_Eps);
	DDX_Text(pDX, IDC_EDITSum, m_Sum);
	DDX_Text(pDX, IDC_EDITPrecise, m_Precise);
	DDX_Text(pDX, IDC_EDITX, m_X);
	DDV_MinMaxDouble(pDX, m_X, -1, 1);
}

BEGIN_MESSAGE_MAP(CParallelDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDOK, &CParallelDlg::OnBnClickedOk)
END_MESSAGE_MAP()


// CParallelDlg message handlers

BOOL CParallelDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

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

void CParallelDlg::OnPaint()
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
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CParallelDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CParallelDlg::OnBnClickedOk()
{
	UpdateData();

	omp_set_num_threads(m_Threads);

	m_Sum = 0;
	double a = -1;
	
	;

	#pragma omp parallel for 
	for(int i = 1; (UINT)i < m_N; i++)
	{
		a = -a*m_X;
		m_Sum += (i+1)*(i+2)*(i+3)*(i+4)*a;
	}

	m_Sum=1.0- m_Sum/24.0;

	m_Precise = pow(1.0+m_X, -5);

	UpdateData(FALSE);
}
