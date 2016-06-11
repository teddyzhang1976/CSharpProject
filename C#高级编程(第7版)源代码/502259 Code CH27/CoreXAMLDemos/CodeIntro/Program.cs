using System;
using System.Windows;
using System.Windows.Controls;

namespace Wrox.ProCSharp.XAML
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var b = new Button
            {
                Content = "Click Me!"
            };
            var w = new Window
            {
                Title = "Code Demo",
                Content = b
            };
            
            var app = new Application();
            app.Run(w);


        }
    }
}
