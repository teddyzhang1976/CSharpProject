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
using System.Windows.Shapes;
using System.Globalization;

namespace WpfApplication1
{
    /// <summary>
    /// Window16.xaml 的交互逻辑
    /// </summary>
    public partial class Window16 : Window
    {
        public Window16()
        {
            InitializeComponent();
            Binding bind =new Binding("Value") { UpdateSourceTrigger= UpdateSourceTrigger.PropertyChanged,Source=slider1, Mode= BindingMode.TwoWay};
            ValidationRule rule = new RangeValidationRule();
            rule.ValidatesOnTargetUpdated = true;
            bind.ValidationRules.Add(rule);
            bind.NotifyOnValidationError = true;
            this.textBox1.SetBinding(TextBox.TextProperty, bind);
            this.textBox1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(ValidationError));
        }

        private void ValidationError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(textBox1).Count > 0)
            {
                this.textBox1.ToolTip = Validation.GetErrors(textBox1)[0].ErrorContent.ToString();
            }
            else
            {
                this.textBox1.ToolTip = "";
            }
        }
    }

    //public interface IValueConverter
    //{
    //    object Convert(object value, Type targetType, object parameters, CultureInfo culture);
    //    object ConvertBack(object value, Type targetType, object parameters, CultureInfo culture);
    //}

   

    public class RangeValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double d = 0;
            if(double.TryParse(value.ToString(),out d))
            {
                if(d>=0&&d<=100)
                {
                    return new ValidationResult(true,null);
                }
            }
            return new ValidationResult(false,"ErrorContent");
        }
    }
}
