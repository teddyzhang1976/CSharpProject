using System.Data.Services.Common;

namespace Wrox.ProCSharp.DataServices
{
    [DataServiceKey("Id")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category()
        {

        }

        public Category(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
