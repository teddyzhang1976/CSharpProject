using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Wrox.ProCSharp.SqlServer
{
    class Program
    {
        static void Main()
        {
            // XmlReaderDemo();
            // XmlDocumentDemo();
            EFDemo();

        }

        static void EFDemo()
        {
            using (ExamsEntities data = new ExamsEntities())
            {
                foreach (Exam item in data.Exams)
                {
                    XElement exam = XElement.Parse(item.Info);
                    Console.WriteLine("Exam: {0}", exam.Attribute("Number").Value);
                    Console.WriteLine("Title: {0}", exam.Element("Title").Value);
                    Console.Write("Course(s): ");
                    foreach (var course in exam.Elements("Course"))
                    {
                        Console.Write("{0} ", course.Value);
                    }
                    Console.WriteLine();
                }

            }
        }

        static void XmlDocumentDemo()
        {
            string connectionString =
       @"server=(local);database=SqlServerSampleDB;trusted_connection=true";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Number, Info FROM Exams";
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                SqlXml xml = reader.GetSqlXml(2);
                var doc = new XmlDocument();
                doc.LoadXml(xml.Value);

                XmlNode examNode = doc.SelectSingleNode("//Exam");
                Console.WriteLine("Exam: {0}", examNode.Attributes["Number"].Value);
                XmlNode titleNode = examNode.SelectSingleNode("./Title");
                Console.WriteLine("Title: {0}", titleNode.InnerText);
                Console.Write("Course(s): ");

                foreach (XmlNode courseNode in examNode.SelectNodes("./Course"))
                {
                    Console.Write("{0} ", courseNode.InnerText);
                }
                Console.WriteLine();

            }
            reader.Close();

        }

        static void XmlReaderDmeo()
        {
            string connectionString =
   @"server=(local);database=ProCSharp;trusted_connection=true";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Number, Info FROM Exams";
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                SqlXml xml = reader.GetSqlXml(2);

                XmlReader xmlReader = xml.CreateReader();

                StringBuilder courses = new StringBuilder("Course(s): ", 40);
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "Exam" && xmlReader.IsStartElement())
                    {
                        Console.WriteLine("Exam: {0}", xmlReader.GetAttribute("Number"));
                    }
                    else if (xmlReader.Name == "Title" && xmlReader.IsStartElement())
                    {
                        Console.WriteLine("Title: {0}", xmlReader.ReadString());
                    }
                    else if (xmlReader.Name == "Course" && xmlReader.IsStartElement())
                    {
                        courses.AppendFormat("{0} ", xmlReader.ReadString());
                    }
                }
                xmlReader.Close();
                Console.WriteLine(courses.ToString());
                Console.WriteLine();
            }
            reader.Close();
        }
    }
}
