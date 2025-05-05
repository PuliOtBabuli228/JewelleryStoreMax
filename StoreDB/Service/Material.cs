using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class Material
    {
        public Material(int materialID, string materialName, ICollection<Product> products)
        {
            MaterialID = materialID;
            MaterialName = materialName;
            Products = products;
        }
        public Material()
        {
            
        }

        public override string ToString()
        {
            return MaterialName;
        }

        public int MaterialID { get; set; }
        public string MaterialName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
