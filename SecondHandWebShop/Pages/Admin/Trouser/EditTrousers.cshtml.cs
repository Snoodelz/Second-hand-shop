using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace SecondHandWebShop.Pages.Trouser
{
    public class EditTrousersModel : PageModel
    {
        ProductContext _Context;
        public EditTrousersModel(ProductContext productContext)
        {
            _Context = productContext;
        }

        [BindProperty]
        public Trousers Trousers { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from trouser in _Context.Trousers
                            where trouser.Id == id
                            select trouser).SingleOrDefault();
                Trousers = data;
            }
        }
        public ActionResult OnPost()
        {
            var trousers = Trousers;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _Context.Entry(trousers).Property(x => x.Name).IsModified = true;
            _Context.Entry(trousers).Property(x => x.Description).IsModified = true;
            _Context.Entry(trousers).Property(x => x.Price).IsModified = true;
            _Context.Entry(trousers).Property(x => x.ImageUrl).IsModified = true;
            _Context.Entry(trousers).Property(x => x.Brand).IsModified = true;
            _Context.Entry(trousers).Property(x => x.TypeOf).IsModified = true;
            _Context.Entry(trousers).Property(x => x.Gender).IsModified = true;
            _Context.Entry(trousers).Property(x => x.Size).IsModified = true;
            _Context.Entry(trousers).Property(x => x.Color).IsModified = true;

            _Context.SaveChanges();
            return RedirectToPage("AllTrousers");
        }
    }
}
