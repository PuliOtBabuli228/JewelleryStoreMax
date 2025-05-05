using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class Category
    {
        public Category(int categoryID, string categoryName, ICollection<Product> products)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            Products = products;
        }
        public Category()
        {
            
        }

        public override string ToString()
        {
            return CategoryName;
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
