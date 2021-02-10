using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SecondHandWebShop.Pages.Shirts
{
    public class ShirtsDetailModel : PageModel
    {
            ProductContext _Context;

            public ShirtsDetailModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            public Shirt Shirts { get; set; }

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Shirts = await _Context.Shirts.FirstOrDefaultAsync(m => m.Id == id);

                if (Shirts == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
    }