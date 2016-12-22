using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _09_CustomActivities
{
    public class Message : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            MessageBox.Show(Text.Get(context));
        }
    }
}
