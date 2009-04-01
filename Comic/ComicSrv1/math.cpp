//
// Math.cpp
//

#include <stdafx.h>
#include <windows.h>
#include "math.h"

//
// Math class implementation
//
// Constructors
Math::Math()
{
   m_lRef = 0;

   // Увеличить значение внешнего счетчика объектов
   InterlockedIncrement( &g_lObjs ); 
}

// The destructor
Math::~Math()
{
   // Уменьшить значение внешнего счетчика объектов
   InterlockedDecrement( &g_lObjs ); 
}

STDMETHODIMP Math::QueryInterface( REFIID riid, void** ppv )
{
    *ppv = 0;

    if ( riid == IID_IUnknown || riid == IID_IMath )
        *ppv = this;

    if ( *ppv )
    {
        AddRef();
        return( S_OK );
    }
    return (E_NOINTERFACE);
}

STDMETHODIMP_(ULONG) Math::AddRef()
{
   return InterlockedIncrement( &m_lRef );
}

STDMETHODIMP_(ULONG) Math::Release()
{
   if ( InterlockedDecrement( &m_lRef ) == 0 )
   {
      delete this;
      return 0;
   }

   return m_lRef;
}

STDMETHODIMP Math::Add( long lOp1, long lOp2, long* pResult )
{
   *pResult = lOp1 + lOp2;
   return S_OK;
}

STDMETHODIMP Math::Subtract( long lOp1, long lOp2, long* pResult )
{
   *pResult = lOp1 - lOp2;
   return S_OK;
}

STDMETHODIMP Math::Multiply( long lOp1, long lOp2, long* pResult )
{
   *pResult = lOp1 * lOp2;
   return S_OK;
}

STDMETHODIMP Math::Divide( long lOp1, long lOp2, long* pResult )
{
   *pResult = lOp1 / lOp2;
   return S_OK;
}

STDMETHODIMP Math::Interpol(int n, float* xi, float* yi, float x, /*out*/ float* y)
{
//	int n = sizeof(xi)/sizeof(xi[0]);

	double sum = 0;
	for (int k = 0; k <= n; k++)
	{
		double numerator = 1.0;
		double denominator = 1.0;
		for (int i = 0; i <= n; i++)
		{
			if (i == k) continue;
			if (xi[i] == xi[k]) continue;

			numerator *= (x - xi[i]);
			denominator *= (xi[k] - xi[i]);
		}

		sum += yi[k] * numerator / denominator;
	}
	
	*y = (float)sum;

   return S_OK;
}


MathClassFactory::MathClassFactory()
{
   m_lRef = 0;
}

MathClassFactory::~MathClassFactory()
{
}

STDMETHODIMP MathClassFactory::QueryInterface( REFIID riid, void** ppv )
{
   *ppv = 0;

   if ( riid == IID_IUnknown || riid == IID_IClassFactory )
      *ppv = this;

   if ( *ppv )
   {
      AddRef();
      return S_OK;
   }

   return(E_NOINTERFACE);
}

STDMETHODIMP_(ULONG) MathClassFactory::AddRef()
{
   return InterlockedIncrement( &m_lRef );
}

STDMETHODIMP_(ULONG) MathClassFactory::Release()
{
   if ( InterlockedDecrement( &m_lRef ) == 0 )
   {
      delete this;
      return 0;
   }

   return m_lRef;
}



STDMETHODIMP MathClassFactory::CreateInstance
     ( LPUNKNOWN pUnkOuter, REFIID riid, void** ppvObj )
{
   Math*      pMath;
   HRESULT    hr;

   *ppvObj = 0;

   pMath = new Math;

   if ( pMath == 0 )
      return( E_OUTOFMEMORY );

   hr = pMath->QueryInterface( riid, ppvObj );

   if ( FAILED( hr ) )
      delete pMath;

   return hr;
}

STDMETHODIMP MathClassFactory::LockServer( BOOL fLock )
{
   if ( fLock )
      InterlockedIncrement( &g_lLocks ); 
   else
      InterlockedDecrement( &g_lLocks );

    return S_OK;
}
