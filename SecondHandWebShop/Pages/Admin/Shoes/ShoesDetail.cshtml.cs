using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SecondHandWebShop.Pages.Shoes
{
    public class ShoesDetailModel : PageModel
    {
            ProductContext _Context;

            public ShoesDetailModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            public Shoe Shoes { get; set; }

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Shoes = await _Context.Shoes.FirstOrDefaultAsync(m => m.Id == id);

                if (Shoes == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
    }
