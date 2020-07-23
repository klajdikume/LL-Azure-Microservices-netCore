using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Products.Db
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
