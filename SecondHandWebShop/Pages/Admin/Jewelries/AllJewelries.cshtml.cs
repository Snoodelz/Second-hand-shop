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
    public class AllJewelriesModel : PageModel
    {
            ProductContext _Context;
            public AllJewelriesModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            public List<Jewelry> allJewelries { get; set; }
            public void OnGet()
            {
                var data = (from jewelriesList in _Context.Jewelries
                            select jewelriesList).ToList();

                allJewelries = data;
            }
            public ActionResult OnGetDelete(int? id)
            {
                if (id != null)
                {
                    var data = (from jewelries in _Context.Jewelries
                                where jewelries.Id == id
                                select jewelries).SingleOrDefault();

                    _Context.Remove(data);
                    _Context.SaveChanges();
                }
                return RedirectToPage("AllJewelries");
            }
        }
    }
