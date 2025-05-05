using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class SaleItem
    {
        public SaleItem(int saleItemID, int saleID, int productID, int quantity, decimal unitPrice, Sale sale, Product product)
        {
            SaleItemID = saleItemID;
            SaleID = saleID;
            ProductID = productID;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Sale = sale;
            Product = product;
        }
        public SaleItem()
        {
            
        }

        public int SaleItemID { get; set; }
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}
