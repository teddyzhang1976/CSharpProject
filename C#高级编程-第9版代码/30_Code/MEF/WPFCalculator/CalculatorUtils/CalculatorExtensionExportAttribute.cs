using System;
using System.ComponentModel.Composition;

namespace Wrox.ProCSharp.MEF
{
  [MetadataAttribute]
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
  public class CalculatorExtensionExportAttribute : ExportAttribute
  {
    public CalculatorExtensionExportAttribute(Type contractType)
      : base(contractType) { }

    public string Title { get; set;  }
    public string Description { get; set;  }

    public string ImageUri { get; set; }
  }
}
