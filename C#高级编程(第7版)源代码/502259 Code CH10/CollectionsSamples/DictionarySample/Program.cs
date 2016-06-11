using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main()
        {
            var employees = new Dictionary<EmployeeId, Employee>(31);

            var idKyle = new EmployeeId("T3755");
            var kyle = new Employee(idKyle, "Kyle Bush", 5443890.00m);
            employees.Add(idKyle, kyle);
            Console.WriteLine(kyle);

            var idCarl = new EmployeeId("F3547");
            var carl = new Employee(idCarl, "Carl Edwards", 5597120.00m);
            employees.Add(idCarl, carl);
            Console.WriteLine(carl);

            var idJimmie = new EmployeeId("C3386");
            var jimmie = new Employee(idJimmie, "Jimmie Johnson", 5024710.00m);
            employees.Add(idJimmie, jimmie);
            Console.WriteLine(jimmie);

            var idDale = new EmployeeId("C3323");
            var dale = new Employee(idDale, "Dale Earnhardt Jr.", 3522740.00m);
            employees[idDale] = dale;
            Console.WriteLine(dale);

            var idJeff = new EmployeeId("C3234");
            var jeff = new Employee(idJeff, "Jeff Burton", 3879540.00m);
            employees[idJeff] = jeff;
            Console.WriteLine(jeff);



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
