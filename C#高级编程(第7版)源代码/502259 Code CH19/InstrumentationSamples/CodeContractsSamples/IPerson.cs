using System.Diagnostics.Contracts;

namespace Wrox.ProCSharp.Instrumentation
{
    [ContractClass(typeof(PersonContract))]
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        void ChangeName(string firstName, string lastName);
    }
}
