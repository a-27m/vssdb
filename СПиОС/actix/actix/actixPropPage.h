#pragma once

// actixPropPage.h : Declaration of the CactixPropPage property page class.


// CactixPropPage : See actixPropPage.cpp for implementation.

class CactixPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CactixPropPage)
	DECLARE_OLECREATE_EX(CactixPropPage)

// Constructor
public:
	CactixPropPage();

// Dialog Data
	enum { IDD = IDD_PROPPAGE_ACTIX };

// Implementation
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Message maps
protected:
	DECLARE_MESSAGE_MAP()
};

