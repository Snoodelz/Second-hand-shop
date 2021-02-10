using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondHandWebShop.Pages.Shirts
{
    public class CreateShirtsModel : PageModel
    {
            ProductContext _Context;
            public CreateShirtsModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            [BindProperty]
            public Shirt Shirts { get; set; }
            public void OnGet()
            {
            }

            public ActionResult OnPost()
            {
                var shirt = Shirts;

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                shirt.Id = 0;
                var result = _Context.Add(shirt);
                _Context.SaveChanges();

                return RedirectToPage("AllShirts");
            }
        }
    }
