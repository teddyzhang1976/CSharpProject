// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 2 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_2_CSharp
{
    public partial class TableDetails : Form
    {
        private DataTable ActiveTable;

        public TableDetails()
        {
            InitializeComponent();
        }

        public void ShowTable(DataTable whichTable)
        {
            // ----- Show the form to the user.
            ActiveTable = whichTable;
            this.ShowDialog();
        }

        private void TableDetails_Load(object sender, EventArgs e)
        {
            // ----- If there's no table, jump out early.
            if ((ActiveTable == null) || (ActiveTable.TableName == null)
                    || (ActiveTable.TableName.Length == 0)
                    || (ActiveTable.Columns == null))
            {
                this.AllColumns.Items.Add("No columns available");
                return;
            }

            // ----- Show the table name.

            // ----- Add the columns to the display list.

        }

        private void AllColumns_DrawItem(object sender, DrawItemEventArgs e)
        {
            // ----- Draw a single display item.
            System.Drawing.Brush useBrush;
            DataColumn itemDetail;
            StringFormat ellipsesFormat;
            string columnName = "";
            string dataTypeName = "";
            bool isPrimaryKey = false;

            // ----- Ignore undrawable items.
            if (e.Index == -1) return;

            // ----- Draw the background of the item.
            if ((e.State & DrawItemState.Selected) != 0)
                useBrush = SystemBrushes.HighlightText;
            else
                useBrush = SystemBrushes.WindowText;
            e.DrawBackground();

            // ----- This list handles both DataColumn and string entries.
            if (AllColumns.Items[e.Index].GetType() == typeof(DataColumn))
            {
                // ----- Extract the detail from the list.
                itemDetail = (DataColumn)AllColumns.Items[e.Index];

                // ----- Extract the column details.
                
                // ----- Some data may not fit.
                ellipsesFormat = new StringFormat();
                ellipsesFormat.Trimming = StringTrimming.EllipsisCharacter;

                // ----- Draw the text of the item.
                e.Graphics.DrawString(columnName, e.Font, useBrush,
                    new Rectangle(ColColumnName.Left - AllColumns.Left,
                    e.Bounds.Top, ColDataType.Left - ColColumnName.Left - 5,
                    e.Bounds.Height), ellipsesFormat);
                e.Graphics.DrawString(dataTypeName, e.Font, useBrush,
                    ColDataType.Left - AllColumns.Left, e.Bounds.Top);

                // ----- Indicate if this is a primary key column.
                if (isPrimaryKey)
                    e.Graphics.DrawString("PK", e.Font, useBrush, 0, e.Bounds.Top);
            }
            else
            {
                // ----- Display the string content.
                e.Graphics.DrawString((string)AllColumns.Items[e.Index], 
                    e.Font, useBrush, 0, e.Bounds.Top);
            }
            
            // ----- If the ListBox has focus, draw a focus rectangle.
            e.DrawFocusRectangle();
        }
    }
}
