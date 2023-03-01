using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProCateNimapInfoTech.Models
{
    public class NimapContext:DbContext
    {
        public NimapContext():base("name=DBConnection")
        {

        }
        public DbSet<Category> CategoriesTable { get; set; }
        public DbSet<Product> ProductsTable { get; set; }

    }
}