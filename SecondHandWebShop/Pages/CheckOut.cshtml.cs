using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecondHandWebShop.Helpers;

namespace SecondHandWebShop.Pages
{
    public class CheckOutModel : PageModel
    {
        public List<Item> cart { get; set; }
        public decimal Total { get; set; }

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
 
        }
    }
}
