using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace SecondHandWebShop.Pages.Jackets
{
    public class EditJacketsModel : PageModel
    {
        ProductContext _Context;
        public EditJacketsModel(ProductContext productContext)
        {
            _Context = productContext;
        }

        [BindProperty]
        public Jacket Jackets { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from jacket in _Context.Jackets
                            where jacket.Id == id
                            select jacket).SingleOrDefault();
                Jackets = data;
            }
        }
        public ActionResult OnPost()
        {
            var jacket = Jackets;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _Context.Entry(jacket).Property(x => x.Name).IsModified = true;
            _Context.Entry(jacket).Property(x => x.Description).IsModified = true;
            _Context.Entry(jacket).Property(x => x.Price).IsModified = true;
            _Context.Entry(jacket).Property(x => x.ImageUrl).IsModified = true;
            _Context.Entry(jacket).Property(x => x.Brand).IsModified = true;
            _Context.Entry(jacket).Property(x => x.TypeOf).IsModified = true;
            _Context.Entry(jacket).Property(x => x.Gender).IsModified = true;
            _Context.Entry(jacket).Property(x => x.Material).IsModified = true;
            _Context.Entry(jacket).Property(x => x.Size).IsModified = true;
            _Context.Entry(jacket).Property(x => x.Color).IsModified = true;

            _Context.SaveChanges();
            return RedirectToPage("AllJackets");
        }
    }
}