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

namespace TableDemo
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


            var titleRow = new TableRow();
            titleRow.Background = new SolidColorBrush(Colors.LightBlue);
            var titleCell = new TableCell { ColumnSpan = 3, TextAlignment = TextAlignment.Center };
            titleCell.Blocks.Add(
                new Paragraph(new Run("Formula 1 Championship 2009") { FontSize = 24, FontWeight = FontWeights.Bold }));
            titleRow.Cells.Add(titleCell);

            var headerRow = new TableRow { Background = new SolidColorBrush(Colors.LightGoldenrodYellow) };
            headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Pos")) { FontSize = 14, FontWeight = FontWeights.Bold }));
            headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Name")) { FontSize = 14, FontWeight = FontWeights.Bold }));
            headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Points")) { FontSize = 14, FontWeight = FontWeights.Bold }));

            var row1 = new TableRow();
            row1.Cells.Add(new TableCell(new Paragraph(new Run("1."))));
            row1.Cells.Add(new TableCell(new Paragraph(new Run("Jenson Button"))));
            row1.Cells.Add(new TableCell(new Paragraph(new Run("95"))));

            var row2 = new TableRow { Background = new SolidColorBrush(Colors.LightGray) };
            row2.Cells.Add(new TableCell(new Paragraph(new Run("2."))));
            row2.Cells.Add(new TableCell(new Paragraph(new Run("Sebastian Vettel"))));
            row2.Cells.Add(new TableCell(new Paragraph(new Run("84"))));

            var row3 = new TableRow();
            row3.Cells.Add(new TableCell(new Paragraph(new Run("3."))));
            row3.Cells.Add(new TableCell(new Paragraph(new Run("Rubens Barrichello"))));
            row3.Cells.Add(new TableCell(new Paragraph(new Run("77"))));

            var rowGroup = new TableRowGroup();
            rowGroup.Rows.Add(titleRow);
            rowGroup.Rows.Add(headerRow);
            rowGroup.Rows.Add(row1);
            rowGroup.Rows.Add(row2);
            rowGroup.Rows.Add(row3);
            t1.RowGroups.Add(rowGroup);

            doc.Blocks.Add(t1);

            reader.Document = doc;
        }
    }
}
