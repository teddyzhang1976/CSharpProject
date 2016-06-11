using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Formula1Demo
{
    /// <summary>
    /// Interaction logic for TreeUC.xaml
    /// </summary>
    public partial class TreeUC : UserControl
    {
        private Formula1Entities data = new Formula1Entities();

        public TreeUC()
        {
            InitializeComponent();
            this.DataContext = Years;
        }

        public IEnumerable<Championship> Years
        {
            get
            {
                F1DataContext.Data = data;
                var q = (from r in data.Races
                         orderby r.Date ascending
                         select 
                         new Championship
                         {
                             Year = r.Date.Year,
                         }).Distinct();
                return q;
            }
        }
    }
}
