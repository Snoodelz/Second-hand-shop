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

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from Order in _context.Order
                            where Order.OrderId == id
                            select Order).SingleOrDefault();

                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }
        public async Task OnGetAsync()
        {
            Order = await _context.Order.OrderByDescending(x => x.OrderDate).ToListAsync();
        }
    }
}
