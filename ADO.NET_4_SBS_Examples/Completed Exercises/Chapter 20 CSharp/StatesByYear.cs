// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 20 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_20_CSharp
{
    public partial class StatesByYear : Form
    {
        public StatesByYear()
        {
            InitializeComponent();
        }

        private void StatesByYear_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Perform the lookup.
            using (SalesOrderDataContext context = new SalesOrderDataContext(General.GetConnectionString()))
            {
                var result = from st in context.StateRegions
                             where st.Admitted != null
                             orderby st.Admitted.Value.Year
                             select new
                             {
                                 StateName = st.FullName,
                                 AdmitYear = st.Admitted.Value.Year,
                                 TotalAdmittedInYear = context.AdmittedInYear(st.Admitted)
                             };

                StateAdmittance.DataSource = result.ToList();
            }
        }
    }
}
