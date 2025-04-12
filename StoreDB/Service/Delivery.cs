using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class Delivery
    {
        public Delivery(int deliveryID, int supplierID, DateTime deliveryDate, decimal totalAmount, Supplier supplier, ICollection<DeliveryItem> deliveryItems)
        {
            DeliveryID = deliveryID;
            SupplierID = supplierID;
            DeliveryDate = deliveryDate;
            TotalAmount = totalAmount;
            Supplier = supplier;
            DeliveryItems = deliveryItems;
        }
        public Delivery()
        {
            
        }

        public int DeliveryID { get; set; }
        public int SupplierID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<DeliveryItem> DeliveryItems { get; set; }
    }
}
