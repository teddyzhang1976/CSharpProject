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
using System.Activities.Presentation.Metadata;
using System.ComponentModel;

namespace Activities.Presentation
{
    // Interaction logic for ActivityDesigner1.xaml
    public partial class DebugWriteDesigner
    {
        public DebugWriteDesigner()
        {
            InitializeComponent();
        }

        public static void RegisterMetadata(AttributeTableBuilder atb)
        {
            Type t = Type.GetType("Activities.DebugWrite, Activities");

            atb.AddCustomAttributes(t, new Attribute[] { new DesignerAttribute(typeof(DebugWriteDesigner)) });
        }
    }
}
