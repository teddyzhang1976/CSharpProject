using System;
using System.Text;

namespace Encoder2
{
    class Program
    {
        static void Main()
        {
            StringBuilder greetingBuilder =
               new StringBuilder("Hello from all the guys at Wrox Press. ", 150);
            greetingBuilder.Append("We do hope you enjoy this book as much as we enjoyed writing it");

            for(int i = (int)'z'; i>=(int)'a' ; i--)
            {
               char old1 = (char)i;
               char new1 = (char)(i+1);
               greetingBuilder = greetingBuilder.Replace(old1, new1);
            }

            for(int i = (int)'Z'; i>=(int)'A' ; i--)
            {
               char old1 = (char)i;
               char new1 = (char)(i+1);
               greetingBuilder = greetingBuilder.Replace(old1, new1);
            }

            Console.WriteLine("Encoded:\n" + greetingBuilder);
            Console.ReadLine();
        }
    }
}
