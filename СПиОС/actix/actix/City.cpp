// City.cpp : implementation file
//

#include "stdafx.h"
//#include "PathMaker.h"
#include "MyList.h"
#include "City.h"
#include "Pipe.h"


// CCity
CCity::CCity()
{
	coord = CPoint(0,0);
	name = CString("");
	pipes = new CMyList<CPipe>;
}

CCity::CCity(CPoint _point, CString _name)
{
	coord = _point;
	name = _name;
	pipes = new CMyList<CPipe>;
}

CCity::CCity(const CCity& exemplar)
{
	coord = exemplar.coord;
	name = exemplar.name;
	ZIP = exemplar.ZIP;
	pipes = exemplar.pipes;
}

CCity::~CCity()
{
	//delete pipes; // NB!
}

void CCity::operator= (const CCity& srcCity)
{
	name = srcCity.name;
	coord = srcCity.coord;
	pipes = srcCity.pipes;
	ZIP = srcCity.ZIP;
}

bool CCity::operator== (const CCity& srcCity) const
{
	return (	(srcCity.coord.x == coord.x) &&
				(srcCity.coord.y == coord.y) &&
				(srcCity.name	 ==	name)	 &&
				(srcCity.ZIP	 ==	ZIP )	);
}
 //CCity member functions
CArchive& AFXAPI operator<< (CArchive& ar, CCity& Ob)
{
	ar<<Ob.coord.x<<Ob.coord.y;
	ar<<Ob.name;
	ar<<Ob.ZIP;
	ar<<*(Ob.pipes);
	return ar;
}
CArchive& AFXAPI operator>> (CArchive& ar, CCity& Ob)
{
	ar>>Ob.coord.x>>Ob.coord.y;
	ar>>Ob.name;
	ar>>Ob.ZIP;
	ar>>*(Ob.pipes);
	return ar;
}
//void CCity::Serialize(CArchive &ar)
//{
//	if (ar.IsStoring())
//	{
//		ar<<coord.x<<coord.y;
//		ar<<name;
//		ar<<ZIP;
//		ar<<*pipes;
//	}
//	else
//	{
//		ar>>coord.x>>coord.y;
//		ar>>name;
//		ar>>ZIP;
//		ar>>*pipes;
//	}
//}
