// asmDlg.cpp : implementation file
//

#include "stdafx.h"
#include <stdio.h>
#include "asm.h"
#include "asmDlg.h"
#include "MyList.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif
#pragma warning( disable :4996)
//#pragma warning(disable:4700)

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CasmDlg dialog




CasmDlg::CasmDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CasmDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CasmDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST1, m_list1);
	DDX_Control(pDX, IDC_LIST2, m_list2);
}

BEGIN_MESSAGE_MAP(CasmDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_Open, &CasmDlg::OnBnClickedOpen)
	ON_BN_CLICKED(IDC_Translate, &CasmDlg::OnBnClickedTranslate)
END_MESSAGE_MAP()


// CasmDlg message handlers

BOOL CasmDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CasmDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CasmDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CasmDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CasmDlg::OnBnClickedOpen()
{
	CFileDialog dlg(TRUE, (LPCTSTR)"asm", (LPCTSTR)"*.asm");
	if(dlg.DoModal() == IDOK){
	CStdioFile file;
	CString s;
	VERIFY(file.Open(dlg.GetPathName(),CFile::modeRead));
	while (file.ReadString(s))
	{
		m_list1.AddString(s);
	}
}

}

bool first;
bool error = false;
bool start;
bool end = false;
int ORG = -1000;
int code_start;
int length;
CMyList<int>*	list_addr = new CMyList<int>;
CString label_start;
CMyList<CString> *SymTab = new CMyList<CString>;
CMyList<int> *SymTab_addr = new CMyList<int>;
CMyList<int> *SymTab_value = new CMyList<int>;
int list_i;
int numb;
struct Command{
				char *pname;
				int iCode;
				int iLength;
			  };
Command OpTab[3] = {
					{"MOV", 1, 4},
					{"INT", 2, 2},
					{"RET", 3, 1}
					};

void ORG_Adress(CString s, CString word)
{
	if(word == "ORG")
		{
			CString str;
			bool b = false;
			UINT nType = MB_OK;
	        UINT nIDHelp = 0;
			int w;
			int l = word.GetLength() + 1;  
			for (w = l; w < s.GetLength(); w++)
			{
				if (s.GetAt(w) == ' ')
					b = true;
				int len = word.GetLength();
				if (b == false)
					str.Insert(len, s.GetAt(w));
			}
			ORG = _wtoi((LPCTSTR)str);
			if (ORG == 0)//если в ORG не число
			{
				AfxMessageBox((LPCTSTR)L"Wrang use of directive ORG", nType, nIDHelp);
				error = true;
				return;
			}
			else//если в ORG число
			{
				int len = str.GetLength() + 4;//есть ли еще слова в строке
				if (s.GetLength() != len)
				{
					b = false;
					for (w = len; w < s.GetLength(); w++)
					{
						if (s.GetAt(w) != ' ')
						{
							if (b == false)
							{
								if (s.GetAt(w) == ';')//не комментарий ли
								{
									b = true;
									list_addr ->AddLast(ORG);
									first = false;
								}
								else 
								{
									AfxMessageBox((LPCTSTR)L"Wrang use of directive ORG", nType, nIDHelp);
									error = true;
									return;
								}
							}
						}
					}
				}
				else
				{
					first = false;
					list_addr ->AddLast(ORG);
				}
			}
		}
		else//если не ORG
		{
			if (s.GetAt(0) == ';')
				first = true;
			else
			{
				AfxMessageBox((LPCTSTR)L"Directive ORG wasn't use");
				error = true;
				return;
			}
		}
}

void Label(CString s, CString word)
{
	if(s.GetLength() == word.GetLength())
	{
		if(start)
		{
			AfxMessageBox((LPCTSTR)L"Redefine beginning of programm");
			error = true;
			return;
		}
		else
		{
			int len = word.GetLength() - 1;
			word.Delete(len, 1);
			int count = list_addr->GetCount() - 1;
			code_start = *list_addr->GetByIndex(count);
			label_start = word;
		}
	}
	else
	{
		bool b = false;
		CString str;
		int w;
		for (int i = word.GetLength(); i < s.GetLength(); ++i)
		{
			if(s.GetAt(i) != ' ')
			{
				if(b == false)
				{
					b = true;
					for (w = i; w < s.GetLength(); ++w)
					{
						if(s.GetAt(w) != ' ')
						{
							str.Insert(str.GetLength(), s.GetAt(w));
						}
						else
							w = s.GetLength();
							
					}
				}
			}
		}
		b = false;
		if ((str == "db")||(str == "DB"))
		{
			int len = str.GetLength() + word.GetLength() + 1;
			str = "";
			for (w = len + 1; w < s.GetLength(); ++w)
			{
				if(s.GetAt(w) != ' ')
				{
					str.Insert(str.GetLength(), s.GetAt(w));
				}
				else
					w = s.GetLength();		
			}
			int db;
			db = _wtoi((LPCTSTR)str);
			if (db == 0)
			{
				AfxMessageBox((LPCTSTR)L"Varriable difinition isn't right");
				error = true;
				return;
			}
			else
			{
				if(SymTab->GetCount() != 0)
				{
					int len = word.GetLength() - 1;
					word.Delete(len, 1);
					for (int i = 0; i < SymTab->GetCount(); ++i)
					{
						if (word == *SymTab->GetByIndex(i))
						{
							AfxMessageBox((LPCTSTR)L"Redifine variable");
							error = true;
							return;
						}		
					}
					SymTab->AddLast(word);
					++length;
					SymTab_addr->AddLast(*list_addr->GetByIndex(list_addr->GetCount() - 1));
					list_addr->AddLast(*SymTab_addr->GetByIndex(SymTab_addr->GetCount() - 1) + 1);
					SymTab_value->AddLast(db);
				}
				else
				{
					word.Delete(word.GetLength() - 1, 1); 
					SymTab->AddLast(word);
					++length;
					SymTab_addr->AddLast(*list_addr->GetByIndex(list_addr->GetCount() - 1));
					list_addr->AddLast(*SymTab_addr->GetByIndex(list_addr->GetCount() - 1) + 1);
					SymTab_value->AddLast(db);
				}
			}
		}
		else
		{
			AfxMessageBox((LPCTSTR)L"Varriable difinition isn't right");
			error = true;
			return;
		}
	}
}

void Operation(CString s, CString word)
{
	bool b = false;
	int w = 0; 
	for (int i = 0; i < 3; ++i)
	{
		if(word == OpTab[i].pname)
		{
			b = true;
			w = i;
		}
	}
	if(b)
	{
		if(label_start == "")
		{
			AfxMessageBox((LPCTSTR)L"Operation situated outside of code");
			error = true;
			return;
		}
		else
		{
			length = length + OpTab[w].iLength;
			list_addr->AddLast(OpTab[w].iLength + *list_addr->GetByIndex(list_addr->GetCount() - 1));
		}
	}
	else
	{
		if((word == "END")||(word == "end"))
		{
			if(label_start == "")
			{
				AfxMessageBox((LPCTSTR)L"Cann't use operation END without enter a program");
				error = true;
				return;
			}
			else
			{
				CString str;
				for (int i = word.GetLength(); i < s.GetLength(); ++i)
				{
					if(s.GetAt(i) != ' ')
					{
						if(b == false)
						{
							b = true;
							for (w = i; w < s.GetLength(); ++w)
							{
								if(s.GetAt(w) != ' ')
								{
									str.Insert(str.GetLength(), s.GetAt(w));
								}
									else
										w = s.GetLength();
							}
						}
					}
				}
				if (str == label_start)
				{
					b = false;
					if(list_i != numb - 1)
					{
						AfxMessageBox((LPCTSTR)L"Code after END willn't reading");
						list_i  = numb;
						end = true;
						return;
					}
					else
					{
						if (s.GetLength() != (str.GetLength() + word.GetLength() + 1))
						{
							for (w = str.GetLength() + word.GetLength() + 1; w < s.GetLength(); w++)
							{
								if (s.GetAt(w) != ' ')
								{
									if (b == false)
									{
										if (s.GetAt(w) == ';')//не комментарий ли
										{
											b = true;
											end = true;
										}
										else 
										{
											AfxMessageBox((LPCTSTR)L"Wrong use of operator END");
											error = true;
											return;
										}
									}
								}
							}
						}
						else
						{
							end = true;
						}
					}
				}
				else
				{
					AfxMessageBox((LPCTSTR)L"Name of beginning and end of program doesn't coincide");
					error = true;
					return;
				}
			}
		}
		else
		{
			AfxMessageBox((LPCTSTR)L"Unknown code of operation");
			error = true;
			return;
		}
	}
}
void CasmDlg::OnBnClickedTranslate()
{
	SymTab = new CMyList<CString>;
	SymTab_addr = new CMyList<int>;
	list_addr = new CMyList<int>;
	first = true;
	start = false;
	CString s;
	numb = m_list1.GetCount();
	int i = 0;
	int w = 0;
	UINT nType = MB_OK;
	UINT nIDHelp = 0;
	for (list_i = 0; list_i < numb; ++list_i)
	{
		CString word;
		m_list1.GetText(list_i, s);
		bool b = false;
		for (w = 0; w < s.GetLength(); w++)
		{
			if (s.GetAt(w) == ' ')
				b = true;
			int len = word.GetLength();
			if (b == false)
				word.Insert(len, s.GetAt(w));
		}
		if (first)
		{
			ORG_Adress(s, word);
			if (error)
				return;
		}
		else
		{
			if(s.GetAt(0) != ';')
			{ 
				if (word.GetAt(word.GetLength() - 1) == ':')
				{
					Label(s, word);
					if (error)
						return;
				}
				else
				{
					Operation(s, word);
					if (error)
						return;
				}
			}
		}
	}
	if (end == false)
	{
		AfxMessageBox((LPCTSTR)L"Operator END wasn't use");
		return;
	}
	first = true;
	int index = 0; 
	for (list_i = 0; list_i < numb; ++list_i)
	{
		CString word;
		m_list1.GetText(list_i, s);
		if(s.GetAt(0) != ';')
		{
			if (first)
			{
				CString str("Head Org ");
				char *buf;
				buf = new char[20];
				--length;
				itoa(length, buf, 16);
				//itoa(length, buf, 16);
				for (int i = 0; i < 2; ++i)
				{
					str.Insert(str.GetLength(), buf[i]);	
				}
				m_list2.AddString(str);
				first = false;
			}
			else
			{
				bool b = false;
				CString word;
				for (w = 0; w < s.GetLength(); w++)
				{
					if (s.GetAt(w) == ' ')
						b = true;
					int len = word.GetLength();
					if (b == false)
						word.Insert(len, s.GetAt(w));
				}
				if (word.GetAt(word.GetLength() - 1) == ':')
				{
					if (word.GetLength() != s.GetLength())
					{
						w = 0;
						for (int i = 0; i < SymTab->GetCount(); ++i)
						{
							if (*SymTab->GetByIndex(i) == word)
							{
								w = i;
								i = SymTab->GetCount();
							}
						}
						CString str("Code  ");
						int addr = *list_addr->GetByIndex(index);
						++index;
						char *buf;
						buf = new char[20];
						itoa(addr, buf, 16);
						for (int i = 0; i < 2; ++i)
						{
							str.Insert(5 + i, buf[i]);	
						}
						buf = new char[20];
						addr = *SymTab_value->GetByIndex(w);
						itoa(addr, buf, 16);
						CString s_b;
						for (int i = 0; i < 2; ++i)
						{
							str.Insert(str.GetLength(), buf[i]);	
						}
						//str = str + ' ';///////////////////////////!!!!!!!!!!!!!!!!!!!!!1
						//str = str + s_b;
						//str.Insert(str.GetLength(), s_b);
						m_list2.AddString(str);
					}
				}
				else
				{
					if((word == "END")||(word == "end"))
					{
						CString str("END ");
						int l = *list_addr->GetByIndex(0);
						char *buf = new char[20];
						itoa(l, buf, 16);
						for (int i = 0; i < 2; ++i)
						{
							str.Insert(str.GetLength(), buf[i]);	
						}
						m_list2.AddString(str);
					}
					else
					{
						w = -1;
						if(word == "MOV")
						{
							for (int i = 4; i < s.GetLength(); ++i)
							{
								if(s.GetAt(i) == ',')
								{
									w = i;
									i = s.GetLength();
								}
							}
							if(w == -1)
							{
								AfxMessageBox((LPCTSTR)L"Wrong use of operator MOV");
								return;
							}
							else
							{
								CString s_digit;
								for (int i = w + 2; i < s.GetLength(); ++i)
								{
									s_digit.Insert(s_digit.GetLength(), s.GetAt(i));
									if(s.GetAt(i) == ' ')
										i = s.GetLength();
								}
								int digit = _wtoi((LPCTSTR)s_digit);
								if(digit != 0)
								{
									CString str("Code  01 ");
									int l = *list_addr->GetByIndex(index);
									++index;
									char *buf = new char[20];
						 			itoa(l, buf, 16);
									for (int i = 0; i < 2; ++i)
									{
										str.Insert(5 + i, buf[i]);	
									}
									buf = new char[20];
									itoa(digit, buf, 16);
									for (int i = 0; i < 2; ++i)
									{
										str.Insert(str.GetLength(), buf[i]);	
									}
									m_list2.AddString(str);
								}
								else
								{
									bool b = false;
									w = 0;
									for (int i = 0; i < SymTab->GetCount(); ++i)
									{
										if (*SymTab->GetByIndex(i) == s_digit)
										{
											w = i;
											i = SymTab->GetCount();
											b = true;
										}
									}
									if(b == false)
									{
										AfxMessageBox((LPCTSTR)L"Wrong use of operator MOV");
										return;
									}
									else
									{
										CString str("Code  01 ");
										int addr = *list_addr->GetByIndex(index);
										++index;
										char *buf = new char[20];
						 				itoa(addr, buf, 16);
										for (int i = 0; i < 2; ++i)
										{
											str.Insert(5 + i, buf[i]);	
										}
										int digit = *SymTab_addr->GetByIndex(w);
										buf = new char[20];
										itoa(digit, buf, 16);
										for (int i = 0; i < 2; ++i)
										{
											str.Insert(str.GetLength(), buf[i]);	
										}
										m_list2.AddString(str);
									}
								}
							}
						}
						if(word == "INT")
						{
							CString s_digit;
							for (int i = 4; i < s.GetLength(); ++i)
							{
								s_digit.Insert(s_digit.GetLength(), s.GetAt(i));
							}
							int digit = _wtoi((LPCTSTR)s_digit);
							if(digit != 0)
							{
								CString str("Code  02 ");
								int l = *list_addr->GetByIndex(index);
								++index;
								char *buf = new char[20];
						 		itoa(l, buf, 16);
								for (int i = 0; i < 2; ++i)
								{
									str.Insert(5 + i, buf[i]);	
								}
								buf = new char[20];
								itoa(digit, buf, 16);
								for (int i = 0; i < 2; ++i)
								{
									str.Insert(str.GetLength(), buf[i]);	
								}
								m_list2.AddString(str);
							}
							else
							{
								AfxMessageBox((LPCTSTR)L"Wrong use of operator INT");
								return;
							}
						}
						if(word == "RET")
						{
							if(word.GetLength() == s.GetLength())
							{
								CString str("Code  03");
								char *buf = new char[20];
								int addr = *list_addr->GetByIndex(index);
								++index;
								itoa(addr, buf, 16);
								for (int i = 0; i < 2; ++i)/////////////!!!!!!!!!!!!!!!!!!!
								{
									str.Insert(5 + i, buf[i]);	
								}
								m_list2.AddString(str);
							}
							else
							{
								AfxMessageBox((LPCTSTR)L"Wrong use of operator RET");
								return;
							}
						}
					}
				}
			}
		}
	}
}
