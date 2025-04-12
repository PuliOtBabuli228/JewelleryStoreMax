using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class Product
    {
        public Product(int productID, string name, int categoryID, int materialID, int? stoneID, decimal weight, decimal price, int inStock, Category category, Material material, Stone stone, ICollection<DeliveryItem> deliveryItems, ICollection<SaleItem> saleItems)
        {
            ProductID = productID;
            Name = name;
            CategoryID = categoryID;
            MaterialID = materialID;
            StoneID = stoneID;
            Weight = weight;
            Price = price;
            InStock = inStock;
            Category = category;
            Material = material;
            Stone = stone;
            DeliveryItems = deliveryItems;
            SaleItems = saleItems;
        }
        public Product()
        {
            
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int MaterialID { get; set; }
        public int? StoneID { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }

        public Category Category { get; set; }
        public Material Material { get; set; }
        public Stone Stone { get; set; }

        public ICollection<DeliveryItem> DeliveryItems { get; set; }
        public ICollection<SaleItem> SaleItems { get; set; }
    }
}
