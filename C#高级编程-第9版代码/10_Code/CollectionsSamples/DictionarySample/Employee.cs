using System;

namespace Wrox.ProCSharp.Collections
{
  [Serializable]
  public class Employee
  {
    private string name;
    private decimal salary;
    private readonly EmployeeId id;

    public Employee(EmployeeId id, string name, decimal salary)
    {
      this.id = id;
      this.name = name;
      this.salary = salary;
    }

    public override string ToString()
    {
      return String.Format("{0}: {1, -20} {2:C}",
            id.ToString(), name, salary);
    }
  }

}
