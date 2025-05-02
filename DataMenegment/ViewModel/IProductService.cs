using StoreDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMenegment.ViewModel
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
    }
}
