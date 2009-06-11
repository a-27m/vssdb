// ChildView.cpp : implementation of the CChildView class
//

#include "stdafx.h"
#include "PiChat.h"
#include "ChildView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define BUFSIZE 1024

// CChildView

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

UINT ServerMainThread( LPVOID pParam )
{
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

		if (ConnectNamedPipe(newPipe, NULL))
		{
			HANDLE hCurrentProcess = GetCurrentProcess();
			HANDLE hPipe;
			DuplicateHandle(hCurrentProcess, newPipe,
				hCurrentProcess, &hPipe,	0, TRUE, DUPLICATE_SAME_ACCESS);

			// start new thread for client interaction
			AfxBeginThread((AFX_THREADPROC)&ClientThread, &hPipe);
		}
	}
}

UINT ClientThread( LPVOID pParam )
{
	HANDLE hPipe = *(LPHANDLE*)pParam;

	char buffer[BUFSIZE];
	DWORD len = 0;

	while(1)
	{
		if (ReadFile(hPipe, &buffer, BUFSIZE, &len, NULL))
		{
			//GetDocument()->->text.AddTail(CString(buffer));

		}
	}
}

CChildView::CChildView()
{
	fontHeight = 18;

	simpleFont = new CFont();
	simpleFont->CreateFontW(
		fontHeight, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, L"Cambria");

	srvMainThread = AfxBeginThread(&ServerMainThread, NULL);

	//m_pDocument = new CChatDocument();
	
}

CChildView::~CChildView()
{
	srvMainThread->ExitInstance();
}


BEGIN_MESSAGE_MAP(CChildView, CEditView)
	ON_WM_PAINT()
END_MESSAGE_MAP()



// CChildView message handlers

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
		if (!CEditView::PreCreateWindow(cs))
		return FALSE;

	//if (m_bDefWordWrap)
	//	cs.style &= ~(WS_HSCROLL|ES_AUTOHSCROLL);

	return TRUE;


	//if (!CWnd::PreCreateWindow(cs))
	//	return FALSE;

	//cs.dwExStyle |= WS_EX_CLIENTEDGE;
	//cs.style &= ~WS_BORDER;
	//cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
	//	::LoadCursor(NULL, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), NULL);

	return TRUE;
}



void CChildView::OnPaint() 
{
	CPaintDC dc(this); // device context for painting
	
	RECT rc;
	this->GetClientRect(&rc);

	dc.SelectObject(simpleFont);
	dc.DrawText(L"Привет! Съешь еще этих ленивых собак. And jump over the fox.", 	79-19, &rc, 0);

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
	// Do not call CWnd::OnPaint() for painting messages
}

