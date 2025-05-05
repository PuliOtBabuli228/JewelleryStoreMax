using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class Supplier
    {
        public Supplier(int supplierID, string name, string phone, string email, string address, ICollection<Delivery> deliveries)
        {
            SupplierID = supplierID;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            Deliveries = deliveries;
        }
        public Supplier()
        {
            
        }

        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Delivery> Deliveries { get; set; }
    }
}
