using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecondHandWebShop.Data;
using SecondHandWebShop.Models;

namespace SecondHandWebShop.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ProductContext _context;

        public ProductModel(ProductContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public Clothing Product { get; set; }
        public void OnGet()
        {
            if(ID == 0)
            {
                Product = _context.Clothing.First(c => c.Id == 1);
            }
            else
            {
                Product = _context.Clothing.First(c => c.Id == ID);
            }

        }
    }
}
