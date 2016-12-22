using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Collections
{
  class Program
  {
    static void Main()
    {
      var employees = new Dictionary<EmployeeId, Employee>(31);

      var idTony = new EmployeeId("C3755");
      var tony = new Employee(idTony, "Tony Stewart", 379025.00m);
      employees.Add(idTony, tony);
      Console.WriteLine(tony);

      var idCarl = new EmployeeId("F3547");
      var carl = new Employee(idCarl, "Carl Edwards", 403466.00m);
      employees.Add(idCarl, carl);
      Console.WriteLine(carl);

      var idKevin = new EmployeeId("C3386");
      var kevin = new Employee(idKevin, "Kevin Harwick", 415261.00m);
      employees.Add(idKevin, kevin);
      Console.WriteLine(kevin);

      var idMatt = new EmployeeId("F3323");
      var matt = new Employee(idMatt, "Matt Kenseth", 1589390.00m);
      employees[idMatt] = matt;
      Console.WriteLine(matt);

      var idBrad = new EmployeeId("D3234");
      var brad = new Employee(idBrad, "Brad Keselowski", 322295.00m);
      employees[idBrad] = brad;
      Console.WriteLine(brad);



      while (true)
      {
        Console.Write("Enter employee id (X to exit)> ");
        var userInput = Console.ReadLine();
        userInput = userInput.ToUpper();
        if (userInput == "X") break;

        EmployeeId id;
        try
        {
          id = new EmployeeId(userInput);


          Employee employee;
          if (!employees.TryGetValue(id, out employee))
          {
            Console.WriteLine("Employee with id {0} does not exist", id);
          }
          else
          {
            Console.WriteLine(employee);
          }
        }
        catch (EmployeeIdException ex)
        {
          Console.WriteLine(ex.Message);
        }
      }

    }
  }
}
