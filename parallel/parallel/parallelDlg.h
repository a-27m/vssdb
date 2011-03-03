
// parallelDlg.h : header file
//

#pragma once


// CParallelDlg dialog
class CParallelDlg : public CDialogEx
{
// Construction
public:
	CParallelDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_PARALLEL_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions

private:
	virtual BOOL OnInitDialog();
protected:
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();
	int m_Threads;
	UINT m_N;
	double m_Eps;
	double m_Sum;
	double m_Precise;
	double m_X;
};
