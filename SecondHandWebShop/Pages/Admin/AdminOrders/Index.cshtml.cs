using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SecondHandWebShop.Data;
using SecondHandWebShop.Models;

namespace SecondHandWebShop.Pages.Admin.AdminOrders
{
    public class IndexModel : PageModel
    {
        private readonly SecondHandWebShop.Data.ProductContext _context;

        public IndexModel(SecondHandWebShop.Data.ProductContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order.ToListAsync();
        }
    }
}
