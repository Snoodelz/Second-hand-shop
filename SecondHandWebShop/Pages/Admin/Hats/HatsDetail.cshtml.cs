using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SecondHandWebShop.Pages.Hats
{
    public class HatsDetailModel : PageModel
    {
        ProductContext _Context;

        public HatsDetailModel(ProductContext productContext)
        {
            _Context = productContext;
        }

        public Hat Hats { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hats = await _Context.Hats.FirstOrDefaultAsync(m => m.Id == id);

            if (Hats == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}