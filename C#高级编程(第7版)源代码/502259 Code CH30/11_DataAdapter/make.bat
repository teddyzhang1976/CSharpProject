osql -S".\sqlexpress" -E -i StoredProc.sql
csc /t:exe /debug+ /r:System.dll /r:System.Data.dll dataadapter.cs ..\login.cs