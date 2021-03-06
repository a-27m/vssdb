
// PiChatServerDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "mylist.h"

#define MAX_CLIENT 100

// CPiSrvDlg dialog
class CPiSrvDlg : public CDialog
{
// Construction
public:
	CPiSrvDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_PICHATSERVER_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;
	CWinThread* srvMainThread;
	CMyList<CString> listText;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	CListBox m_log;
	CListBox m_usr;

	void WriteLine(CString str) { listText.AddFirst(str); }
};
