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
    public class EditJewelriesModel : PageModel
    {
            ProductContext _Context;
            public EditJewelriesModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            [BindProperty]
            public Jewelry Jewelries { get; set; }

            public void OnGet(int? id)
            {
                if (id != null)
                {
                    var data = (from jewelries in _Context.Jewelries
                                where jewelries.Id == id
                                select jewelries).SingleOrDefault();
                    Jewelries = data;
                }
            }
            public ActionResult OnPost()
            {
                var hat = Jewelries;
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _Context.Entry(hat).Property(x => x.Name).IsModified = true;
                _Context.Entry(hat).Property(x => x.Description).IsModified = true;
                _Context.Entry(hat).Property(x => x.Price).IsModified = true;
                _Context.Entry(hat).Property(x => x.ImageUrl).IsModified = true;
                _Context.Entry(hat).Property(x => x.Brand).IsModified = true;
                _Context.Entry(hat).Property(x => x.TypeOf).IsModified = true;
                _Context.Entry(hat).Property(x => x.Material).IsModified = true;

                _Context.SaveChanges();
                return RedirectToPage("AllJewelries");
            }
        }
    }
