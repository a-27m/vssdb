
// RegViewDoc.cpp : implementation of the CRegViewDoc class
//

#include "stdafx.h"
#include "RegView.h"

#include "RegViewDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CRegViewDoc

IMPLEMENT_DYNCREATE(CRegViewDoc, CDocument)

BEGIN_MESSAGE_MAP(CRegViewDoc, CDocument)
END_MESSAGE_MAP()


// CRegViewDoc construction/destruction

CRegViewDoc::CRegViewDoc()
{
	// TODO: add one-time construction code here

}

CRegViewDoc::~CRegViewDoc()
{
}

BOOL CRegViewDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CRegViewDoc serialization

void CRegViewDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}


// CRegViewDoc diagnostics

#ifdef _DEBUG
void CRegViewDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CRegViewDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CRegViewDoc commands
