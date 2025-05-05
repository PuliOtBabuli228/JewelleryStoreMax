using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class Sale
    {
        public Sale(int saleID, DateTime saleDate, decimal totalAmount, string customerName, ICollection<SaleItem> saleItems)
        {
            SaleID = saleID;
            SaleDate = saleDate;
            TotalAmount = totalAmount;
            CustomerName = customerName;
            SaleItems = saleItems;
        }
        public Sale()
        {
            
        }

        public int SaleID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }

        public ICollection<SaleItem> SaleItems { get; set; }
    }
}
