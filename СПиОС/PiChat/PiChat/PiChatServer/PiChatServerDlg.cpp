
// PiChatServerDlg.cpp : implementation file
//

#include "stdafx.h"
#include "PiChatServer.h"
#include "PiChatServerDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define BUFSIZE 1024

UINT ClientThread( LPVOID pParam );
UINT ServerMainThread( LPVOID pParam );

enum MessageType
{
	mtLogin = 1, mtLogout,	mtQuery, 
};

struct SMessageHeader
{
	MessageType type;
	UINT lenght;
	UINT toWhom; // for messages, 0 means broadcast
};
struct ThParam 
{
	HANDLE h;
	CPiSrvDlg* pisrv; 
};

UINT ServerMainThread( LPVOID pParam )
{
	ThParam* tp = (ThParam*) pParam;

	while(1)
	{
		HANDLE newPipe = CreateNamedPipe( 
			L"\\\\.\\pipe\\chatpipe",
			PIPE_ACCESS_DUPLEX,       // read/write access 
			PIPE_TYPE_MESSAGE |       // message type pipe 
			PIPE_READMODE_MESSAGE |   // message-read mode 
			PIPE_WAIT,                // blocking mode 
			PIPE_UNLIMITED_INSTANCES, // max. instances  
			BUFSIZE,                  // output buffer size 
			BUFSIZE,                  // input buffer size 
			0,                        // client time-out 
			NULL);                    // default security attribute 

		// if (HANDLE == INVALID_HANDLE_VALUE) ...
		//Sleep(10000);
		//while ();

		tp->pisrv->pText = new CString(L"Pipe created. Waiting for clients...");
		tp->pisrv->UpdateWindow();

		if (ConnectNamedPipe(newPipe, NULL))
		{
			ThParam* tp2 = new ThParam();
			tp2->pisrv = tp->pisrv;

			HANDLE hCurrentProcess = GetCurrentProcess();
			DuplicateHandle(hCurrentProcess, newPipe,
				hCurrentProcess, &(tp2->h),	0, TRUE, DUPLICATE_SAME_ACCESS);

			tp->pisrv->pText = new CString(L"New client is connected, starting his worker thread...");
			tp->pisrv->UpdateWindow();
			AfxBeginThread(&ClientThread,  (LPVOID)tp2);
		}
	}
}

UINT ClientThread( LPVOID pParam )
{
	ThParam* tp = (ThParam*) pParam;

	HANDLE hPipe = tp->h;

	wchar_t buffer[BUFSIZE];
	DWORD len = 0;

	while(1)
	{
		if (ReadFile(hPipe, &buffer, BUFSIZE, &len, NULL))
		{
			CString msg;
			msg.Format(L"New message: %s", (wchar_t*)buffer);
			tp->pisrv->pText = new CString(msg);
			tp->pisrv->RedrawWindow();
		}
	}
}


// CPiSrvDlg dialog

CPiSrvDlg::CPiSrvDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CPiSrvDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	pText = NULL;
}

void CPiSrvDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST2, m_log);
	DDX_Control(pDX, IDC_LIST1, m_usr);
}

/*
	CList<CString>* txt= &(GetDocument()->text);
	POSITION pos;
	pos = txt->GetTailPosition();
	while(pos)
	{
		CString line = (CString)(txt->GetAt(pos));
		dc.DrawText(line, &rc, 0);
		rc.top += 20;
		txt->GetPrev(pos);
	}
*/
BEGIN_MESSAGE_MAP(CPiSrvDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()


// CPiSrvDlg message handlers

BOOL CPiSrvDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	ThParam* tp = new ThParam();
	tp->pisrv = this;
	srvMainThread = AfxBeginThread(&ServerMainThread, (LPVOID)tp);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CPiSrvDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
		CDialog::OnSysCommand(nID, lParam);
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CPiSrvDlg::OnPaint()
{
	if (pText != NULL)
	{
		m_log.AddString(*pText);
		delete pText;
		pText = NULL;
	}
	//if (IsIconic())
	//{
	//	CPaintDC dc(this); // device context for painting

	//	SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

	//	// Center icon in client rectangle
	//	int cxIcon = GetSystemMetrics(SM_CXICON);
	//	int cyIcon = GetSystemMetrics(SM_CYICON);
	//	CRect rect;
	//	GetClientRect(&rect);
	//	int x = (rect.Width() - cxIcon + 1) / 2;
	//	int y = (rect.Height() - cyIcon + 1) / 2;

	//	// Draw the icon
	//	dc.DrawIcon(x, y, m_hIcon);
	//}
	//else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CPiSrvDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

// CAboutDlg dialog used for App About
