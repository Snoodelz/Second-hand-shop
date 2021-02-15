using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondHandWebShop.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            //try
            //{
            //    PassUsr();
            //    if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            //    {
            //        return RedirectToPage("/Privacy");
            //    }
            //    else if (UserName.Contains("admin@admin.com") && Password.Contains("admin"))
            //    {
            //        return RedirectToPage("/AdminView");
            //    }
            //    return RedirectToPage("/Privacy");
            //}
            //catch (System.NullReferenceException)
            //{
            //    return RedirectToPage("/Privacy");
            //}
            if (UserName == "admin@admin.com" && Password == "admin")
            {
                HttpContext.Session.SetString("username", UserName);
                return RedirectToPage("/Admin/Index");
            }
            else
            {
                Message = "Invalid";
                return Page();
            }

        }
    }
}
