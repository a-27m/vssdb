// ChildView.h : interface of the CChildView class
//


#pragma once


// CChildView window
class CChatDocument;

class CChildView : public CEditView//CWnd
{
// Construction
public:
	CChildView();

// Attributes
public:
	CFont* simpleFont;
	int fontHeight;
// Operations
public:
// Overrides
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Implementation
public:
	virtual ~CChildView();

	// Generated message map functions
protected:
	CWinThread* srvMainThread;
	friend UINT ServerMainThread( LPVOID pParam ); 
	friend UINT ClientThread( LPVOID pParam ); 
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()

	CChatDocument* GetDocument() { return (CChatDocument*)m_pDocument; }
};

class CChatDocument : public CDocument
{
public:
	CList<CString> text;
};