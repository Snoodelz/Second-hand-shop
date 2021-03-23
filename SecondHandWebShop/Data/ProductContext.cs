using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecondHandWebShop.Models;

namespace SecondHandWebShop.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext (DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<SecondHandWebShop.Models.Clothing> Clothing { get; set; }

        public DbSet<SecondHandWebShop.Models.Order> Order { get; set; }
    }
}
