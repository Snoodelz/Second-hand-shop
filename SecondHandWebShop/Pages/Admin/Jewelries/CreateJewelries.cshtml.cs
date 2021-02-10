using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondHandWebShop.Pages.Jewelries
{
    public class CreateJewelriesModel : PageModel
    {
            ProductContext _Context;
            public CreateJewelriesModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            [BindProperty]
            public Jewelry Jewelries { get; set; }
            public void OnGet()
            {
            }

            public ActionResult OnPost()
            {
                var jewelry = Jewelries;

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                jewelry.Id = 0;
                var result = _Context.Add(jewelry);
                _Context.SaveChanges();

                return RedirectToPage("AllJewelries");
            }
        }
    }

