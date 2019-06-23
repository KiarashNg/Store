using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Store.Models;

namespace Store.Services.DAL
{
    public class StoreDbContext :DbContext
    {
        public StoreDbContext()
            :base("name=StoreDbContext")
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}