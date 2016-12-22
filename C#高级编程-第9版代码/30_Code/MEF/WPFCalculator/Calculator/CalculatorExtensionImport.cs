using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Wrox.ProCSharp.MEF
{
  public class CalculatorExtensionImport : IPartImportsSatisfiedNotification
  {
    public event EventHandler<ImportEventArgs> ImportsSatisfied;

    [ImportMany(AllowRecomposition = true)]
    public IEnumerable<Lazy<ICalculatorExtension, ICalculatorExtensionMetadata>> CalculatorExtensions { get; set; }

    public void OnImportsSatisfied()
    {
      if (ImportsSatisfied != null)
        ImportsSatisfied(this, new ImportEventArgs { StatusMessage = "ICalculatorExtension imports successful" });

    }
  }
}
