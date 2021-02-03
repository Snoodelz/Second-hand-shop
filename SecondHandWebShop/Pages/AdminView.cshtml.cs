using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondHandWebShop.Pages
{
    public class AdminViewModel : PageModel
    {
        public string UserName { get; set; }
        public void OnGet()
        {
            UserName = HttpContext.Session.GetString("username");
        }



        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("/Login");
        }
    }
}
