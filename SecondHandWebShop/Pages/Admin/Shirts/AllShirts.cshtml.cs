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
    public class AllShirtsModel : PageModel
    {
            ProductContext _Context;
            public AllShirtsModel(ProductContext productContext)
            {
                _Context = productContext;
            }

            public List<Shirt> allShirts { get; set; }
            public void OnGet()
            {
                var data = (from shirtslist in _Context.Shirts
                            select shirtslist).ToList();

                allShirts = data;
            }
            public ActionResult OnGetDelete(int? id)
            {
                if (id != null)
                {
                    var data = (from shirts in _Context.Shirts
                                where shirts.Id == id
                                select shirts).SingleOrDefault();

                    _Context.Remove(data);
                    _Context.SaveChanges();
                }
                return RedirectToPage("AllShirts");
            }
        }
    }
