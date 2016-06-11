// dllmain.h : Declaration of module class.

class CCOMServerModule : public ATL::CAtlDllModuleT< CCOMServerModule >
{
public :
	DECLARE_LIBID(LIBID_COMServerLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_COMSERVER, "{CED2993C-15A1-486F-915F-0045B394313B}")
};

extern class CCOMServerModule _AtlModule;
