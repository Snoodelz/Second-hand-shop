using Microsoft.AspNetCore.Mvc;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWebShop.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly EFDataAccessLibrary.DataAccess.ProductContext _context;

        public CatalogModel(EFDataAccessLibrary.DataAccess.ProductContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }
        
        public List<Hat> Hats { get; set; }
        public List<Jacket> Jackets { get; set; }
        public List<Jewelry> Jewelries { get; set; }
        public List<Shirt> Shirts { get; set; }
        public List<Shoe> Shoes { get; set; }
        public List<Trousers> Trousers { get; set; }

        public void OnGet()
        {
            Hats = _context.Hats.ToList();
            Jackets = _context.Jackets.ToList();
            Jewelries = _context.Jewelries.ToList();
            Shirts = _context.Shirts.ToList();
            Shoes = _context.Shoes.ToList();
            Trousers = _context.Trousers.ToList();
        }
    }
}
