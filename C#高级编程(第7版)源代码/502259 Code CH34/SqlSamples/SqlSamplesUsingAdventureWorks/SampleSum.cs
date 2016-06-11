using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct SampleSum
{
    private int sum;

    public void Init()
    {
        sum = 0;
    }

    public void Accumulate(SqlInt32 Value)
    {
        sum += Value.Value;
    }

    public void Merge(SampleSum Group)
    {
        sum += Group.sum;
    }

    public SqlInt32 Terminate()
    {
        return new SqlInt32(sum);
    }
}
