
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


	// TODO: You may populate your ListView with items by directly accessing
	//  its list control through a call to GetListCtrl().
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
