// PiChatClientDlg.h : header file
//

#pragma once
#include "afxwin.h"


// CPiClientDlg dialog
class CPiClientDlg : public CDialog
{
// Construction
public:
	CPiClientDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_PICHATCLIENT_DIALOG };

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
	afx_msg void OnBnClickedButton1();

	BOOL ConnectServer();

	// Where user write text of the message
	CString m_input;

	CListBox m_buddylist;

	// Chat flow itself
	CString m_chat;

	CButton m_button;
	afx_msg void OnLbnDblclkList1();
};
