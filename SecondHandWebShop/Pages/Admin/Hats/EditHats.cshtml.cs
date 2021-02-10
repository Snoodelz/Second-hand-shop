using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFDataAccessLibrary.Models;


namespace SecondHandWebShop.Pages.Hats
{
    public class EditHatsModel : PageModel
    {
        ProductContext _Context;
        public EditHatsModel(ProductContext productContext)
        {
            _Context = productContext;
        }
        
        [BindProperty]
        public Hat Hats { get; set; }
 
        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from hat in _Context.Hats
                            where hat.Id == id
                            select hat).SingleOrDefault();
                            Hats = data;
            }
        }
        public ActionResult OnPost()
        {
            var hat = Hats;
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
            _Context.Entry(hat).Property(x => x.Color).IsModified = true;

            _Context.SaveChanges();
            return RedirectToPage("AllHats");
        }
    }
}