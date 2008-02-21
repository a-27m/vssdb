//#include "City.h"
#pragma once


class CCity;
// CPipe command target

class CPipe
{
	double cost;
	CCity * destination;
//protected:
	int dest_ZIP;		// for serialization purposes only

public:
// constr-destr
	CPipe();
	CPipe(int ZIP, double _cost);
	CPipe(CCity* cty, double _cost);
	CPipe(CPipe&);
	virtual ~CPipe();
// serialization & K°
	void operator= (const CPipe& srcPipe);
	bool operator== (const CPipe&) const;

	friend
		CArchive& operator<< (CArchive&, CPipe& Ob);
	friend
		CArchive& operator>> (CArchive&, CPipe& Ob);
	//void Serialize(CArchive &ar);

	friend class CGraph;
};


