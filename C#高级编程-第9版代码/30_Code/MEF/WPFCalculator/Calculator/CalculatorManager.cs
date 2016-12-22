using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.MEF
{
  public sealed class CalculatorManager : IDisposable
  {
    private DirectoryCatalog catalog;
    private CompositionContainer container;
    private CalculatorImport calcImport;
    private CalculatorExtensionImport calcExtensionImport;
    private CalculatorViewModel vm;

    public CalculatorManager(CalculatorViewModel vm)
    {
      this.vm = vm;
    }

    public async void InitializeContainer()
    {

      catalog = new DirectoryCatalog(Properties.Settings.Default.AddInDirectory);

      #region DirectoryCatalog Changed event
      catalog.Changed += (sender, e) =>
      {
        var sb = new StringBuilder();

        foreach (var definition in e.AddedDefinitions)
        {
          foreach (var metadata in definition.Metadata)
          {
            sb.AppendFormat("added definition with metadata - key: {0}, value: {1}\n", metadata.Key, metadata.Value);
          }
        }

        foreach (var definition in e.RemovedDefinitions)
        {
          foreach (var metadata in definition.Metadata)
          {
            sb.AppendFormat("removed definition with metadata - key: {0}, value: {1}\n", metadata.Key, metadata.Value);
          }
        }

        vm.Status += sb.ToString();
      };
      #endregion

      container = new CompositionContainer(catalog);

      #region Container ExportsChanged event
      container.ExportsChanged += (sender, e) =>
      {
        var sb = new StringBuilder();

        foreach (var item in e.AddedExports)
        {
          sb.AppendFormat("added export {0}\n", item.ContractName);
        }
        foreach (var item in e.RemovedExports)
        {
          sb.AppendFormat("removed export {0}\n", item.ContractName);
        }
        vm.Status += sb.ToString();
      };
      #endregion

      calcImport = new CalculatorImport();

      #region ImportsSatisfied event
      calcImport.ImportsSatisfied += (sender, e) =>
      {
        vm.Status += string.Format("{0}\n", e.StatusMessage);
      };
      #endregion

      await Task.Run(() =>
        {
          container.ComposeParts(calcImport);
        });

      await InitializeOperationsAsync();
    }



    public Task InitializeOperationsAsync()
    {
      Contract.Requires(calcImport != null);
      Contract.Requires(calcImport.Calculator != null);
      return Task.Run(() =>
        {
          var operators = calcImport.Calculator.Value.GetOperations();
          lock (vm.syncCalcAddInOperators)
          {
            vm.CalcAddInOperators.Clear();

            foreach (var op in operators)
            {
              vm.CalcAddInOperators.Add(op);
            }
          }
        });
    }

    public async Task InvokeCalculatorAsync(IOperation operation, double[] operands)
    {
      double result = await Task<double>.Run(() =>
        {
          return calcImport.Calculator.Value.Operate(operation, operands);
        });

      vm.Result = result.ToString();
      vm.Input = string.Empty;
    }

    public void RefreshExensions()
    {
      catalog.Refresh();
      calcExtensionImport = new CalculatorExtensionImport();
      calcExtensionImport.ImportsSatisfied += (sender, e) =>
      {
        vm.Status += String.Format("{0}\n", e.StatusMessage);
      };

      container.ComposeParts(calcExtensionImport);
      vm.CalcExtensions.Clear();
      foreach (var extension in calcExtensionImport.CalculatorExtensions)
      {
        vm.CalcExtensions.Add(extension);
      }
    }

    private void GetExportInformation<T>(CompositionContainer container, StringBuilder sb)
    {
      foreach (var export in container.GetExports<T, IDictionary<string, object>>())
      {
        sb.AppendFormat("Export type: {0}\n", export.Value.GetType().Name);
        foreach (var metaKey in export.Metadata.Keys)
        {
          sb.AppendFormat("\tkey: {0}, value: {1}\n", metaKey, export.Metadata[metaKey]);
        }
      }
    }

    public void ShowExports()
    {
      var sb = new StringBuilder();
      GetExportInformation<ICalculator>(container, sb);
      GetExportInformation<ICalculatorExtension>(container, sb);
      vm.Status += sb.ToString();
    }

    public void Dispose()
    {
      catalog.Dispose();
      container.Dispose();
    }
  }
}
