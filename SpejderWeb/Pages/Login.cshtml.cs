using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages
{
    public class LoginModel : PageModel
    {
        private ILoginRepo _login;

        public LoginModel(ILoginRepo login)
        {
            _login = login;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string UserPassword { get; set; }

        public IActionResult OnPost()
        {
            (bool loginOk, bool supervisor) = _login.LoginController(UserName, UserPassword);

            if (loginOk == true && supervisor == true)
            {
                Message = "Du er logget ind som en adminstrator";
                return RedirectToPage("/Admin/AdminLogin");
            }
            if (loginOk == true && supervisor == false)
            {
                Message = "Du er logget ind som en bruger";
                return RedirectToPage("/User/UserLogin");
            }

            return RedirectToPage("/Login");
        }

        public void OnGet()
        {
        }
    }
}