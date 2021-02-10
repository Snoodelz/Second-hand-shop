using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondHandWebShop.Pages.Hats
{
    public class AllHatsModel : PageModel
    {
        ProductContext _Context;
        public AllHatsModel(ProductContext productContext)
        {
            _Context = productContext;
        }

        public List<Hat> AllHats { get; set; }
        public void OnGet()
        {
            var data = (from hatslist in _Context.Hats
                        select hatslist).ToList();

            AllHats = data;
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
            return RedirectToPage("AllHats");
        }
    }
}
