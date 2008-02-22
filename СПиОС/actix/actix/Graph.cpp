// Graph.cpp : implementation file
//
#include "stdafx.h"
#include "actix.h"
#include "Graph.h"
#include "math.h"

#pragma warning( disable:  4244)
// CGraph
IMPLEMENT_SERIAL( CGraph, CObject, 1 )

CGraph::CGraph()
{
	cities	= new CMyList<CCity>;
	Anchor	= NULL;
	props	= new GRAPHPROPS;
	sizeTotal.SetSize(1,1);
}

CGraph::~CGraph()
{
	delete cities;
	delete props;
}
//
//         -----====SHOW====----- 
//	all
void CGraph::Show(Graphics * gr)
{
	ShowPipes(gr);
	ShowLabels(gr);
	ShowCities(gr);
	ShowAnchor(gr);
}
void CGraph::ShowPipes(Graphics* gr)
{
      Pen pen(	Color(FromRGB(props->pipeColor, 220)));

	  pen.SetWidth(2.0F);
	  gr->SetSmoothingMode(SmoothingModeHighQuality );

	for(  CMyList<CCity>::Iterator i (cities);
		  !i.EOL;
		  i.GoNext() )
	{
		CPoint a1 = i.GetCurrent()->data.coord;
		for(	CMyList<CPipe>::Iterator j (i.GetCurrent()->data.pipes);
			!j.EOL;
			j.GoNext() )
		{
			CPoint a2 = j.GetCurrent()->data.destination->coord;
			gr->DrawLine(&pen, a1.x, a1.y, a2.x, a2.y);
		}
	}

}
//	cities, cities->pipes
void CGraph::ShowLabels(Graphics* gr)
{
	Pen pen( Color( FromRGB( props->pipeColor)));
	SolidBrush brush( Color( FromRGB( props->bkColor)));
	SolidBrush fnt_brush( Color(0,0,0));


	StringFormat format;
	format.SetAlignment(StringAlignmentCenter );
	format.SetLineAlignment(StringAlignmentCenter);

	RectF bounds(0, 0, 1, 1);

	Font font(L"Arial", 10);

	gr->SetSmoothingMode(SmoothingModeHighSpeed );
	//gr->SetTextRenderingHint(TextRenderingHintAntiAlias);

	int R = props->radius;
	CString s;
	for(  CMyList<CCity>::Iterator i (cities);
		!i.EOL;
		i.GoNext() )
	{
		CPoint a1 = i.GetCurrent()->data.coord;
		for(CMyList<CPipe>::Iterator j (i.GetCurrent()->data.pipes);
			!j.EOL;
			j.GoNext() )
		{
			CPoint a2 = j.GetCurrent()->data.destination->coord;
			
			s.Format(L"%.1f",j.GetCurrent()->data.cost);
			RectF bounds( (a1.x+a2.x)/2-R, (a1.y+a2.y)/2-R, 2+s.GetLength()*font.GetSize(), 2*R);

			gr->FillRectangle(&brush, bounds);
			gr->DrawRectangle(&pen, bounds);
			gr->DrawString(s, -1, &font, bounds, &format, &fnt_brush);
		}
	}
}
//	cities
void CGraph::ShowCities(Graphics* gr) 
{
	int R = props->radius;
	SolidBrush brush(Color(FromRGB(props->ctyColor) )	);

    Pen pen(	Color(FromRGB(props->pipeColor)		));

	RectF bounds(0, 0, 1, 1);

	// Готовим формат и параметры шрифта
	StringFormat format;
	format.SetAlignment(StringAlignmentNear );
	format.SetLineAlignment(StringAlignmentNear);

	Font font(L"Arial", 12, FontStyleBold);

	gr->SetSmoothingMode(SmoothingModeHighQuality );

	for(  CMyList<CCity>::Iterator i (cities);
		!i.EOL;
		i.GoNext() )
	{
		CPoint  point = i.GetCurrent()->data.coord;
		CString s     = i.GetCurrent()->data.GetName();


		RectF bounds(point.x+R, point.y,
			s.GetLength()*font.GetSize(),
			font.GetSize()*2 );
		
		LinearGradientBrush fnt_brush(bounds,
			Color(FromRGB(props->ctyColor,220)),
			Color(FromRGB(props->pipeColor,240)),
			LinearGradientModeHorizontal	);

		gr->SetTextRenderingHint(TextRenderingHintAntiAlias);
		gr->FillEllipse(& brush, point.x-R, point.y-R, 2*R, 2*R); 
		gr->DrawEllipse(& pen,	 point.x-R, point.y-R, 2*R, 2*R); 
		gr->DrawString(s, -1, &font, bounds, &format, &fnt_brush);

	}
}
//	anchor
void CGraph::ShowAnchor(Graphics* gr) 
{
	if (Anchor == NULL) return;
 
	Pen pen(	Color(FromRGB(props->ctyColor)		));
	SolidBrush brush(	Color(FromRGB(props->pipeColor)		));

	int R = props->radius;
	gr->FillEllipse(& brush, Anchor->coord.x-R, Anchor->coord.y-R, 2*R, 2*R); 
	gr->DrawEllipse(& pen,	 Anchor->coord.x-R, Anchor->coord.y-R, 2*R, 2*R); 
}
// chain
void CGraph::ShowChain(Graphics* gr, CMyList<CCity>* list) 
{
	if (!list->GetCount()) return;

	COLORREF pipeColor	= (int)0x00ffffff - (int)props->ctyColor;
	COLORREF ctyColor	= (int)0x00ffffff - (int)props->pipeColor;

	Pen pen(	Color(FromRGB(pipeColor, 220)));
	pen.SetWidth(2.5F);

	int R = props->radius;
	SolidBrush brush( Color( FromRGB( ctyColor)));

	gr->SetSmoothingMode(SmoothingModeHighQuality );

	CMyList<CCity>::Iterator i (list);
	CPoint a1 = i.GetCurrent()->data.coord;
	for(;!i.EOL;i.GoNext() )
	{
		CPoint a2 = i.GetCurrent()->data.coord;
		gr->DrawLine	(& pen,		a1.x,	a1.y,	a2.x,	a2.y);
		// draw cost i.GetCurrent()->data.
		gr->FillEllipse	(& brush,	a2.x-R,	a2.y-R,	2*R,	2*R); 
		gr->DrawEllipse	(& pen,		a2.x-R,	a2.y-R,	2*R,	2*R); 

		a1 = a2;
	}
}
//
void CGraph::_toGraph(CGraph *pGr, CCity *cty, CMetka* Label)
{
	pGr->cities->~CMyList();
	CMyList<CCity>* pCtys = new CMyList<CCity>;
	pGr->cities = pCtys;

	pGr->AddCity( CCity(
		cty->coord,
		cty->name
		));
	if (cty->ZIP[Label].prev)
	{
	pGr->AddCity( CCity(
		cty->ZIP[Label].prev->coord,
		cty->ZIP[Label].prev->name
		));
		pGr->AddPipe(
			pGr->cities->GetByIndex(pGr->cities->GetCount()-2),
			pGr->cities->GetByIndex(pGr->cities->GetCount()-1),
			cty->ZIP[Label].sum_cost
			);
		while (cty->ZIP[Label].prev)
		{
			pGr->AddCity(  CCity(
				cty->ZIP[Label].prev->coord,
				cty->ZIP[Label].prev->name
				));
			pGr->AddPipe(
				pGr->cities->GetByIndex(pGr->cities->GetCount()-2),
				pGr->cities->GetByIndex(pGr->cities->GetCount()-1),
				cty->ZIP[Label].sum_cost
				);
			cty = cty->ZIP[Label].prev;
		}
		//SendMessage(hWnd, msg, 0, DIJKSTRA_STEP);
	}
}

void CGraph::_dijk(CGraph* pGrf, CCity* ctyT, CMetka* Label, HWND hWnd, UINT msg)
{
	ctyT->ZIP[Label].IsVar = false;
	for(CMyList<CPipe>::Iterator i(ctyT->pipes); !i.EOL;i.GoNext())
	{
		//if (i.GetCurrent()->data.destination->ZIP[Label].IsVar)
		//{
			if (	i.GetCurrent()->data.destination->ZIP[Label].sum_cost >
				(ctyT->ZIP[Label].sum_cost + i.GetCurrent()->data.cost)
				)
			{
				i.GetCurrent()->data.destination->ZIP[Label].sum_cost = 
					ctyT->ZIP[Label].sum_cost + i.GetCurrent()->data.cost;
				i.GetCurrent()->data.destination->ZIP[Label].prev = ctyT;
				_toGraph(pGrf, i.GetCurrent()->data.destination, Label);
				SendMessage(hWnd, msg, 0, DIJKSTRA_STEP);
			}
	}
	for(CMyList<CPipe>::Iterator i(ctyT->pipes); !i.EOL;i.GoNext())
	{

			if (i.GetCurrent()->data.destination->ZIP[Label].IsVar)
				_dijk(pGrf, i.GetCurrent()->data.destination, Label, hWnd, msg);
	}
		//}
}
//	Dijkstra algorithm realization
void CGraph::Dijkskra(CCity* ctyA, CCity* ctyB,
					  CGraph* pResult,  HWND hWnd, UINT msg)
{
	const int n = this->cities->GetCount();
	CMetka* Label = new CMetka[n];

	IndexCities();
	pResult->cities->~CMyList();
	CMyList<CCity>* pCtys = new CMyList<CCity>;
	pResult->cities = pCtys;

	pResult->props->pipeColor	= (int)0x00ffffff - (int)props->ctyColor;
	pResult->props->ctyColor	= (int)0x00ffffff - (int)props->pipeColor;

	ctyA->ZIP[Label].sum_cost = 0.0;
	//ctyA->ZIP[Label].IsVar = false;

	_dijk(pResult, ctyA, Label, hWnd, msg);

	_toGraph(pResult, ctyB, Label);
	SendMessage(hWnd, msg, 0, DIJKSTRA_DONE);

}

	/*
	while (stack.GetCount())
	{
		//double min_cost = MAX_COST;
		t = *stack.GetByIndex(0);
		stack.RemoveFirst();
		//if (t1 == ctyB) break;
		for(CMyList<CPipe>::Iterator i(t->pipes);!i.EOL;i.GoNext())
		{
			CPipe* curr = & i.GetCurrent()->data;
			if (curr->destination->ZIP[Label].IsVar) 
			{// if variable label
				if ( curr->destination->ZIP[Label].sum_cost >
					t->ZIP[Label].sum_cost + curr->cost )
				{
					curr->destination->ZIP[Label].sum_cost =
						t->ZIP[Label].sum_cost + curr->cost;
					curr->destination->ZIP[Label].prev = t;
					// draw step
					pResult->cities->~CMyList();
					CMyList<CCity>* pCtys = new CMyList<CCity>;
					pResult->cities = pCtys;

					pResult->AddCity( CCity(
						t->coord,
						t->name
						));
					if (t->ZIP[Label].prev)
					{
						pResult->AddPipe(t,t->ZIP[Label].prev, t->ZIP[Label].sum_cost);
						while (t->ZIP[Label].prev)
						{
							pResult->AddCity( CCity(
								t->ZIP[Label].prev->coord,
								t->ZIP[Label].prev->name
								));
							pResult->AddPipe(t,t->ZIP[Label].prev, t->ZIP[Label].sum_cost);
							t = t->ZIP[Label].prev;
						}
						SendMessage(hWnd, msg, 0, DIJKSTRA_STEP);
					}
				}
				stack.AddFirst(curr->destination);
				//if ((curr->cost < min_cost)&&(curr->destination->ZIP[Label].IsVar))
				//{
				//	min_cost = curr->cost;
				//	t1 = curr->destination;
				//}
			}
		}
		//if (min_cost==MAX_COST) goto abc;
		//t->ZIP[Label].IsVar = false;

	}
abc:
	pResult->AddCity( CCity(
		t->coord,
		t->name
		));
	if (t->ZIP[Label].prev)
	{
		pResult->AddPipe(t,t->ZIP[Label].prev, t->ZIP[Label].sum_cost);

		while (t->ZIP[Label].prev)
		{
			pResult->AddCity( CCity(
				t->ZIP[Label].prev->coord,
				t->ZIP[Label].prev->name
				));
			pResult->AddPipe(t,t->ZIP[Label].prev, t->ZIP[Label].sum_cost);
			t = t->ZIP[Label].prev;
		}

		SendMessage(hWnd, msg, 0, DIJKSTRA_DONE);
	}*/
//

//         -----====OTHER====----- 
// resolves ZIP indexeas to normal pointers for every pipe of every city in the graph
void CGraph::ResolveZIPs()
{
	CCity* *pnt_mp = new CCity*[cities->GetCount()];

	for(CMyList<CCity>::Iterator i(cities);
		!i.EOL;
		i.GoNext())
	{
		pnt_mp[i.GetOffset()] = & (i.GetCurrent()->data);
	}

	for(CMyList<CCity>::Iterator i(cities);
		!i.EOL;
		i.GoNext())
		for(CMyList<CPipe>::Iterator j( i.GetCurrent()->data.pipes) ;
			!j.EOL;
			j.GoNext())
		{
			j.GetCurrent()->data.destination = pnt_mp[j.GetCurrent()->data.dest_ZIP];
		}
}

void CGraph::IndexCities(void)
{
	for(CMyList<CCity>::Iterator i(cities);
		!i.EOL;
		i.GoNext())
	{
		i.GetCurrent()->data.ZIP = i.GetOffset();
	}

	for(CMyList<CCity>::Iterator i(cities);
		!i.EOL;
		i.GoNext())

		for(CMyList<CPipe>::Iterator j( i.GetCurrent()->data.pipes) ;
			!j.EOL;
			j.GoNext())
		{
			j.GetCurrent()->data.dest_ZIP = j.GetCurrent()->data.destination->ZIP;
		}
}

//	save/restore
void CGraph::Serialize(CArchive& ar)
{
	CObject::Serialize( ar );

	if (ar.IsStoring() )
	{
		ar.Write(props, sizeof(GRAPHPROPS));
		IndexCities();
		ar<<*cities;
	}
	else
	{
		//props = new GRAPHPROPS;
		ar.Read(props, sizeof(GRAPHPROPS));
		ar>>*cities;
		ResolveZIPs();

		for(  CMyList<CCity>::Iterator i (cities);
		  !i.EOL;
		  i.GoNext() )
			UpdateSize(&i.GetCurrent()->data);
	}
}

//
//
CCity*	CGraph::Nearest(CPoint pick, double &min_d) 
{
//	CGraph::Nearest()
//	Searches the nearest city, farer than min_d
//		[in] CPoint pick
//		[in,out] double min_d
//		[out] return CCity*
	
	CCity * min_City = NULL;
	for(CMyList<CCity>::Iterator i(cities);
		!i.EOL;
		i.GoNext())
	{
		double d = sqrt( pow((double)(pick.x - i.GetCurrent()->data.coord.x),int(2)) + 
						 pow((double)(pick.y - i.GetCurrent()->data.coord.y),int(2))	);

		if (min_City == NULL)
		{
			min_City = & (i.GetCurrent()->data);
			min_d=d;
		}
		if (d<min_d)
		{
			min_d = d;
			min_City = & (i.GetCurrent()->data);
		}

	}
	return min_City;
}

int	CGraph::FindPipe(CPipe* pip,CMyList<CPipe>* list)
{
	for(CMyList<CPipe>::Iterator i(list); !i.EOL; i.GoNext() )
		if (i.GetCurrent()->data.destination ==
			pip->destination) return i.GetOffset();
	return NOT_FOUND_IN_LIST;

}
void CGraph::UpdateSize(CCity* cty)
{
/*	if ((cty->coord.x < props->radius) || 
		(cty->coord.y < props->radius))
	{

		for(CMyList<CCity>::Iterator i(cities);!i.EOL;i.GoNext)
		{

		}
	}
	*/
	if (cty->coord.x + cty->name.GetLength()*FONT_WIDTH >	sizeTotal.cx)
		sizeTotal.cx = cty->coord.x +
						2 * props->radius +
						cty->name.GetLength()*FONT_WIDTH;
	if (cty->coord.y > sizeTotal.cy)
		sizeTotal.cy = cty->coord.y +
						2 * props->radius;
}
//
GRAPHPROPS CGraph::GetProps(void)
{
	return *props;
}
void CGraph::SetProps(GRAPHPROPS GProps)
{
	*props = GProps;
}

//
Color CGraph::FromRGB(COLORREF rgbcolor, int alpha/* = 255*/)
{
	return Color(alpha,
BYTE((rgbcolor&(0x000000ff))),
BYTE((rgbcolor&(0x0000ff00))>>8),
BYTE((rgbcolor&(0x00ff0000))>>16));
}


//
void CGraph::AddPipe(CCity* cty1, CCity* cty2, double _cost/* = 1 */)
{
	CPipe pipe1 (cty2,_cost);
	CPipe pipe2 (cty1,_cost);
	if (cty1 == cty2) return;
	int index = FindPipe(&pipe1,cty1->pipes);
	if	( index == NOT_FOUND_IN_LIST )
	{
		cty1->pipes->AddLast(pipe1);
		cty2->pipes->AddLast(pipe2);
	}
	else
	{
		*cty1->pipes->GetByIndex(index) = pipe1;
		index = FindPipe(&pipe2,cty2->pipes);
		*cty2->pipes->GetByIndex(index) = pipe2;
	}
		 
}

void CGraph::AddCity(CCity dat)
{
	CMyList<CCity>::Iterator i(cities);
	for(;!i.EOL;i.GoNext())
	{
		if (i.GetCurrent()->data == dat) return;
	}
	cities->AddLast(dat);
	UpdateSize(&dat);
}
