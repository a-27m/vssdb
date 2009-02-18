#pragma once

// LabActiveCtrl.h : Declaration of the CLabActiveCtrl ActiveX Control class.


// CLabActiveCtrl : See LabActiveCtrl.cpp for implementation.

class CLabActiveCtrl : public COleControl
{
	DECLARE_DYNCREATE(CLabActiveCtrl)

// Constructor
public:
	CLabActiveCtrl();

protected:
	float ** u; // the 2D matrix for calculating U(x,t)
	float *xx;
	int T;	int N;

// Other methods
public:
	int snapshotTimeIndex;
	void Рассчитать(
		float x1,
		float x2,
		float t1,
		float t2,
		float **f,		// u(x, t1) = f(x, t)
		float *mju1,	// u(x1, t) = mju1(t)
		float *mju2,	// u(x2, t) = mju1(t)
		float h, float tau);

// Overrides
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();

// Implementation
protected:
	~CLabActiveCtrl();

	DECLARE_OLECREATE_EX(CLabActiveCtrl)    // Class factory and guid
	DECLARE_OLETYPELIB(CLabActiveCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CLabActiveCtrl)     // Property page IDs
	DECLARE_OLECTLTYPE(CLabActiveCtrl)		// Type name and misc status

// Message maps
	DECLARE_MESSAGE_MAP()

// Dispatch maps
	DECLARE_DISPATCH_MAP()

// Event maps
	DECLARE_EVENT_MAP()

// Dispatch and event IDs
public:
	enum {
	};
	void Animate(float speed);
};

