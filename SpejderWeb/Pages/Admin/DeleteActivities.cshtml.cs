using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Model;
using DeLyserrodSpejdere.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace SpejderWeb.Pages.Admin
{
    public class DeleteActivitiesModel : PageModel
    {
        private IAdminLoginRepo _admin;

        public DeleteActivitiesModel(IAdminLoginRepo admin)
        {
            _admin = admin;
        }

        [BindProperty]
        public int Id { get; set; }

        [TempData]
        public string Message { get; set; }

        public List<Activities> ActivitiesList { get; set; }

        public IActionResult OnPost()
        {
            if (_admin.ActivitieIdExist(Id) == true)
            {
                _admin.DeleteActivitesbyId(Id);

                Message = "Aktivtet er blevet slettet";
            }
            else
            {
                Message = "Aktivtet eksistere ikke prøv igen";
            }

            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}