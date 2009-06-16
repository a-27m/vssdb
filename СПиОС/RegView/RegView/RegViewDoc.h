
// RegViewDoc.h : interface of the CRegViewDoc class
//


#pragma once


class CRegViewDoc : public CDocument
{
protected: // create from serialization only
	CRegViewDoc();
	DECLARE_DYNCREATE(CRegViewDoc)

// Attributes
public:

// Operations
public:

// Overrides
public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// Implementation
public:
	virtual ~CRegViewDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};


