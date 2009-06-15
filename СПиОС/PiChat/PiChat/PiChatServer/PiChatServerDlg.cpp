
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
void SendList();
void SendTo(CString* name, CString* msg);

struct ThParam 
{
	HANDLE h;
	CPiSrvDlg* pisrv; 
};
struct Client
{
	OVERLAPPED ovlp;
	HANDLE m_h;
	CString m_name;
};

CMyList<Client> cls;
int clientsCount = 1;

CString* ClientNameByHandle(HANDLE h);
HANDLE ClientHandleByName(CString* str);
VOID WINAPI CompletedWrite(DWORD, DWORD, LPOVERLAPPED); 

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

		tp->pisrv->WriteLine(CString(L"Pipe created, ready for client connection..."));
			tp->pisrv->PostMessage(WM_PAINT);

		if (ConnectNamedPipe(newPipe, NULL))
		{
			CString name;
			name.Format(L"Unnamed%d", clientsCount++);

			Client client;
			client.m_h = newPipe;
			client.m_name = name;

			cls.AddLast(client);

			tp->pisrv->WriteLine(CString(L"New client is connected, starting it's worker thread..."));
			tp->pisrv->PostMessage(WM_PAINT);

			ThParam* tp2 = new ThParam;
			tp2->pisrv = tp->pisrv;			
			tp2->h = newPipe;

			AfxBeginThread(&ClientThread,  (LPVOID)tp2);

			SendList();
		}
	}
}

UINT ClientThread( LPVOID pParam )
{
	ThParam* tp = (ThParam*) pParam;

	HANDLE hPipe = tp->h;

	wchar_t buffer[BUFSIZE];
	DWORD len = 0;
	DWORD cbRead, cbAvail, cbLeft;

	while(1)
	{
		if(!PeekNamedPipe(hPipe,
			buffer, BUFSIZE*sizeof(wchar_t),
			&cbRead, &cbAvail, &cbLeft))
		{
			CMyList<Client> ncls;
			int j = 0;
			CMyList<Client>::Iterator i(&cls);
			while(!i.EOL)
			{ 
				if (i.GetCurrent()->data.m_h == hPipe)//if (!result[j++])
				{
					CString log;
					log.Format(L"Client '%s' is now disconnected.", cls.GetByIndex(j)->m_name);
					tp->pisrv->WriteLine(log);

					cls.RemoveAt(j);//.GetCurrent()->data.m_h = INVALID_HANDLE_VALUE;
					break;
				}
				i.GoNext(); j++;
			}// looking for ourself and remove

			tp->pisrv->PostMessage(WM_PAINT);
			SendList();

			CloseHandle(hPipe);

			delete tp;
			return FALSE; 
		}  // Peek fail 

		if(cbAvail != 0 )
		{
			if (ReadFile(hPipe, &buffer, BUFSIZE, &len, NULL))
			{
				CString msg(buffer);
				if (msg.GetAt(0) == L'!')
				{
					CMyList<Client>::Iterator i(&cls);
					while(!i.EOL)
					{ 
						if (i.GetCurrent()->data.m_h == hPipe)
						{
							i.GetCurrent()->data.m_name = msg.Right(msg.GetLength()-1);
							goto awayLabel;
						}

						i.GoNext();
					}

awayLabel:
					tp->pisrv->PostMessage(WM_PAINT);
					SendList();

					continue;
				} // name change request

				msg.Trim();

				CString log;
				log.Format(L"New message: %s", msg);
				tp->pisrv->WriteLine(log);
				tp->pisrv->PostMessage(WM_PAINT);

				CString name;
				CString fromName = *ClientNameByHandle(hPipe);
					CString stamp;

				int pos = msg.Find(L':');
				if ( (pos == -1) || (pos == 0) )
				{
					name = L"*";
					stamp.Format(L"%s: ", fromName);
					msg.Insert(0, stamp);
					SendTo(&name, &msg);
				}
				else
				{
					name = msg.Left(pos);
					msg = msg.Right(msg.GetLength()-pos-1);
					CString msg1 = msg;
					stamp.Format(L"%s Ч> You: ", fromName);					
					msg.Insert(0, stamp);
					stamp.Format(L"%s Ч> %s: ", fromName, name);					
					msg1.Insert(0, stamp);
					SendTo(&name, &msg);
					SendTo(&fromName, &msg1);
				} // рассылка

			} // read file
		} // avail > 0

		::Sleep(300);
	}

	delete tp;
	return 0;
}

void SendList()
{
	if (cls.GetCount() == 0) return;

	UINT buflen = cls.GetCount()*sizeof(wchar_t)*255;
	BYTE* buffer = new BYTE[buflen];
	CMemFile f;
	f.Attach(buffer, buflen);

	CArchive ar(&f, CArchive::store);
	CMyList<Client>::Iterator iNames(&cls);

	ar<<(BYTE)27;
	ar<<cls.GetCount();
	while(!iNames.EOL)
	{
		ar<<(iNames.GetCurrent()->data.m_name);
		iNames.GoNext();
	}
	ar.Close();

	CMyList<Client>::Iterator i(&cls);
	while(!i.EOL)
	{
		DWORD written;

		//BOOL fSuccess = ::WriteFileEx(
		//	i.GetCurrent()->data.m_h,
		//	buffer, 
		//	buflen,
		//	(LPOVERLAPPED) & i.GetCurrent()->data.ovlp.,
		//	&CompletedWrite
		//	);

		BOOL fSuccess = ::WriteFile(
			i.GetCurrent()->data.m_h,
			buffer, 
			buflen,
			&written,
			NULL
			);

		i.GoNext();
	}

	delete buffer;
}

void SendTo(CString* strTo, CString* msg)
{
	int* result = new int[cls.GetCount()];
	int j = 0;
	msg->LockBuffer();
	DWORD written;

	CMyList<Client>::Iterator i(&cls);
	while(!i.EOL)
	{
		if (*strTo != L"*")
		{
			if (i.GetCurrent()->data.m_name != *strTo)
			{	
				i.GoNext();
				continue;
			}
		}

		BOOL fSuccess = ::WriteFile(
			i.GetCurrent()->data.m_h,
			msg->GetBuffer(), 
			(msg->GetLength()+1)*sizeof(wchar_t),
			&written,//(LPOVERLAPPED) & i.GetCurrent()->data,
			NULL//&CompletedWrite
			);

		result[j++] = fSuccess;

		i.GoNext();
	}

	msg->ReleaseBuffer();


	delete result;
}

VOID WINAPI CompletedWrite(DWORD dwErr, DWORD cbWritten, LPOVERLAPPED po)
{
	Client* pClient = (Client*)po;

}

// CPiSrvDlg dialog

CPiSrvDlg::CPiSrvDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CPiSrvDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CPiSrvDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST2, m_log);
	DDX_Control(pDX, IDC_LIST1, m_usr);
}


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
	ThParam* tp = new ThParam;
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
	m_log.ResetContent();
	CMyList<CString>::Iterator i(&listText);
	while(!i.EOL)
	{
		m_log.InsertString(0, i.GetCurrent()->data);
		i.GoNext();
	}

	m_usr.ResetContent();
	CMyList<Client>::Iterator j(&cls);
	while(!j.EOL)
	{
		m_usr.AddString(j.GetCurrent()->data.m_name);
		j.GoNext();
	}

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
HCURSOR CPiSrvDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

// CAboutDlg dialog used for App About

CString* ClientNameByHandle(HANDLE h)
{
	Client c;

	CMyList<Client>::Iterator i(&cls);
	while(!i.EOL)
	{
		c = i.GetCurrent()->data;
		if (c.m_h == h) return &c.m_name;
		i.GoNext();
	}

	return NULL;
}
HANDLE ClientHandleByName(CString *pstr)
{
	Client c;

	CMyList<Client>::Iterator i(&cls);
	while(!i.EOL)
	{
		c = i.GetCurrent()->data;
		if (c.m_name.Compare(*pstr) == 0) return c.m_h;
		i.GoNext();
	}
	
	return NULL;
}