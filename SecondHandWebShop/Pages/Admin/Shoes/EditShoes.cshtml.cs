using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace SecondHandWebShop.Pages.Shoes
{
    public class EditShoesModel : PageModel
    {
        ProductContext _Context;
        public EditShoesModel(ProductContext productContext)
        {
            _Context = productContext;
        }

        [BindProperty]
        public Shoe Shoes { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from shoes in _Context.Shoes
                            where shoes.Id == id
                            select shoes).SingleOrDefault();
                Shoes = data;
            }
        }
        public ActionResult OnPost()
        {
            var hat = Shoes;
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
            _Context.Entry(hat).Property(x => x.Gender).IsModified = true;
            _Context.Entry(hat).Property(x => x.Size).IsModified = true;
            _Context.Entry(hat).Property(x => x.Material).IsModified = true;


            _Context.SaveChanges();
            return RedirectToPage("AllShoes");
        }
    }
}