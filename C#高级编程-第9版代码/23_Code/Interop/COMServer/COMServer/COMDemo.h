// COMDemo.h : Declaration of the CCOMDemo

#pragma once
#include "resource.h"       // main symbols



#include "COMServer_i.h"
#include "_ICompletedEvents_CP.H"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

using namespace ATL;


// CCOMDemo

class ATL_NO_VTABLE CCOMDemo :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCOMDemo, &CLSID_COMDemo>,
	public IDispatchImpl<IWelcome, &IID_IWelcome, &LIBID_COMServerLib, /*wMajor =*/ 1, /*wMinor =*/ 0>,
	public IDispatchImpl<IMath, &IID_IMath, &LIBID_COMServerLib, 1, 0>,
	public IConnectionPointContainerImpl<CCOMDemo>,
	public CProxy_ICompletedEvents<CCOMDemo>
{
public:
	CCOMDemo()
	{
	}

	DECLARE_REGISTRY_RESOURCEID(IDR_COMDEMO)


	BEGIN_COM_MAP(CCOMDemo)
		COM_INTERFACE_ENTRY(IWelcome)
		COM_INTERFACE_ENTRY(IMath)
		COM_INTERFACE_ENTRY2(IDispatch, IWelcome)
		COM_INTERFACE_ENTRY(IConnectionPointContainer)
	END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:



	STDMETHOD(Greeting)(BSTR name, BSTR* message);
	STDMETHOD(Add)(long val1, long val2, long* result);
	STDMETHOD(Sub)(long val1, long val2, long* result);

	BEGIN_CONNECTION_POINT_MAP(CCOMDemo)
		CONNECTION_POINT_ENTRY(__uuidof(_ICompletedEvents))
	END_CONNECTION_POINT_MAP()
};

OBJECT_ENTRY_AUTO(__uuidof(COMDemo), CCOMDemo)
