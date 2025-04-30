using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class Stone
    {
        public Stone(int stoneID, string stoneName, ICollection<Product> products)
        {
            StoneID = stoneID;
            StoneName = stoneName;
            Products = products;
        }
        public Stone()
        {
            
        }

        public override string ToString()
        {
            return StoneName;
        }

        public int StoneID { get; set; }
        public string StoneName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
