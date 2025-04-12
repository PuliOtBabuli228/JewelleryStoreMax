using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class DeliveryItem
    {
        public DeliveryItem(int deliveryItemID, int deliveryID, int productID, int quantity, decimal itemPrice, Delivery delivery, Product product)
        {
            DeliveryItemID = deliveryItemID;
            DeliveryID = deliveryID;
            ProductID = productID;
            Quantity = quantity;
            ItemPrice = itemPrice;
            Delivery = delivery;
            Product = product;
        }
        public DeliveryItem()
        {
            
        }

        public int DeliveryItemID { get; set; }
        public int DeliveryID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }

        public Delivery Delivery { get; set; }
        public Product Product { get; set; }
    }
}
