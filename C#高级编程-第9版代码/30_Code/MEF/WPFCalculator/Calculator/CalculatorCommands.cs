using System.Windows.Input;

namespace Wrox.ProCSharp.MEF
{
  public static class CalculatorCommands
  {
    private static ICommand refreshExtensions;
    public static ICommand RefreshExtensions
    {
      get
      {
        return refreshExtensions ?? (refreshExtensions = new RoutedUICommand("Refresh Extensions", "RefreshExtensions", typeof(CalculatorCommands)));
      }
    }

    private static ICommand showExports;
    public static ICommand ShowExports
    {
      get
      {
        return showExports ?? (showExports = new RoutedUICommand("Show Exports", "Show Exports", typeof(CalculatorCommands)));
      }
    }

    private static ICommand clearLog;
    public static ICommand ClearLog
    {
      get
      {
        return clearLog ?? (clearLog = new RoutedUICommand("Clear Log", "Clear Log", typeof(CalculatorCommands)));
      }
    }

    private static ICommand calculate;
    public static ICommand Calculate
    {
      get
      {
        return calculate ?? (calculate = new RoutedUICommand("Calculate", "Calculate", typeof(CalculatorCommands)));
      }
    }

    private static ICommand activateExtension;
    public static ICommand ActivateExtension
    {
      get
      {
        return activateExtension ?? (activateExtension = new RoutedUICommand("Activate AddIn", "Activate", typeof(CalculatorCommands)));
      }
    }

    private static ICommand closeExtension;
    public static ICommand CloseExtension
    {
      get
      {
        return closeExtension ?? (closeExtension = new RoutedUICommand("Activate AddIn", "Activate", typeof(CalculatorCommands)));
      }
    }

  }
}
