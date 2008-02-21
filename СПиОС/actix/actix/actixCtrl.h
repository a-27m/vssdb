#pragma once

// actixCtrl.h : Declaration of the CactixCtrl ActiveX Control class.


// CactixCtrl : See actixCtrl.cpp for implementation.

class CactixCtrl : public COleControl
{
	DECLARE_DYNCREATE(CactixCtrl)

// Constructor
public:
	CactixCtrl();

// Overrides
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();

// Implementation
protected:
	~CactixCtrl();

	DECLARE_OLECREATE_EX(CactixCtrl)    // Class factory and guid
	DECLARE_OLETYPELIB(CactixCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CactixCtrl)     // Property page IDs
	DECLARE_OLECTLTYPE(CactixCtrl)		// Type name and misc status

// Message maps
	DECLARE_MESSAGE_MAP()

// Dispatch maps
	DECLARE_DISPATCH_MAP()

// Event maps
	DECLARE_EVENT_MAP()

// Dispatch and event IDs
public:
	enum {
	};
};

