using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondHandWebShop.Pages.Shoes
{
    public class CreateShoesModel : PageModel
    {
            ProductContext _Context;
            public CreateShoesModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            [BindProperty]
            public Shoe Shoes { get; set; }
            public void OnGet()
            {
            }

            public ActionResult OnPost()
            {
                var shoe = Shoes;

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                shoe.Id = 0;
                var result = _Context.Add(shoe);
                _Context.SaveChanges();

                return RedirectToPage("AllShoes");
            }
        }
    }
