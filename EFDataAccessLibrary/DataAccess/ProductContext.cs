using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.DataAccess
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options) {}
        public DbSet<Trousers> Trousers { get; set; }
        public DbSet<Hat> Hats { get; set; }
        public DbSet<Jacket> Jackets { get; set; }
        public DbSet<Jewelry> Jewelries { get; set; }
        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
    }
}
