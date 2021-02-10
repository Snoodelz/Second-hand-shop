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
    public class AllJacketsModel : PageModel
    {
        ProductContext _Context;
        public AllJacketsModel(ProductContext productContext)
        {
            _Context = productContext;
        }

        public List<Jacket> allJackets { get; set; }
        public void OnGet()
        {
            var data = (from jacketList in _Context.Jackets
                        select jacketList).ToList();

            allJackets = data;
        }
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from jackets in _Context.Jackets
                            where jackets.Id == id
                            select jackets).SingleOrDefault();

                _Context.Remove(data);
                _Context.SaveChanges();
            }
            return RedirectToPage("AllJackets");
        }
    }
}
