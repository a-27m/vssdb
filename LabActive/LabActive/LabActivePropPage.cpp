// LabActivePropPage.cpp : Implementation of the CLabActivePropPage property page class.

#include "stdafx.h"
#include "LabActive.h"
#include "LabActivePropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CLabActivePropPage, COlePropertyPage)



// Message map

BEGIN_MESSAGE_MAP(CLabActivePropPage, COlePropertyPage)
END_MESSAGE_MAP()



// Initialize class factory and guid

IMPLEMENT_OLECREATE_EX(CLabActivePropPage, "LABACTIVE.LabActivePropPage.1",
	0x2f898ce1, 0x90d3, 0x4810, 0x87, 0xc, 0x99, 0xdb, 0xc, 0x12, 0xa1, 0x3c)



// CLabActivePropPage::CLabActivePropPageFactory::UpdateRegistry -
// Adds or removes system registry entries for CLabActivePropPage

BOOL CLabActivePropPage::CLabActivePropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_LABACTIVE_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CLabActivePropPage::CLabActivePropPage - Constructor

CLabActivePropPage::CLabActivePropPage() :
	COlePropertyPage(IDD, IDS_LABACTIVE_PPG_CAPTION)
{
}



// CLabActivePropPage::DoDataExchange - Moves data between page and properties

void CLabActivePropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CLabActivePropPage message handlers
