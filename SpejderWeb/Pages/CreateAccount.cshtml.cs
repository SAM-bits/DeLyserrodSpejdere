using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages
{
    public class CreateAccountModel : PageModel
    {
        private ICreateAccount _createAccount;

        public CreateAccountModel(ICreateAccount createAccount)
        {
            _createAccount = createAccount;
        }

        [BindProperty]
        public Person Person { get; set; } = new();

        [TempData]
        public string Message { get; set; }

        public IActionResult OnPost()
        {
            _createAccount.Create(Person);

            Message = "Person er tilføjet ";

            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}