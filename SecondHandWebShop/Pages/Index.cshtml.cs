using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SecondHandWebShop.Data;
using SecondHandWebShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWebShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductContext _context;

        public IndexModel(ProductContext context)
        {
            _context = context;
        }

        public IList<Clothing> AllClothing { get; set; }
        public IEnumerable<Clothing> AllHats { get; set; }
        public IEnumerable<Clothing> AllJackets { get; set; }
        public IEnumerable<Clothing> AllJewelries { get; set; }
        public IEnumerable<Clothing> AllShirts { get; set; }
        public IEnumerable<Clothing> AllShoes { get; set; }
        public IEnumerable<Clothing> AllTrousers { get; set; }
        public IEnumerable<Clothing> ProductsOnDiscount { get; set; }
        public IEnumerable<Clothing> Merchandise { get; set; }


        public void OnGet()
        {
            AllClothing = _context.Clothing.Where(c => c.Category != "Merchandise").ToList();
            AllHats = _context.Clothing.Where(c => c.Category == "Hat").ToList();
            AllJackets = _context.Clothing.Where(c => c.Category == "Jacket").ToList();
            AllJewelries = _context.Clothing.Where(c => c.Category == "Jewelry").ToList();
            AllShirts = _context.Clothing.Where(c => c.Category == "Shirt").ToList();
            AllShoes = _context.Clothing.Where(c => c.Category == "Shoe").ToList();
            AllTrousers = _context.Clothing.Where(c => c.Category == "Trouser").ToList();
            ProductsOnDiscount = _context.Clothing.Where(d => d.Discount > 0).OrderBy(d => d.Date).ToList();
            Merchandise = _context.Clothing.Where(c => c.Category == "Merchandise").ToList();
        }
    }
}
