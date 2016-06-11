using System.Data.Services.Common;

namespace Wrox.ProCSharp.DataServices
{
    [DataServiceKey("Id")]
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }

        public Menu()
        {
        }
        public Menu(int id, string name, decimal price, Category category)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }
    }
}
