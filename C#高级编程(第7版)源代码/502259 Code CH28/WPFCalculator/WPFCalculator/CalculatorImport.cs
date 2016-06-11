using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Wrox.ProCSharp.MEF
{
    public class CalculatorImport : IPartImportsSatisfiedNotification
    {
        public event EventHandler<ImportEventArgs> ImportsSatisfied;

        [Import(typeof(ICalculator))]
        public Lazy<ICalculator> Calculator { get; set; }

        public void OnImportsSatisfied()
        {
            if (ImportsSatisfied != null)
                ImportsSatisfied(this, new ImportEventArgs { StatusMessage = "ICalculator import successful" });

        }
    }
}
