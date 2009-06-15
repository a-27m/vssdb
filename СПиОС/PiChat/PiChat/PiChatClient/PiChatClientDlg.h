// PiChatClientDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "mylist.h"


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
	CMyList<CString> listText;

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
	void AddBuddy(CString* str) { listText.AddFirst(*str); }
	void ClearBuddies() { while(listText.GetCount()) listText.RemoveFirst(); }
	//void WriteLine(CString* str) { .AddFirst(*str); }
	CEdit m_textChat;
	CEdit m_textInput;
};
