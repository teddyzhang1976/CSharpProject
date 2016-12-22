// COMClient.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#import "../DotNetServer/bin/debug/DotnetServer.tlb" named_guids

using namespace std;
using namespace DotnetServer;


class CEventHandler: public IDispEventImpl<4, CEventHandler,
	&DIID_IMathEvents, &LIBID_DotnetServer, 1, 0>
{
public:
	BEGIN_SINK_MAP(CEventHandler)
		SINK_ENTRY_EX(4, DIID_IMathEvents, 46200, OnCalcCompleted)
	END_SINK_MAP()

	HRESULT __stdcall OnCalcCompleted()
	{
		cout << "calculation completed" << endl;
		return S_OK;
	}
};


int _tmain(int argc, _TCHAR* argv[])
{
	HRESULT hr;
	hr = CoInitialize(NULL);

	try
	{
		IWelcomePtr spWelcome;

		// CoCreateInstance()
		hr = spWelcome.CreateInstance("Wrox.DotnetComponent");

		IUnknownPtr spUnknown = spWelcome;

		cout << spWelcome->Greeting("Bill") << endl;

		CEventHandler* eventHandler = new CEventHandler();
		hr = eventHandler->DispEventAdvise(spUnknown);

		IMathPtr spMath;
		spMath = spWelcome;   // QueryInterface()

		long result = spMath->Add(4, 5);
		cout << "result:" << result << endl;

		eventHandler->DispEventUnadvise(spWelcome.GetInterfacePtr());
		delete eventHandler;

	}
	catch (_com_error& e)
	{
		cout << e.ErrorMessage() << endl;
	}

	CoUninitialize();


	return 0;
}

