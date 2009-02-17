#pragma once

// LabActivePropPage.h : Declaration of the CLabActivePropPage property page class.


// CLabActivePropPage : See LabActivePropPage.cpp for implementation.

class CLabActivePropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CLabActivePropPage)
	DECLARE_OLECREATE_EX(CLabActivePropPage)

// Constructor
public:
	CLabActivePropPage();

// Dialog Data
	enum { IDD = IDD_PROPPAGE_LABACTIVE };

// Implementation
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Message maps
protected:
	DECLARE_MESSAGE_MAP()
};

