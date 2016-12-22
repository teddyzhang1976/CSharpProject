// dllmain.h : Declaration of module class.

class CCOMServerModule : public ATL::CAtlDllModuleT< CCOMServerModule >
{
public :
	DECLARE_LIBID(LIBID_COMServerLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_COMSERVER, "{7716CF0E-6A3E-44B6-B369-2DDE0CE4F14F}")
};

extern class CCOMServerModule _AtlModule;
