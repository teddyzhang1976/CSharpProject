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
                if (refreshExtensions == null)
                {
                    refreshExtensions = new RoutedUICommand("Refresh Extensions", "RefreshExtensions", typeof(CalculatorCommands));
                }
                return refreshExtensions;
            }
        }

        private static ICommand getExports;
        public static ICommand GetExports
        {
            get
            {
                if (getExports == null)
                {
                    getExports = new RoutedUICommand("Get Exports", "GetExports", typeof(CalculatorCommands));
                }
                return getExports;
            }
        }
    }
}
