using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSampleApp.Models
{
  public class Menu
  {
    public int Id { get; set; }
    [Required, StringLength(25)]
    public string Text { get; set; }
    [DisplayName("Price"), DisplayFormat(DataFormatString="{0:C}")]
    public double Price { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    [StringLength(10)]
    public string Category { get; set; }
  }

}