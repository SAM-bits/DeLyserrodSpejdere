using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages.Admin
{
    public class CreateActivitieModel : PageModel
    {
        private IAdminLoginRepo _admin;

        public CreateActivitieModel(IAdminLoginRepo admin)
        {
            _admin = admin;
        }

        [BindProperty]
        public Activities Activities { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnPost()
        {
            _admin.CreateActivities(Activities);

            Message = "Aktivitet er oprettet.";

            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}