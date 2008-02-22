#pragma once
#include "afxwin.h"


// CDlgProp dialog

class CAddCityDlg : public CDialog
{
	DECLARE_DYNAMIC(CAddCityDlg)

public:
	CAddCityDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~CAddCityDlg();

// Dialog Data
	enum { IDD = IDD_DIALOG1 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	CEdit m_edit;
public:
	CString m_name;
public:
	afx_msg void OnBnClickedOk();
};
#pragma once

#include "graph.h"

// CPropDlg dialog

class CPropDlg : public CDialog
{
	DECLARE_DYNAMIC(CPropDlg)

	GRAPHPROPS props;

public:
	afx_msg void OnPaint( );
	CPropDlg(GRAPHPROPS props, CWnd* pParent = NULL);   // standard constructor
	virtual ~CPropDlg();

// Dialog Data
	enum { IDD = IDD_DIALOG2 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButton1();
public:
	afx_msg void OnBnClickedOk();
public:
	afx_msg void OnBnClickedButton2();
public:
	afx_msg void OnBnClickedButton3();
public:
	afx_msg void OnBnClickedButton5();
public:
	CString m_fnt_name;
public:
	int m_r;
};
#pragma once


// CPipDlg dialog

class CPipDlg : public CDialog
{
	DECLARE_DYNAMIC(CPipDlg)

public:
	CPipDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~CPipDlg();

// Dialog Data
	enum { IDD = IDD_DIALOG3 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	double m_cost;
};
