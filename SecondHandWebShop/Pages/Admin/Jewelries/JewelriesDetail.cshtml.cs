using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SecondHandWebShop.Pages.Jewelries
{
    public class JewelriesDetailModel : PageModel
    {
            ProductContext _Context;

            public JewelriesDetailModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            public Jewelry Jewelries { get; set; }

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Jewelries = await _Context.Jewelries.FirstOrDefaultAsync(m => m.Id == id);

                if (Jewelries == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
    }
