using StoreDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMenegment.ViewModel
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetAllProducts()
        {
            // Пример: возвращаем заглушки
            return new List<Product>
        {
            new Product { Name = "Кольцо", Price = 12000 },
            new Product { Name = "Браслет", Price = 25000 }
        };
        }
    }
}
