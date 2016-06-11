using System;
using System.Collections.Generic;
using System.Text;
using Message = System.Messaging.Message;

namespace CSharp
{

    public class ExceptionDemo
    {
        public void ThrowMethod()
        {
            throw new ArgumentException("error");
        }

        public void Handler()
        {
            try
            {
                ThrowMethod();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}
