using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Wrox.ProCSharp.MEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompositionContainer container;
        private DirectoryCatalog catalog;
        private CalculatorImport calcImport;
        private CalculatorExtensionImport calcExtensionImport;
        private IOperation currentOperation;
        private double[] currentOperands;

        public MainWindow()
        {
            InitializeComponent();
            InitializeContainer();
            RefreshExensions();
        }

        private void InitializeContainer()
        {
            catalog = new DirectoryCatalog(Properties.Settings.Default.AddInDirectory);
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
                    this.textStatus.Text += sb.ToString();
                };
            container = new CompositionContainer(catalog);
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
                this.textStatus.Text += sb.ToString();
            };

            calcImport = new CalculatorImport();
            calcImport.ImportsSatisfied += (sender, e) =>
                {
                    textStatus.Text += String.Format("{0}\n", e.StatusMessage);
                };
            // container.ComposeParts(calcImport);

            var batch = new CompositionBatch();
            batch.AddPart(calcImport);
            container.Compose(batch);

            InitializeOperations();
        }

        private void InitializeOperations()
        {
            Contract.Requires(calcImport != null);
            Contract.Requires(calcImport.Calculator != null);

            var operators = calcImport.Calculator.Value.GetOperations();
            foreach (var op in operators)
            {
                var b = new Button();
                b.Width = 40;
                b.Height = 30;
                b.Content = op.Name;
                b.Margin = new Thickness(2);
                b.Padding = new Thickness(4);
                b.Tag = op;
                b.Click += new RoutedEventHandler(DefineOperation);
                listOperators.Items.Add(b);
            }

        }

        void DefineOperation(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            if (b != null)
            {
                try
                {
                    IOperation op = b.Tag as IOperation;
                    currentOperands = new double[op.NumberOperands];
                    currentOperands[0] = double.Parse(textInput.Text);
                    textInput.Text += String.Format(" {0} ", op.Name);
                    currentOperation = op;
                }
                catch (FormatException ex)
                {
                    textResult.Text = ex.Message;
                }
            }
        }

        private void OnNumberClick(object sender, RoutedEventArgs e)
        {
            var b = e.Source as Button;
            if (b != null)
            {
                textInput.Text += b.Content.ToString();
            }
        }

        private void InvokeOperation(object sender, RoutedEventArgs e)
        {
            if (currentOperands.Length == 2)
            {
                string[] input = textInput.Text.Split(' ');
                currentOperands[1] = double.Parse(input[2]);
            }
            double result = calcImport.Calculator.Value.Operate(currentOperation, currentOperands);
            textResult.Text = result.ToString();
            textInput.Text = string.Empty;
        }

        private void RefreshExensions() 
        {
            catalog.Refresh();
            calcExtensionImport = new CalculatorExtensionImport();
            calcExtensionImport.ImportsSatisfied += (sender, e) =>
                {
                    this.textStatus.Text += String.Format("{0}\n", e.StatusMessage);
                };


            container.ComposeParts(calcExtensionImport);
            menuAddins.Items.Clear();
            foreach (var extension in calcExtensionImport.CalculatorExtensions)
            {
                var menuItemHeader = new StackPanel { Orientation = Orientation.Horizontal };
                menuItemHeader.Children.Add(new Label { Content = extension.Title });
                var menuCheck = new CheckBox { IsChecked = true };
                menuCheck.Unchecked += (sender1, e1) =>
                    {
                        MenuItem mi = (sender1 as CheckBox).Tag as MenuItem;
                        ICalculatorExtension ext = mi.Tag as ICalculatorExtension;
                        ComposablePart part = AttributedModelServices.CreatePart(ext);
                        var batch = new CompositionBatch();
                        batch.RemovePart(part);
                        container.Compose(batch);
                        MenuItem parentMenu = mi.Parent as MenuItem;    
                        parentMenu.Items.Remove(mi);
                    };
                menuItemHeader.Children.Add(menuCheck);
                
                var menuItem = new MenuItem { Header = menuItemHeader, ToolTip = extension.Description, Tag = extension };
                menuCheck.Tag = menuItem;
                menuItem.Click += ShowAddIn;
                menuAddins.Items.Add(menuItem);
            }        
        }

        private void ShowAddIn(object sender, RoutedEventArgs e)
        {
            var mi = e.Source as MenuItem;
            var ext = mi.Tag as ICalculatorExtension;
            FrameworkElement uiControl = ext.GetUI();
            var headerPanel = new StackPanel { Orientation = Orientation.Horizontal };
            headerPanel.Children.Add(new Label { Content = ext.Title });
            var closeButton = new Button { Content = "X" };
            var ti = new TabItem { Header = headerPanel, Content = uiControl };
            closeButton.Click += delegate
                {
                    tabExtensions.Items.Remove(ti);
                };
            headerPanel.Children.Add(closeButton);

            tabExtensions.SelectedIndex = tabExtensions.Items.Add(ti);
        }

        private void OnClose(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnRefreshExtensions(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            RefreshExensions();
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

        private void OnGetExports(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var sb = new StringBuilder();
            GetExportInformation<ICalculator>(container, sb);
            GetExportInformation<ICalculatorExtension>(container, sb);
            textStatus.Text += sb.ToString();

        }
    }
}
