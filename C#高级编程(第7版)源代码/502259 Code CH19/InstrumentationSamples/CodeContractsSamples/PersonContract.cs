using System;
using System.Diagnostics.Contracts;

namespace Wrox.ProCSharp.Instrumentation
{
    [ContractClassFor(typeof(IPerson))]
    public sealed class PersonContract : IPerson
    {
        string IPerson.FirstName
        {
            [Pure]
            get { return Contract.Result<String>(); }
            set { Contract.Requires(value != null); }
        }
        string IPerson.LastName
        {
            [Pure]
            get { return Contract.Result<String>(); }
            set { Contract.Requires(value != null); }
        }
        int IPerson.Age
        {
            [Pure]
            get
            { 
                Contract.Ensures(Contract.Result<int>() > 0 && Contract.Result<int>() < 121);
                return Contract.Result<int>();
            }
            set
            {
                Contract.Requires(value > 0 && value < 121);
            }
        }
        void IPerson.ChangeName(string firstName, string lastName)
        {
            Contract.Requires(firstName != null);
            Contract.Requires(lastName != null);
        }
    }
}
