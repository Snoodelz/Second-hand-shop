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
    public class CreateHatsModel : PageModel
    {
        ProductContext _Context;
        public CreateHatsModel(ProductContext productContext)
        {
            _Context = productContext;
        }

        [BindProperty]
        public Hat Hats { get; set; }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            var hat = Hats;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            hat.Id = 0;
            var result = _Context.Add(hat);
            _Context.SaveChanges();

            return RedirectToPage("AllHats");
        }
    }
}
