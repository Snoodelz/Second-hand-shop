using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SecondHandWebShop.Pages.Jackets
{
    public class JacketsDetailModel : PageModel

        {
            ProductContext _Context;

            public JacketsDetailModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            public Jacket Jackets { get; set; }

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Jackets = await _Context.Jackets.FirstOrDefaultAsync(m => m.Id == id);

                if (Jackets == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
    }
