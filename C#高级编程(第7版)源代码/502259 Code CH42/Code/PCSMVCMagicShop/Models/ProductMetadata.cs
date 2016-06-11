using System.ComponentModel.DataAnnotations;

namespace PCSMVCMagicShop.Models
{
   public class ProductMetadata
   {
      [StringLength(20)]
      public object Name { get; set; }
   }
}
