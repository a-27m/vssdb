#pragma once

// Machine generated IDispatch wrapper class(es) created by Microsoft Visual C++

// NOTE: Do not modify the contents of this file.  If this class is regenerated by
//  Microsoft Visual C++, your modifications will be overwritten.

/////////////////////////////////////////////////////////////////////////////
// CLabactivectrl1 wrapper class

class CLabactivectrl1 : public CWnd
{
protected:
	DECLARE_DYNCREATE(CLabactivectrl1)
public:
	CLSID const& GetClsid()
	{
		static CLSID const clsid
			= { 0xCF4DEAEF, 0xF3CD, 0x4E00, { 0x94, 0x25, 0x46, 0xCE, 0x35, 0xF6, 0xBC, 0xDE } };
		return clsid;
	}
	virtual BOOL Create(LPCTSTR lpszClassName, LPCTSTR lpszWindowName, DWORD dwStyle,
						const RECT& rect, CWnd* pParentWnd, UINT nID, 
						CCreateContext* pContext = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID); 
	}

    BOOL Create(LPCTSTR lpszWindowName, DWORD dwStyle, const RECT& rect, CWnd* pParentWnd, 
				UINT nID, CFile* pPersist = NULL, BOOL bStorage = FALSE,
				BSTR bstrLicKey = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID,
		pPersist, bStorage, bstrLicKey); 
	}

// Attributes
public:


// Operations
public:

// _DLabActive

// Functions
//

	void Animate(float speed)
	{
		static BYTE parms[] = VTS_R4 ;
		InvokeHelper(14, DISPATCH_METHOD, VT_EMPTY, NULL, parms, speed);
	}
	void Рассчитать(float x1, float x2, float t1, float t2, float * * f, float * m1, float * m2, float h, float tau)
	{
		static BYTE parms[] = VTS_R4 VTS_R4 VTS_R4 VTS_R4 VTS_UNKNOWN VTS_PR4 VTS_PR4 VTS_R4 VTS_R4 ;
		InvokeHelper(15, DISPATCH_METHOD, VT_EMPTY, NULL, parms, x1, x2, t1, t2, f, m1, m2, h, tau);
	}
	void SetSnapshotIndex(int index)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(16, DISPATCH_METHOD, VT_EMPTY, NULL, parms, index);
	}

// Properties
//



};
