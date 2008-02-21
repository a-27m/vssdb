// actixPropPage.cpp : Implementation of the CactixPropPage property page class.

#include "stdafx.h"
#include "actix.h"
#include "actixPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CactixPropPage, COlePropertyPage)



// Message map

BEGIN_MESSAGE_MAP(CactixPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// Initialize class factory and guid

IMPLEMENT_OLECREATE_EX(CactixPropPage, "ACTIX.actixPropPage.1",
	0xfb825460, 0x64c7, 0x41d5, 0xa2, 0x81, 0xd8, 0x19, 0x15, 0xc0, 0x69, 0xe0)



// CactixPropPage::CactixPropPageFactory::UpdateRegistry -
// Adds or removes system registry entries for CactixPropPage

BOOL CactixPropPage::CactixPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ACTIX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CactixPropPage::CactixPropPage - Constructor

CactixPropPage::CactixPropPage() :
	COlePropertyPage(IDD, IDS_ACTIX_PPG_CAPTION)
{
}



// CactixPropPage::DoDataExchange - Moves data between page and properties

void CactixPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CactixPropPage message handlers
