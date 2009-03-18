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

UINT __cdecl CChildView::ServerMainThread( LPVOID pParam )
{
	while(1)
	{
		HANDLE newPipe = CreateNamedPipe( 
			L"\\\\.\\pipe\\chatsrv",
			PIPE_ACCESS_DUPLEX,       // read/write access 
			PIPE_TYPE_MESSAGE |       // message type pipe 
			PIPE_READMODE_MESSAGE |   // message-read mode 
			PIPE_WAIT,                // blocking mode 
			PIPE_UNLIMITED_INSTANCES, // max. instances  
			BUFSIZE,                  // output buffer size 
			BUFSIZE,                  // input buffer size 
			0,                        // client time-out 
			NULL);                    // default security attribute 

		// if (HANDLE == NULL) ...

		if (ConnectNamedPipe(newPipe, NULL))
		{
			// start new thread for client interaction
			AfxBeginThread(ClientThread, &newPipe);

		}
	}
}

UINT __cdecl CChildView::ClientThread( LPVOID pParam )
{
	HANDLE hPipe = *(LPHANDLE*)pParam;


}

CChildView::CChildView()
{
	fontHeight = 28;

	simpleFont = new CFont();
	simpleFont->CreateFontW(
		fontHeight, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0,fs 0, L"Cambria");

	srvMainThread = AfxBeginThread(ServerMainThread, NULL);
}

CChildView::~CChildView()
{
	srvMainThread->ExitInstance();
}


BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
END_MESSAGE_MAP()



// CChildView message handlers

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(NULL, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), NULL);

	return TRUE;
}

void CChildView::OnPaint() 
{
	CPaintDC dc(this); // device context for painting
	
	RECT rc;
	this->GetClientRect(&rc);

	dc.SelectObject(simpleFont);
	dc.DrawText(L"Привет! Съешь еще этих ленивых собак. And jump over the fox.", 
		79-19, &rc, 0);
	// Do not call CWnd::OnPaint() for painting messages
}

