// ComicTestDlg.h : header file
//
#pragma once
#include "afxwin.h"
#include "afxcmn.h"


// CComicTestDlg dialog
class CComicTestDlg : public CDialog
{
// Construction
public:
	CComicTestDlg(CWnd* pParent = NULL);	// standard constructor
	void Cout(LPCTSTR msg);
	~CComicTestDlg();

// Dialog Data

	CMyList<float>* l_x;
	CMyList<float>* l_y;

	enum { IDD = IDD_COMICTEST_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	void UpdateList();
	float f(float x);

	float m_x;
	float m_y;
	float m_x1;
	float m_x2;
	float m_step;
	CListBox m_list;
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedButtonSet();
	afx_msg void OnBnClickedCancel();
	CAnimateCtrl m_pic;
};
