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
        public class DetailsModel : PageModel
        {
            private readonly SecondHandWebShop.Data.ProductContext _context;

            public DetailsModel(SecondHandWebShop.Data.ProductContext context)
            {
                _context = context;
            }

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
        }
    }

