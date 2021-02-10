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
    public class AllShoesModel : PageModel
    {
            ProductContext _Context;
            public AllShoesModel(ProductContext productContext)
            {
                _Context = productContext;
            }
            public List<Shoe> allShoes { get; set; }
            public void OnGet()
            {
                var data = (from shoesList in _Context.Shoes
                            select shoesList).ToList();

                allShoes = data;
            }
            public ActionResult OnGetDelete(int? id)
            {
                if (id != null)
                {
                    var data = (from shoes in _Context.Shoes
                                where shoes.Id == id
                                select shoes).SingleOrDefault();

                    _Context.Remove(data);
                    _Context.SaveChanges();
                }
                return RedirectToPage("AllShoes");
            }
        }
    }

