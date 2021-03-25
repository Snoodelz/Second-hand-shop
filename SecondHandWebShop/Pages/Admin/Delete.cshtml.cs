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
    public class DeleteModel : PageModel
    {
        private readonly SecondHandWebShop.Data.ProductContext _context;

        public DeleteModel(SecondHandWebShop.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clothing Clothing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clothing = await _context.Clothing.FirstOrDefaultAsync(m => m.Id == id);

            if (Clothing == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clothing = await _context.Clothing.FindAsync(id);

            if (Clothing != null)
            {
                var filePath = "./wwwroot" + Clothing.ImageUrl;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                _context.Clothing.Remove(Clothing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
