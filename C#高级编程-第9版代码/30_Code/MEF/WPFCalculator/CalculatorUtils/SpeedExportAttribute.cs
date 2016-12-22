using System;
using System.ComponentModel.Composition;

namespace Wrox.ProCSharp.MEF
{
  public enum Speed
  {
    Fast,
    Slow
  }

  [MetadataAttribute]
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
  public class SpeedExportAttribute : ExportAttribute
  {
    public SpeedExportAttribute(string contractName, Type contractType)
      : base(contractName, contractType) { }

    public Speed Speed { get; set; }
  }
}
