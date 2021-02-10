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
    public class AllTrousersModel : PageModel
    {
            ProductContext _Context;
            public AllTrousersModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            public List<Trousers> allTrousers { get; set; }
            public void OnGet()
            {
                var data = (from trousersList in _Context.Trousers
                            select trousersList).ToList();

                allTrousers = data;
            }
            public ActionResult OnGetDelete(int? id)
            {
                if (id != null)
                {
                    var data = (from hats in _Context.Hats
                                where hats.Id == id
                                select hats).SingleOrDefault();

                    _Context.Remove(data);
                    _Context.SaveChanges();
                }
                return RedirectToPage("AllTrousers");
            }
        }
    }

