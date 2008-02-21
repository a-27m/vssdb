// Pipe.cpp : implementation file
//

#include "stdafx.h"
//#include "PathMaker.h"
#include "Pipe.h"

// CPipe
CPipe::CPipe()
{
	cost = 0;
	dest_ZIP = -1;
	destination = NULL;
}

CPipe::CPipe(int ZIP, double _cost)
{
	cost = _cost;
	dest_ZIP = ZIP;
	destination = NULL;
}
CPipe::CPipe(CCity* cty, double _cost)
{
	cost = _cost;
	//dest_ZIP = cty->ZIP;
	dest_ZIP = -1;
	destination = cty;
}
CPipe::CPipe(CPipe&elem)
{
	cost = elem.cost;
	dest_ZIP = elem.dest_ZIP;
	destination = elem.destination;
}

CPipe::~CPipe(){}

void CPipe::operator= (const CPipe& srcPipe)
{
	cost = srcPipe.cost;
	dest_ZIP = srcPipe.dest_ZIP;
	destination = srcPipe.destination;
}

bool CPipe::operator== (const CPipe& srcPipe) const
{
	return (
		(srcPipe.cost == cost) &&
		(srcPipe.destination == destination)
			);
}
// CPipe member functions

CArchive& operator<< (CArchive& ar, CPipe& Ob)
{
	ar<<Ob.cost;
	ar<<Ob.dest_ZIP;
	return ar;
}
CArchive& operator>> (CArchive& ar, CPipe& Ob)
{
	ar>>Ob.cost;
	ar>>Ob.dest_ZIP;
	return ar;
}
//void CPipe::Serialize(CArchive &ar)
//{
//	if (ar.IsStoring())
//	{
//		ar<<cost;
//		ar<<dest_ZIP;
//	}
//	else
//	{
//		ar>>cost;
//		ar>>dest_ZIP;
//	}
//}
