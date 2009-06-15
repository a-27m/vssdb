// PiChatClientDlg.cpp : implementation file
//

#include "stdafx.h"
#include "PiChatClient.h"
#include "PiChatClientDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define BUFSIZE 1000

UINT PipeReader( LPVOID pParam );

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
	DDX_Control(pDX, IDC_EDIT2, m_textChat);
	DDX_Control(pDX, IDC_EDIT1, m_textInput);
}

BEGIN_MESSAGE_MAP(CPiClientDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BUTTON1, &CPiClientDlg::OnBnClickedButton1)
	ON_LBN_DBLCLK(IDC_LIST1, &CPiClientDlg::OnLbnDblclkList1)
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
	AfxBeginThread(&PipeReader, this);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CPiClientDlg::OnPaint()
{
	m_buddylist.ResetContent();
	CMyList<CString>::Iterator i(&listText);
	while(!i.EOL)
	{
		m_buddylist.InsertString(0, i.GetCurrent()->data);
		i.GoNext();
	}

	UpdateData(FALSE);
	m_textChat.LineScroll(10);

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
		ConnectServer();
		return;
	}

	if (m_input.GetLength() == 0) return;

	 // Convert to a wchar_t*
	USES_CONVERSION;
	wchar_t*  pws = T2W(m_input.GetBuffer());
	m_input.ReleaseBuffer();

	DWORD cbWritten;
	BOOL fSuccess = WriteFile(
		pServer,                  // pipe handle 
		pws,             // message 
		(wcslen(pws)+1)*sizeof(wchar_t), // message length 
		&cbWritten,             // bytes written 
		NULL);                  // not overlapped 

	if (!fSuccess) 
	{
		CString msg;
		msg.Format(L"Write to pipe failed with system error code: 0x%X", GetLastError());
		AfxMessageBox(msg);
		return;
	}

	if (pws[0] == L'!')
	{
		this->SetWindowText(++pws);
		m_input.Empty();
	}
	
	UpdateData(FALSE);
	m_textChat.SetScrollPos(SB_VERT, 100);
	m_textInput.SetFocus();
	m_textInput.SetSel(0, m_input.GetLength());
}

void CPiClientDlg::OnLbnDblclkList1()
{
	UpdateData(TRUE);
	CString msg;
	int i = m_buddylist.GetCurSel();
	if (i != -1)
	{
		m_buddylist.GetText(i, msg);
		msg.AppendFormat(L":%s", m_input);
		m_input.SetString(msg);
		UpdateData(FALSE);
	}
}

UINT PipeReader( LPVOID pParam )
{
	CPiClientDlg* pThis = (CPiClientDlg*)pParam;
	DWORD len;
	DWORD cbRead, cbAvail, cbLeft;
	wchar_t buffer[BUFSIZE];

	while(1)
	{
		if (!weAreConnected) continue;

		/*begin*/
		if(!PeekNamedPipe(pServer,
			buffer, BUFSIZE*sizeof(wchar_t),
			&cbRead, &cbAvail, &cbLeft))
		{
			//KillTimer(m_nTimer);
			CloseHandle(pServer);
			//m_txtText.AppendFormat(L"%s", L"\r\nServer has closed pipe, end of transmission.\r\n");
			weAreConnected = FALSE;
			//pThis->m_button.SetWindowText(L"Connect");
			return FALSE; 
		}

		if(cbAvail != 0 )
		{
			BOOL fSuccess = ::ReadFile(
				pServer, 
				&buffer, 
				1000*sizeof(wchar_t), 
				&len,
				NULL);

			BYTE* pRaw = (BYTE*)&buffer;
			if ( *pRaw == 27) // we've received users list
			{		
				pRaw++;

				pThis->ClearBuddies();

				CMemFile f;
				f.Attach(pRaw, 1000*sizeof(wchar_t));

				CArchive ar(&f, CArchive::load);

				int count;
				ar>>count;
				CString name;
				for(int i = 0; i < count; i++)
				{
					ar>>(name);
					pThis->AddBuddy(&name);
				}

				pThis->PostMessage(WM_PAINT);
			}
			else
			{
				pThis->m_chat.Append(buffer);
				pThis->m_chat.Append(L"\r\n");
				pThis->PostMessage(WM_PAINT);
			}
		}

		::Sleep(300);
	}

	//	CDialog::OnTimer(nIDEvent);

	/*end*/

/*
*/
	return TRUE;
}