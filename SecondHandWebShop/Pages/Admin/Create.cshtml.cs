using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandWebShop.Data;
using SecondHandWebShop.Models;

namespace SecondHandWebShop.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly SecondHandWebShop.Data.ProductContext _context;

        public CreateModel(SecondHandWebShop.Data.ProductContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Clothing Clothing { get; set; }
        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(UploadedImage != null)
            {
                var file = "./wwwroot/img/" + UploadedImage.FileName;
                using(var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(fileStream);
                }
                var imageUrl = "/img/" + UploadedImage.FileName;
                Clothing.ImageUrl = imageUrl;
            }
            _context.Clothing.Add(Clothing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
