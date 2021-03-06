
// RegViewView.cpp : implementation of the CRegViewView class
//

#include "stdafx.h"
#include "RegView.h"

#include "RegViewDoc.h"
#include "RegViewView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CRegViewView

IMPLEMENT_DYNCREATE(CRegViewView, CListView)

BEGIN_MESSAGE_MAP(CRegViewView, CListView)
	ON_WM_STYLECHANGED()
END_MESSAGE_MAP()

// CRegViewView construction/destruction

CRegViewView::CRegViewView()
{
	// TODO: add construction code here

}

CRegViewView::~CRegViewView()
{
}

BOOL CRegViewView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CListView::PreCreateWindow(cs);
}

void CRegViewView::OnInitialUpdate()
{
	CListView::OnInitialUpdate();

	ModifyStyle(LVS_TYPEMASK, LVS_REPORT);
	//ModifyStyle(0, LVS_SORTASCENDING);

	GetListCtrl().InsertColumn(0, L"Name",	0, 150,	0);
	GetListCtrl().InsertColumn(1, L"Type",	0, 100,	1);
	GetListCtrl().InsertColumn(2, L"Value",	0, 300,	2);
}

void CRegViewView::OnRButtonUp(UINT nFlags, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CRegViewView::OnContextMenu(CWnd* pWnd, CPoint point)
{
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
}


// CRegViewView diagnostics

#ifdef _DEBUG
void CRegViewView::AssertValid() const
{
	CListView::AssertValid();
}

void CRegViewView::Dump(CDumpContext& dc) const
{
	CListView::Dump(dc);
}

CRegViewDoc* CRegViewView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CRegViewDoc)));
	return (CRegViewDoc*)m_pDocument;
}
#endif //_DEBUG


// CRegViewView message handlers
void CRegViewView::OnStyleChanged(int nStyleType, LPSTYLESTRUCT lpStyleStruct)
{
	//TODO: add code to react to the user changing the view style of your window	
	CListView::OnStyleChanged(nStyleType,lpStyleStruct);	
}

BOOL CRegViewView::OnNotify(WPARAM wParam, LPARAM lParam, LRESULT* pResult)
{
	NMHDR* pNMHDR = (NMHDR*)lParam;
	ASSERT(pNMHDR != NULL);

	if (pNMHDR->code == TVN_ITEMEXPANDING)
	{
		AfxMessageBox(L"This is it again");
	}

	return CListView::OnNotify(wParam, lParam, pResult);
}
