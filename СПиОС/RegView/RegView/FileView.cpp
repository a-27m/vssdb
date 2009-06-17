
#include "stdafx.h"
#include "mainfrm.h"
#include "FileView.h"
#include "Resource.h"
#include "RegView.h"
#include "RegViewDoc.h"
#include "RegViewView.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

#define BUF_MAXLEN 256
#define STR_HKEY_LOCAL_MACHINE L"HKEY_LOCAL_MACHINE"
#define STR_HKEY_CLASSES_ROOT L"HKEY_CLASSES_ROOT"
#define STR_HKEY_USERS L"HKEY_USERS"
#define STR_HKEY_CURRENT_USER L"HKEY_CURRENT_USER"
#define SWAP_ENDIAN(x) (((x<<24)&0xFF000000)|((x<<8)&0xFF0000)|\
                       ((x>>8)&0xFF00)|((x>>24)|0xFF))

/////////////////////////////////////////////////////////////////////////////
// CFileView

CFileView::CFileView()
{
}

CFileView::~CFileView()
{
}

BEGIN_MESSAGE_MAP(CFileView, CDockablePane)
	ON_WM_CREATE()
	ON_WM_SIZE()
	ON_WM_CONTEXTMENU()
	ON_COMMAND(ID_PROPERTIES, OnProperties)
	ON_COMMAND(ID_OPEN, OnFileOpen)
	ON_COMMAND(ID_OPEN_WITH, OnFileOpenWith)
	ON_COMMAND(ID_DUMMY_COMPILE, OnDummyCompile)
	ON_COMMAND(ID_EDIT_CUT, OnEditCut)
	ON_COMMAND(ID_EDIT_COPY, OnEditCopy)
	ON_COMMAND(ID_EDIT_CLEAR, OnEditClear)
	ON_WM_PAINT()
	ON_WM_SETFOCUS()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CWorkspaceBar message handlers

int CFileView::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CDockablePane::OnCreate(lpCreateStruct) == -1)
		return -1;

	CRect rectDummy;
	rectDummy.SetRectEmpty();

	// Create view:
	const DWORD dwViewStyle = WS_CHILD | WS_VISIBLE | TVS_HASLINES | TVS_LINESATROOT | TVS_HASBUTTONS | TVS_SHOWSELALWAYS;

	if (!m_wndFileView.Create(dwViewStyle, rectDummy, this, 4))
	{
		TRACE0("Failed to create file view\n");
		return -1;      // fail to create
	}

	// Load view images:
	m_FileViewImages.Create(IDB_FILE_VIEW, 16, 0, RGB(255, 0, 255));
	m_wndFileView.SetImageList(&m_FileViewImages, TVSIL_NORMAL);

	//m_wndToolBar.Create(this, AFX_DEFAULT_TOOLBAR_STYLE, IDR_EXPLORER);
	//m_wndToolBar.LoadToolBar(IDR_EXPLORER, 0, 0, TRUE /* Is locked */);

	OnChangeVisualStyle();

	//m_wndToolBar.SetPaneStyle(m_wndToolBar.GetPaneStyle() | CBRS_TOOLTIPS | CBRS_FLYBY);

	//m_wndToolBar.SetPaneStyle(m_wndToolBar.GetPaneStyle() & ~(CBRS_GRIPPER | CBRS_SIZE_DYNAMIC | CBRS_BORDER_TOP | CBRS_BORDER_BOTTOM | CBRS_BORDER_LEFT | CBRS_BORDER_RIGHT));

	m_wndToolBar.SetOwner(this);

	// All commands will be routed via this control , not via the parent frame:
	m_wndToolBar.SetRouteCommandsViaFrame(FALSE);

	// Fill in some static tree view data (dummy code, nothing magic here)
	FillFileView();
	AdjustLayout();

	return 0;
}

void CFileView::OnSize(UINT nType, int cx, int cy)
{
	CDockablePane::OnSize(nType, cx, cy);
	AdjustLayout();
}


void CFileView::FillFileView()
{
	hRoot = m_wndFileView.InsertItem(_T("Windows registry root"), 0, 0);
	m_wndFileView.SetItemState(hRoot, TVIS_BOLD, TVIS_BOLD);

	hTiHKCR = m_wndFileView.InsertItem(STR_HKEY_CLASSES_ROOT, 0, 0, hRoot);
	hTiHKCU = m_wndFileView.InsertItem(STR_HKEY_CURRENT_USER, 0, 0, hRoot);
	hTiHKLM = m_wndFileView.InsertItem(STR_HKEY_LOCAL_MACHINE, 0, 0, hRoot);
	hTiHKU = m_wndFileView.InsertItem(STR_HKEY_USERS, 0, 0, hRoot);

	// respective empty elenents to keep nodes openable
	m_wndFileView.InsertItem(_T(""), 0, 0, hTiHKCR);
	m_wndFileView.InsertItem(_T(""), 0, 0, hTiHKCU);
	m_wndFileView.InsertItem(_T(""), 0, 0, hTiHKLM);
	m_wndFileView.InsertItem(_T(""), 0, 0, hTiHKU);

	//m_wndFileView.SetItemState(
	m_wndFileView.Expand(hRoot, TVE_EXPAND);
	//m_wndFileView.Expand(hTiKHCR, TVE_EXPAND);
}

void CFileView::OnContextMenu(CWnd* pWnd, CPoint point)
{
		CDockablePane::OnContextMenu(pWnd, point);
		return;
		/*
	CTreeCtrl* pWndTree = (CTreeCtrl*) &m_wndFileView;
	ASSERT_VALID(pWndTree);

	if (pWnd != pWndTree)
	{
	}

	if (point != CPoint(-1, -1))
	{
		// Select clicked item:
		CPoint ptTree = point;
		pWndTree->ScreenToClient(&ptTree);

		UINT flags = 0;
		HTREEITEM hTreeItem = pWndTree->HitTest(ptTree, &flags);
		if (hTreeItem != NULL)
		{
			pWndTree->SelectItem(hTreeItem);
		}
	}

	pWndTree->SetFocus();
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EXPLORER, point.x, point.y, this, TRUE);
	*/
}

void CFileView::AdjustLayout()
{
	if (GetSafeHwnd() == NULL)
	{
		return;
	}

	CRect rectClient;
	GetClientRect(rectClient);

	//int cyTlb = m_wndToolBar.CalcFixedLayout(FALSE, TRUE).cy;
int cyTlb = 0;
	//m_wndToolBar.SetWindowPos(NULL, rectClient.left, rectClient.top, rectClient.Width(), cyTlb, SWP_NOACTIVATE | SWP_NOZORDER);
	m_wndFileView.SetWindowPos(NULL, rectClient.left + 1, rectClient.top + cyTlb + 1, rectClient.Width() - 2, rectClient.Height() - cyTlb - 2, SWP_NOACTIVATE | SWP_NOZORDER);
}

void CFileView::OnProperties()
{
	//AfxMessageBox(_T("Properties...."));

}

void CFileView::OnFileOpen()
{
	HTREEITEM hTVI=  m_wndFileView.GetSelectedItem();
	if (hTVI != NULL)
	{
		AfxMessageBox(m_wndFileView.GetItemText(hTVI));
	}
	// TODO: Add your command handler code here
}

void CFileView::OnFileOpenWith()
{
	// TODO: Add your command handler code here
}

void CFileView::OnDummyCompile()
{
	// TODO: Add your command handler code here
}

void CFileView::OnEditCut()
{
	// TODO: Add your command handler code here
}

void CFileView::OnEditCopy()
{
	// TODO: Add your command handler code here
}

void CFileView::OnEditClear()
{
	// TODO: Add your command handler code here
}

void CFileView::OnPaint()
{
	CPaintDC dc(this); // device context for painting

	CRect rectTree;
	m_wndFileView.GetWindowRect(rectTree);
	ScreenToClient(rectTree);

	rectTree.InflateRect(1, 1);
	dc.Draw3dRect(rectTree, ::GetSysColor(COLOR_3DSHADOW), ::GetSysColor(COLOR_3DSHADOW));
}

void CFileView::OnSetFocus(CWnd* pOldWnd)
{
	CDockablePane::OnSetFocus(pOldWnd);

	m_wndFileView.SetFocus();
}

void CFileView::OnChangeVisualStyle()
{
	m_wndToolBar.CleanUpLockedImages();
	m_wndToolBar.LoadBitmap(theApp.m_bHiColorIcons ? IDB_EXPLORER_24 : IDR_EXPLORER, 0, 0, TRUE /* Locked */);

	m_FileViewImages.DeleteImageList();

	UINT uiBmpId = theApp.m_bHiColorIcons ? IDB_FILE_VIEW_24 : IDB_FILE_VIEW;

	CBitmap bmp;
	if (!bmp.LoadBitmap(uiBmpId))
	{
		TRACE(_T("Can't load bitmap: %x\n"), uiBmpId);
		ASSERT(FALSE);
		return;
	}

	BITMAP bmpObj;
	bmp.GetBitmap(&bmpObj);

	UINT nFlags = ILC_MASK;

	nFlags |= (theApp.m_bHiColorIcons) ? ILC_COLOR24 : ILC_COLOR4;

	m_FileViewImages.Create(16, bmpObj.bmHeight, nFlags, 0, 0);
	m_FileViewImages.Add(&bmp, RGB(255, 0, 255));

	m_wndFileView.SetImageList(&m_FileViewImages, TVSIL_NORMAL);
}

BOOL CFileView::OnNotify(WPARAM wParam, LPARAM lParam, LRESULT *pResult)
{
	NMHDR* pNMHDR = (NMHDR*)lParam;
	ASSERT(pNMHDR != NULL);

	if (pNMHDR->code == TVN_ITEMEXPANDING)
	{
			LPNMTREEVIEW pnmtv = (LPNMTREEVIEW) lParam;
			HTREEITEM hItem = pnmtv->itemNew.hItem;
			UINT action = pnmtv->action;

			if (hItem == hRoot) return TRUE; // ignore expanding or collapsing of the root entry

			CString itemText = m_wndFileView.GetItemText(hItem);

			if (action == TVE_EXPAND)
			{			
				HTREEITEM hChild = m_wndFileView.GetChildItem(hItem);
				if (! m_wndFileView.GetItemText(hChild).IsEmpty() ) // have been opened before
					return CDockablePane::OnNotify(wParam, lParam, pResult);
				
				m_wndFileView.DeleteItem(hChild);

				// enum keys and insert their names into hItem
				LSTATUS fSuccess;
				wchar_t wszBuffer[BUF_MAXLEN];
				HKEY hKey = OpenParentKey(hItem);
				DWORD i = 0;

				do //while that enums keys in expanded branch
				{
					fSuccess = ::RegEnumKey(hKey, i++, (WCHAR *)(&wszBuffer), BUF_MAXLEN);

					if (fSuccess != ERROR_SUCCESS) { break; } // return FALSE; // Should OnNotify() return FALSE now?

					HTREEITEM hNewItem = m_wndFileView.InsertItem((CONST WCHAR *)&wszBuffer, 0, 0, hItem);
					m_wndFileView.InsertItem(_T(""), 0, 0, hNewItem);

				} while (fSuccess == ERROR_SUCCESS);
				
				RegCloseKey(hKey);
			}
	}
	else if (pNMHDR->code == TVN_SELCHANGED)
	{
		HTREEITEM hItem = m_wndFileView.GetSelectedItem();

		((CMainFrame*) this->GetParent())->m_wndStatusBar.SetWindowText(GetPathToItem(hItem));

		if (hItem == hRoot) 	return CDockablePane::OnNotify(wParam, lParam, pResult);

		HKEY hKey = OpenParentKey(hItem);

		CListCtrl& pListCtrl = ( 
			(CRegViewView*) (
				((CMainFrame*) this->GetParent())->GetActiveView() 
				) 
			)->GetListCtrl();
		pListCtrl.DeleteAllItems();

		BOOL fResult; int itemNumber = 0;
		DWORD i = 0, cbData = 1024, dwType, dwBufLen = BUF_MAXLEN;		
		WCHAR wszBuffer[BUF_MAXLEN];
		BYTE bData[1024];
		do 
		{
			cbData = 1024, dwBufLen = BUF_MAXLEN;

			fResult = ::RegEnumValue(hKey, i++, wszBuffer, &dwBufLen, NULL, &dwType, bData, &cbData);

			if (! fResult == ERROR_SUCCESS) break;
			
			CString strValue(L""); 
			CString strType(L"");

			switch (dwType)
			{
			case  REG_NONE:												// No value type
				strType.SetString(L"REG_NONE"); 
				break;
			case REG_SZ:														// Unicode nul terminated string
				strType.SetString(L"REG_SZ"); 
				strValue.Format(TEXT("%s"), (WCHAR*)(bData), i);
				break;
			case REG_EXPAND_SZ:										// Unicode nul terminated string (with environment variable references)
				strType.SetString(L"REG_EXPAND_SZ"); 
				strValue.Format(TEXT("Expandable: %s"), (WCHAR*)(bData), i);
				break;
			case REG_BINARY:												// Free form binary
				strType.SetString(L"REG_BINARY"); 
				for(DWORD k = 0; k<cbData; k++)
					strValue.AppendFormat(TEXT("%0X "), bData[k], i);
				break;
			case REG_DWORD:												// 32-bit number
			//case REG_DWORD_LITTLE_ENDIAN:				// 32-bit number (same as REG_DWORD)
				strType.SetString(L"REG_DWORD"); 
				//for(DWORD k = 0; k<cbData; k++)
					strValue.Format(TEXT("%d"), *(DWORD*)(bData), i);
				break;
			case REG_DWORD_BIG_ENDIAN:						// 32-bit number
				strType.SetString(L"REG_DWORD_BIG_ENDIAN"); 
				for(DWORD k = 0; k<cbData; k++)
					strValue.AppendFormat(TEXT("%d"), SWAP_ENDIAN(*(DWORD*)(bData)), i);
				break;
			case REG_LINK:													// Symbolic Link (unicode)
				strType.SetString(L"REG_LINK"); 
				strValue.SetString(L"(Symbolic Link)");
				break;
			case REG_MULTI_SZ:											// Multiple Unicode strings
				strType.SetString(L"REG_MULTI_SZ"); 
				strValue.SetString(L"(Multiple Unicode strings)");
				break;
			case REG_RESOURCE_LIST:								// Resource list in the resource map
				strType.SetString(L"REG_RESOURCE_LIST"); 
				strValue.SetString(L"(Resource list in the resource map)");
				break;
			case REG_FULL_RESOURCE_DESCRIPTOR:		// Resource list in the hardware description
				strType.SetString(L"REG_FULL_RESOURCE_DESCRIPTOR"); 
				strValue.SetString(L"(value)");
				break;
			case REG_RESOURCE_REQUIREMENTS_LIST:	
				strType.SetString(L"REG_RESOURCE_REQUIREMENTS_LIST"); 
				strValue.SetString(L"(value)");
				break;
			case REG_QWORD:											// 64-bit number
			//case REG_QWORD_LITTLE_ENDIAN:				// 64-bit number (same as REG_QWORD)
				strType.SetString(L"REG_QWORD"); 
				strValue.Format(TEXT("%d"), *(QWORD*)(bData), i);
				break;
			default:
				break;
			}

			pListCtrl.InsertItem(LVIF_TEXT, itemNumber, wszBuffer, 0, 0, 0, NULL);			
			pListCtrl.SetItemText(itemNumber, 0, dwBufLen > 0 ? wszBuffer : L"(Default)");
			pListCtrl.SetItemText(itemNumber, 1, strType);
			pListCtrl.SetItemText(itemNumber, 2, strValue);
			itemNumber++;
		}
		while (fResult == ERROR_SUCCESS);

		::RegCloseKey(hKey);
	}

	return CDockablePane::OnNotify(wParam, lParam, pResult);
}

HKEY CFileView::OpenParentKey(HTREEITEM hItem)
{
	if (hItem == hTiHKCR) return HKEY_CLASSES_ROOT;
	if (hItem == hTiHKCU) return HKEY_CURRENT_USER;
	if (hItem == hTiHKLM) return HKEY_LOCAL_MACHINE;
	if (hItem == hTiHKU) return HKEY_USERS;
	if (hItem == hRoot) return (HKEY)INVALID_HANDLE_VALUE;  //error

	// check if we're already at the root of m_wndFileView tree
	if (hItem == TVI_ROOT) return (HKEY)INVALID_HANDLE_VALUE;
	if (hItem == NULL) return (HKEY)INVALID_HANDLE_VALUE;

	HKEY hKey = OpenParentKey(m_wndFileView.GetParentItem(hItem));
	HKEY hKeyResult;

	CString subName = m_wndFileView.GetItemText(hItem);
	if (::RegOpenKeyEx(hKey, subName.GetBuffer(), 0, KEY_READ, &hKeyResult) != ERROR_SUCCESS)
	{
		// do error handling )
		subName.ReleaseBuffer();
		return (HKEY)INVALID_HANDLE_VALUE;
	}
	else
	{
		subName.ReleaseBuffer();
		::RegCloseKey(hKey);
		return hKeyResult;
	}
}

CString CFileView::GetPathToItem(HTREEITEM hItem)
{
	if (hItem == hTiHKCR) return CString(L"HKCR");
	if (hItem == hTiHKCU) return CString(L"HKCU");
	if (hItem == hTiHKLM) return CString(L"HKLM");
	if (hItem == hTiHKU) return CString(L"HKU");
	if (hItem == hRoot) return CString(L"");

	// check if we're already at the root of m_wndFileView tree
	if (hItem == TVI_ROOT) return CString(L"");
	if (hItem == NULL) return CString(L"");

	CString path = GetPathToItem(m_wndFileView.GetParentItem(hItem)) + CString(L"\\") + m_wndFileView.GetItemText(hItem);

	return path;
}