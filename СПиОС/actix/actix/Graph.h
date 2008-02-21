#pragma once

#include "MyList.h"
#include "City.h"

CMyList<CCity>;
//CMyList<CPipe>;
#define FONT_WIDTH	14
#define MAX_COST 1.7E+307
#define DIJKSTRA_DONE	0x00000001
#define DIJKSTRA_STEP	0x00000002
#define DIJKSTRA_FAIL	0x00000008

// CGraph command target
struct CMetka
{
	CCity*	prev;
	bool	IsVar;
	double	sum_cost;
	CMetka()
	{
		prev	= NULL;
		IsVar	= true;
		sum_cost = MAX_COST;
	}
};

struct GRAPHPROPS
{
	COLORREF bkColor;
	COLORREF ctyColor;
	COLORREF pipeColor;
	COLORREF fntColor;
	int		radius;

	GRAPHPROPS()
	{
		bkColor		= RGB(255,153,0);
		ctyColor	= RGB(250,20,10);
		pipeColor	= RGB(0,0,0);
		fntColor	= RGB(0,0,0);
		radius		= 10;
	}
};

class CGraph : public CObject
{
	DECLARE_SERIAL(CGraph)

	CMyList<CCity>* cities;
	CCity * Anchor;
	GRAPHPROPS* props;
	CSize	sizeTotal;

	//internal graph processing
	inline	void	ResolveZIPs(); // resolves ZIPindexes to usual pointers for every pipe of every city in the graph
	inline	void	IndexCities(void);

public:
	CGraph();
	virtual	~CGraph();
	void	Serialize(CArchive& ar);

public:
	CMyList<CCity>*	GetCities(void) {return cities;}
	GRAPHPROPS		GetProps(void);
	CCity *	GetAnchor(void)	{ return Anchor; }
	CSize	GetSize(void) {return sizeTotal;}

	void	SetProps(GRAPHPROPS GProps);
	void	SetAnchor(CCity * _an) { Anchor = _an; }
	void	SetSize(CSize csiz)	{sizeTotal = csiz;}

public:
	void	AddPipe(CCity*, CCity*, double _cost = 1);
	void	AddCity(CCity dat);

	void	Show		(Graphics*);
	void	ShowPipes	(Graphics*);
	void	ShowLabels	(Graphics*);
	void	ShowCities	(Graphics*);
	void	ShowAnchor	(Graphics*);
	void	ShowChain	(Graphics*, CMyList<CCity>*);

	CCity*	Nearest(CPoint pick, double &min_d) ;
	int		FindPipe(CPipe*,CMyList<CPipe>*);
	void	UpdateSize(CCity*);
	Color	FromRGB(COLORREF, int = 255);

	void	Dijkskra(CCity*, CCity*, CGraph*,  HWND, UINT);
protected:
	void	_dijk(CGraph*, CCity*, CMetka*, HWND, UINT);
	void	_toGraph(CGraph*, CCity*, CMetka*);
};