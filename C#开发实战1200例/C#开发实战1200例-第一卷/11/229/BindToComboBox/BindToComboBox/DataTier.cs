using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace BindToComboBox
{
    class DataTier
    {
        private string Connection = string.Format(
            "provider=Microsoft.Jet.OLEDB.4.0; Data Source=test.mdb;User Id=Admin");
        internal List<Instance> GetMessage()
        {
            try
            {
                OleDbDataAdapter P_DataAdapter = new OleDbDataAdapter(
                    "select [message],[count] from [message]", Connection);
                DataTable P_DataTable = new DataTable();
                P_DataAdapter.Fill(P_DataTable);
                List<Instance> P_List_Str = new List<Instance>();
                for (int i = 0; i < P_DataTable.Rows.Count; i++)
                {
                    P_List_Str.Add(new Instance() 
                    {
                        Book = P_DataTable.Rows[i][0].ToString(),
                        count = (int)P_DataTable.Rows[i][1]
                    });
                }
                return P_List_Str;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }
    }
}
