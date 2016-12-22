using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;

namespace DynamicFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new DynamicFileHelper();
            var employeeList = helper.ParseFile("EmployeeList.txt");
            foreach (var employee in employeeList)
            {
                Console.WriteLine(string.Format("{0} {1} lives in {2} {3}.",
                    employee.FirstName,
                    employee.LastName, 
                    employee.City, 
                    employee.State));
            }
            Console.ReadLine();
        }
    }

    public class DynamicFileHelper
    {

        public IList<dynamic> ParseFile(string fileName)
        {
            var retList = new List<dynamic>();
            var fileStream = OpenFile(fileName);
            if(fileStream != null)
            {
                string[] headerLine = fileStream.ReadLine().Split(',');
                while (fileStream.Peek() > 0)
                {
                    string[] dataLine = fileStream.ReadLine().Split(',');
                    dynamic dynamicEntity = new ExpandoObject();
                    for(int i=0;i<headerLine.Length;i++)
                    {
                        ((IDictionary<string,object>)dynamicEntity).Add(headerLine[i],dataLine[i]);
                    }
                    retList.Add(dynamicEntity);
                }
            }
            return retList;
        }

        private StreamReader OpenFile(string fileName)
        {
            if(File.Exists(fileName))
            {
                return new StreamReader(fileName);
            }
            return null;
        }
    }
}
