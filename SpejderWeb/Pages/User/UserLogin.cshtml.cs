using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages.User
{
    public class UserLoginModel : PageModel
    {
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("LoggedId");
            return RedirectToPage("/Index");
        }
    }
}