// COMDemo.cpp : Implementation of CCOMDemo

#include "stdafx.h"
#include "COMDemo.h"


// CCOMDemo



STDMETHODIMP CCOMDemo::Greeting(BSTR name, BSTR* message)
{
	CComBSTR tmp("Welcome, ");
	tmp.Append(name);
	*message = tmp;
	return S_OK;

}

STDMETHODIMP CCOMDemo::Add(LONG val1, LONG val2, LONG* result)
{
	*result = val1 + val2;
	Fire_Completed();
	return S_OK;
}

STDMETHODIMP CCOMDemo::Sub(LONG val1, LONG val2, LONG* result)
{
	*result = val1 - val2;
	Fire_Completed();
	return S_OK;
}
