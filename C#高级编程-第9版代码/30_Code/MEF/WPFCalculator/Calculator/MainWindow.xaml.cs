using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Input;

namespace Wrox.ProCSharp.MEF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private CalculatorViewModel viewModel = new CalculatorViewModel();
    private CalculatorManager containerManager;

    public MainWindow()
    {
      InitializeComponent();

      this.DataContext = viewModel;
      containerManager = new CalculatorManager(viewModel);
      containerManager.InitializeContainer();
     // cm.RefreshExensions();

      BindingOperations.EnableCollectionSynchronization(viewModel.CalcAddInOperators, viewModel.syncCalcAddInOperators);
      BindingOperations.EnableCollectionSynchronization(viewModel.ActivatedExtensions, viewModel.syncActivatedExtensions);

    }

    private void OnNumberClick(object sender, RoutedEventArgs e)
    {
      var b = e.Source as Button;
      if (b != null)
      {
        viewModel.Input += b.Content.ToString();
      }
    }

    private IOperation currentOperation;
    private double[] currentOperands;

    void DefineOperation(object sender, RoutedEventArgs e)
    {
      Button b = e.Source as Button;
      if (b != null)
      {
        try
        {
          IOperation op = b.Tag as IOperation;
          currentOperands = new double[op.NumberOperands];
          currentOperands[0] = double.Parse(viewModel.Input);
          viewModel.Input += String.Format(" {0} ", op.Name);
          currentOperation = op;
        }
        catch (FormatException ex)
        {
          viewModel.Status = ex.Message;
        }
      }
    }

    private void OnClose(object sender, ExecutedRoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private async void OnCalculate(object sender, ExecutedRoutedEventArgs e)
    {
      if (currentOperands.Length == 2)
      {
        string[] input = viewModel.Input.Split(' ');
        currentOperands[1] = double.Parse(input[2]);
        await containerManager.InvokeCalculatorAsync(currentOperation, currentOperands);
      }
    }

    private void OnRefreshExtensions(object sender, ExecutedRoutedEventArgs e)
    {
      containerManager.RefreshExensions();
    }

    private void OnClearLog(object sender, ExecutedRoutedEventArgs e)
    {
      viewModel.Status = string.Empty;
    }

    private void OnActivateExtension(object sender, ExecutedRoutedEventArgs e)
    {
      var button = e.OriginalSource as RibbonButton;
      if (button != null)
      {
        Lazy<ICalculatorExtension> control = button.Tag as Lazy<ICalculatorExtension>;
        FrameworkElement el = control.Value.UI;
        viewModel.ActivatedExtensions.Add(control);
      }     
    }

    private void OnShowExports(object sender, ExecutedRoutedEventArgs e)
    {
      containerManager.ShowExports();
    }

    private void OnCloseExtension(object sender, ExecutedRoutedEventArgs e)
    {
      Button b = e.OriginalSource as Button;
      if (b != null)
      {
        Lazy<ICalculatorExtension> ext = b.Tag as Lazy<ICalculatorExtension>;
        if (ext != null)
        {
          viewModel.ActivatedExtensions.Remove(ext);
        }
      }
    }
  }
}
