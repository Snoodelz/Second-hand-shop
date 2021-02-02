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
        public DbSet<Pants> Pants { get; set; }
    }
}
