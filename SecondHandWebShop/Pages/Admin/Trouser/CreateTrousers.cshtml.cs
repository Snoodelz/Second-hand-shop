using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondHandWebShop.Pages.Trouser
{
    public class CreateTrousersModel : PageModel
    {
            ProductContext _Context;
            public CreateTrousersModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            [BindProperty]
            public Trousers Trousers { get; set; }
            public void OnGet()
            {
            }

            public ActionResult OnPost()
            {
                var trousers = Trousers;

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                trousers.Id = 0;
                var result = _Context.Add(trousers);
                _Context.SaveChanges();

                return RedirectToPage("AllTrousers");
            }
        }
    }

