// PiChatClientDlg.cpp : implementation file
//

#include "stdafx.h"
#include "PiChatClient.h"
#include "PiChatClientDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CPiClientDlg dialog




CPiClientDlg::CPiClientDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CPiClientDlg::IDD, pParent)
	, m_input(_T(""))
	, m_chat(_T(""))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CPiClientDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT1, m_input);
	DDX_Control(pDX, IDC_LIST1, m_buddylist);
	DDX_Text(pDX, IDC_EDIT2, m_chat);
	DDX_Control(pDX, IDC_BUTTON1, m_button);
}

BEGIN_MESSAGE_MAP(CPiClientDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BUTTON1, &CPiClientDlg::OnBnClickedButton1)
END_MESSAGE_MAP()


// CPiClientDlg message handlers

BOOL CPiClientDlg::OnInitDialog()
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

void CPiClientDlg::OnPaint()
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
HCURSOR CPiClientDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

HANDLE pServer;
bool weAreConnected = false;
BOOL CPiClientDlg::ConnectServer()
{
			CString targetpipe;
		targetpipe.Format(L"\\\\%s\\pipe\\chatpipe", m_input);
		pServer = ::CreateFile(
			targetpipe, // who we connect
			GENERIC_READ | GENERIC_WRITE,
			0,              // no sharing 
			NULL,           // default security attributes
			OPEN_EXISTING,  // opens existing pipe 
			0,              // default attributes 
			NULL);          // no template file 
		
		if (pServer == INVALID_HANDLE_VALUE) 
		{	
			AfxMessageBox(L"Could not open pipe: invalid handle");
			return FALSE;
		}

		DWORD lastError = GetLastError();

		if (lastError != ERROR_SUCCESS)
		{
			if (lastError != ERROR_PIPE_BUSY) 
			{
				CString msg;
				msg.Format(L"Could not open pipe, error code: 0x%Xh", lastError);
				AfxMessageBox(msg);
				CloseHandle(pServer);
				return FALSE;
			}

			// All pipe instances are busy, so wait for 20 seconds.  
			if (!WaitNamedPipe(targetpipe, 5000)) 
			{ 
				AfxMessageBox(L"Could not open pipe: timeout");
				return FALSE;
			} 
		}
		// The pipe connected
		
		//change to message-read mode. 
		DWORD dwMode = PIPE_READMODE_BYTE;
		BOOL fSuccess = SetNamedPipeHandleState(
			pServer,    // pipe handle 
			&dwMode,  // new pipe mode 
			NULL,     // don't set maximum bytes 
			NULL);    // don't set maximum time

		if (!fSuccess) 
		{
			CloseHandle(pServer);
			AfxMessageBox(L"Error: SetNamedPipeHandleState failed."); 
			return FALSE;
		}

		m_chat.Append(L"Connected\r\n"); 
		weAreConnected = TRUE;
		m_button.SetWindowText(L"Send");
		m_input.Empty();

		return TRUE;
}

void CPiClientDlg::OnBnClickedButton1()
{
	UpdateData(TRUE);

	if (!weAreConnected) 
	{
		if (!ConnectServer())
			return;
	}

	DWORD cbWritten;
	BOOL fSuccess = WriteFile(
		pServer,                  // pipe handle 
		m_input,             // message 
		m_input.GetLength()*sizeof(WCHAR),//(lstrlen(lpvMessage)+1)*sizeof(TCHAR), // message length 
		&cbWritten,             // bytes written 
		NULL);                  // not overlapped 

	if (!fSuccess) 
	{
		CString msg;
		msg.Format(L"Write to pipe failed with system error code: 0x%X", GetLastError());
		AfxMessageBox(msg);
		return;
	}
	
	m_chat.Append(L"Sent\r\n"); 

	UpdateData(FALSE);
}
