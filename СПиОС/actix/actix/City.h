#pragma once

#include "Pipe.h"

// forward declaration
class CPipe;

// CCity command target
class CCity
{
		int		ZIP;
		CString	name;
		CMyList<CPipe>*	pipes;
	public:
		CPoint	coord;
		
public:
	CCity();
	CCity(const CCity&);
	CCity(CPoint _point, CString _name);

	virtual	~CCity();
	CString	GetName(void) {return name;}
	void	SetName(CString s) {name=s;}
	void	operator= (const CCity& srcCity);
	bool	operator== (const CCity&) const;

	friend CArchive& AFXAPI operator<< (CArchive&, CCity& Ob);
	friend CArchive& AFXAPI operator>> (CArchive&, CCity& Ob);
	//void Serialize(CArchive &ar);

	friend class CGraph;
};
