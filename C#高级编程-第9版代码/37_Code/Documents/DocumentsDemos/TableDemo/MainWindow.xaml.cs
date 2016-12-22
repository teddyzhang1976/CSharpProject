using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wrox.ProCSharp.Documents
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      var doc = new FlowDocument();
      var t1 = new Table();
      t1.Columns.Add(new TableColumn { Width = new GridLength(50, GridUnitType.Pixel) });
      t1.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Auto) });
      t1.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Auto) });

      var titleRow = new TableRow { Background = Brushes.LightBlue };

      var titleCell = new TableCell { ColumnSpan = 3, TextAlignment = TextAlignment.Center };
      titleCell.Blocks.Add(
          new Paragraph(new Run("Formula 1 Championship 2011") { FontSize = 24, FontWeight = FontWeights.Bold }));
      titleRow.Cells.Add(titleCell);

      var headerRow = new TableRow { Background = Brushes.LightGoldenrodYellow };
      headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Pos")) { FontSize = 14, FontWeight = FontWeights.Bold }));
      headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Name")) { FontSize = 14, FontWeight = FontWeights.Bold }));
      headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Points")) { FontSize = 14, FontWeight = FontWeights.Bold }));

      var rowGroup = new TableRowGroup();
      rowGroup.Rows.Add(titleRow);
      rowGroup.Rows.Add(headerRow);

      string[][] results = new string[][]
      {
        new string[] { "1.", "Sebastian Vettel", "392" },
        new string[] { "2.", "Jenson Button", "270" },
        new string[] { "3.", "Mark Webber", "258" },
        new string[] { "4.", "Fernando Alonso", "257" },
        new string[] { "5.", "Lewis Hamilton", "227"}
      };

      List<TableRow> rows = results.Select(row =>
        {
          var tr = new TableRow();
          foreach (var cell in row)
          {
            tr.Cells.Add(new TableCell(new Paragraph(new Run(cell))));
          }
          return tr;
        }).ToList();

      rows.ForEach(r => rowGroup.Rows.Add(r));

      t1.RowGroups.Add(rowGroup);
      doc.Blocks.Add(t1);

      reader.Document = doc;
    }
  }
}
