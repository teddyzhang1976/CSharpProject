using System;
using System.Diagnostics.Contracts;

namespace Wrox.ProCSharp.Diagnostics
{
    [ContractClassFor(typeof(IPerson))]
    public abstract class PersonContract : IPerson
    {
        string IPerson.FirstName
        {
            get { return Contract.Result<String>(); }
            set { Contract.Requires(value != null); }
        }
        string IPerson.LastName
        {
            get { return Contract.Result<String>(); }
            set { Contract.Requires(value != null); }
        }
        int IPerson.Age
        {
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
