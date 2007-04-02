// asmDlg.h : header file
//

#pragma once
#include "afxwin.h"


// CasmDlg dialog
class CasmDlg : public CDialog
{
// Construction
public:
	CasmDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_ASM_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()

public:
	CListBox m_list1;
	CListBox m_list2;

	afx_msg void OnBnClickedOpen();
	afx_msg void OnBnClickedTranslate();
};
