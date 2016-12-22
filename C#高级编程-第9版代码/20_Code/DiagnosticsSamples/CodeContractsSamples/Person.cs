
namespace Wrox.ProCSharp.Diagnostics
{
    public class Person : IPerson
    {
        #region IPerson Members

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }


        public void ChangeName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        #endregion
    }
}
