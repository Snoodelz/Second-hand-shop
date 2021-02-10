using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SecondHandWebShop.Pages.Trouser
{
    public class TrousersDetailModel : PageModel
    {
            ProductContext _Context;

            public TrousersDetailModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            public Trousers Trousers { get; set; }

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Trousers = await _Context.Trousers.FirstOrDefaultAsync(m => m.Id == id);

                if (Trousers == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
    }

