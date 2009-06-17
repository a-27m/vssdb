
// RegViewView.h : interface of the CRegViewView class
//


#pragma once


class CRegViewView : public CListView
{
protected: // create from serialization only
	DECLARE_DYNCREATE(CRegViewView)

// Attributes
public:
	CRegViewView();

	CRegViewDoc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual void OnInitialUpdate(); // called first time after construct

// Implementation
public:
	virtual ~CRegViewView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	afx_msg void OnStyleChanged(int nStyleType, LPSTYLESTRUCT lpStyleStruct);
	afx_msg void OnFilePrintPreview();
	afx_msg void OnRButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnContextMenu(CWnd* pWnd, CPoint point);

	virtual BOOL OnNotify(WPARAM wParam, LPARAM lParam, LRESULT* pResult);

	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in RegViewView.cpp
inline CRegViewDoc* CRegViewView::GetDocument() const
   { return reinterpret_cast<CRegViewDoc*>(m_pDocument); }
#endif

