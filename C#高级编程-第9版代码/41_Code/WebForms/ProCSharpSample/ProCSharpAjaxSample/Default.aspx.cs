using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProCSharpAjaxSample
{
  public partial class Default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GoButtonClick(object sender, EventArgs e)
    {
      int maxValue = 0;
      var resultText = new StringBuilder();
      if (int.TryParse(MaxValue.Text, out maxValue))
      {
        for (int trial = 2; trial <= maxValue; trial++)
        {
          bool isPrime = true;
          for (int divisor = 2; divisor <= Math.Sqrt(trial); divisor++)
          {
            if (trial % divisor == 0)
            {
              isPrime = false;
              break;
            }
          }
          if (isPrime)
          {
            resultText.AppendFormat("{0} ", trial);
          }
        }
      }
      else
      {
        resultText.Append("Unable to parse maximum value.");
      }
      ResultLabel.Text = resultText.ToString();
    }

  }
}