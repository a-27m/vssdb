// LabTest2Dlg.h : header file
//

#pragma once
#include "labactivectrl1.h"
#include "afxcmn.h"


// CLabTest2Dlg dialog
class CLabTest2Dlg : public CDialog
{
// Construction
public:
	CLabTest2Dlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_LABTEST2_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg void OnHScroll(UINT, UINT, CScrollBar*);
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	CLabactivectrl1 m_labctct;
	afx_msg void OnBnClickedOk();
	CSliderCtrl m_slider;
};
