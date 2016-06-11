using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.DataServices
{
    public class MenuCard
    {
        private static object sync = new object();
        private static MenuCard menuCard;
        public static MenuCard Instance
        {
            get
            {
                lock (sync)
                {
                    if (menuCard == null)
                        menuCard = new MenuCard();
                }
                return menuCard;
            }
        }

        private List<Category> categories;
        private List<Menu> menus;

        private MenuCard()
        {
            categories = new List<Category>      
            {
                new Category(1, "Main"),
                new Category(2, "Appetizer")
            };

            menus = new List<Menu>() {
                new Menu(1, "Roasted Chicken", 22, categories[0]),
                new Menu(2, "Rack of Lamb", 32, categories[0]),
                new Menu(3, "Pork Tenderloin", 23, categories[0]),
                new Menu(4, "Fried Calamari", 9, categories[1])
            };
        }

        public IEnumerable<Menu> Menus
        {
            get
            {
                return menus;
            }
        }

        public IEnumerable<Category> Categories
        {
            get
            {
                return categories;
            }
        }

    }
}
