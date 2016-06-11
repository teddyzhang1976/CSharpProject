osql -S".\sqlexpress" -E -i StoredProcs.sql
csc /t:exe /debug+ /r:System.dll /r:System.Data.dll storedprocs.cs ..\login.cs