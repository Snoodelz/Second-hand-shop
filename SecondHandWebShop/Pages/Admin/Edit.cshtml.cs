using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondHandWebShop.Data;
using SecondHandWebShop.Models;

namespace SecondHandWebShop.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly SecondHandWebShop.Data.ProductContext _context;

        public EditModel(SecondHandWebShop.Data.ProductContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Clothing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingExists(Clothing.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClothingExists(int id)
        {
            return _context.Clothing.Any(e => e.Id == id);
        }
    }
}
