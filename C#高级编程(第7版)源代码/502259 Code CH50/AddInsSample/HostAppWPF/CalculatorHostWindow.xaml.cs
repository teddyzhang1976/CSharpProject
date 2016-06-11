using System;
using System.AddIn.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Wrox.ProCSharp.MAF.Properties;

namespace Wrox.ProCSharp.MAF
{
   public partial class CalculatorHostWindow : Window
   {
      private Calculator activeAddIn = null;
      private Operation currentOperation = null;

      public CalculatorHostWindow()
      {
         InitializeComponent();

         FindAddIns();
      }

      void FindAddIns()
      {
         try
         {
            this.listAddIns.DataContext = AddInStore.FindAddIns(typeof(Calculator), Settings.Default.PipelinePath);
         }
         catch (DirectoryNotFoundException)
         {
            MessageBox.Show("Verify the pipeline directory in the config file");
            Application.Current.Shutdown();
         }
      }

      void ListOperatons()
      {
         this.listOperations.DataContext = activeAddIn.GetOperations();
      }

      void ListOperands(double[] operands)
      {
         this.listOperands.DataContext =
            operands.Select((operand, index) => new OperandUI() { Index = index + 1, Value = operand }).ToArray();
      }

      private void UpdateStore(object sender, RoutedEventArgs e)
      {
         string[] messages = AddInStore.Update(Settings.Default.PipelinePath);
         if (messages.Length != 0)
         {
            MessageBox.Show(string.Join("\n", messages), "AddInStore Warnings", MessageBoxButton.OK, MessageBoxImage.Warning);
         }
      }

      private void RebuildStore(object sender, RoutedEventArgs e)
      {
         string[] messages = AddInStore.Rebuild(Settings.Default.PipelinePath);
         if (messages.Length != 0)
         {
            MessageBox.Show(string.Join("\n", messages), "AddInStore Warnings", MessageBoxButton.OK, MessageBoxImage.Warning);
         }
      }

      private void RefreshAddIns(object sender, RoutedEventArgs e)
      {
         FindAddIns();
      }

      private class OperandUI
      {
         public int Index { get; set; }
         public double Value { get; set; }
      }

      private void App_Exit(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }



      private void ActivateAddIn(object sender, RoutedEventArgs e)
      {
         FrameworkElement el = sender as FrameworkElement;

         Trace.Assert(el != null, "ActivateAddIn invoked from the wrong control type");
          
         AddInToken addIn = el.Tag as AddInToken;
         Trace.Assert(el.Tag != null, String.Format("An AddInToken must be assigned to the Tag property of the control {0}", el.Name));

         AddInProcess process = new AddInProcess();
         process.KeepAlive = false;
        
         activeAddIn = addIn.Activate<Calculator>(process, AddInSecurityLevel.Internet);

         ListOperatons();    

      }

      private void OperationSelected(object sender, RoutedEventArgs e)
      {
         FrameworkElement el = sender as FrameworkElement;
         Trace.Assert(el != null, "OperationSelected invoked from the wrong control type");
          
         Operation op = el.Tag as Operation;
         Trace.Assert(op != null, String.Format("An Operation must be assigned to the Tag property of the of the control {0}", el.Name));

         currentOperation = op;
         ListOperands(new double[op.NumberOperands]);

         buttonCalculate.IsEnabled = true;
      }

      private void Calculate(object sender, RoutedEventArgs e)
      {
         OperandUI[] operandsUI = (OperandUI[])this.listOperands.DataContext;
         double[] operands = operandsUI.Select(opui => opui.Value).ToArray();
         double result = activeAddIn.Operate(currentOperation, operands);
         labelResult.Content = result;
      }


   }
}
