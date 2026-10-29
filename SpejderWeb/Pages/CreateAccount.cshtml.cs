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
        public string CreateOk { get; set; }

        public IActionResult OnPost()
        {
            if (_createAccount.Create(Person) == true)
            {
                CreateOk = "Person er tilføjet ";
            }
            else
            {
                CreateOk = "Fejl ved oprettelse";
            }

            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}