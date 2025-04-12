using Microsoft.EntityFrameworkCore;
using StoreDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.ContextDB
{
    public class SQLServerDBContext : DbContext
    {
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Delivery> Deliverys { get; set; }
        public DbSet<DeliveryItem> DeliveryItems { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Stone> Stones { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Database = JewelleryStore");
        }
    }
}
