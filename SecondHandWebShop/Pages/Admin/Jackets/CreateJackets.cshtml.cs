using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondHandWebShop.Pages.Jackets
{
        public class CreateJacketsModel : PageModel
        {
            ProductContext _Context;
            public CreateJacketsModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            [BindProperty]
            public Jacket Jackets { get; set; }
            public void OnGet()
            {
            }

            public ActionResult OnPost()
            {
                var jacket = Jackets;

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                jacket.Id = 0;
                var result = _Context.Add(jacket);
                _Context.SaveChanges();

                return RedirectToPage("AllJackets");
            }
        }
    }

