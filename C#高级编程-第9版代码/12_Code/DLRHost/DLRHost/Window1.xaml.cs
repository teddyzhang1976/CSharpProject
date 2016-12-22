using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Scripting.Runtime;
using Microsoft.Scripting.Hosting;

namespace DLRHost
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string scriptToUse;
            if (CostRadioButton.IsChecked.Value)
            {
                scriptToUse = "AmountDisc.py";
            }
            else
            {
                scriptToUse = "CountDisc.py";
            }
            ScriptRuntime scriptRuntime = ScriptRuntime.CreateFromConfiguration();
            ScriptEngine rbEng = scriptRuntime.GetEngine("python");
            ScriptSource source = rbEng.CreateScriptSourceFromFile(scriptToUse);
            ScriptScope scope = rbEng.CreateScope();
            scope.SetVariable("prodCount", Convert.ToInt32(totalItems.Text));
            scope.SetVariable("amt", Convert.ToDecimal(totalAmt.Text));
            source.Execute(scope);
            label5.Content = scope.GetVariable("retAmt").ToString();
        }

private void button2_Click(object sender, RoutedEventArgs e)
{
    ScriptRuntime scriptRuntime = ScriptRuntime.CreateFromConfiguration();
    dynamic calcRate = scriptRuntime.UseFile("CalcTax.py");
    label6.Content = calcRate.CalcTax(Convert.ToDecimal(label5.Content)).ToString();
}

     
       
    }
}
