using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SecondHandWebShop.Data;
using SecondHandWebShop.Models;

namespace SecondHandWebShop.Pages.Admin
{
    public class MerchandiseModel : PageModel
    {
        private readonly SecondHandWebShop.Data.ProductContext _context;

        public MerchandiseModel(SecondHandWebShop.Data.ProductContext context)
        {
            _context = context;
        }

        public IList<Clothing> Clothing { get; set; }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from clothings in _context.Clothing
                            where clothings.Id == id
                            select clothings).SingleOrDefault();

                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }
        public async Task OnGetAsync()
        {
            Clothing = await _context.Clothing.ToListAsync();
        }

    }
}
