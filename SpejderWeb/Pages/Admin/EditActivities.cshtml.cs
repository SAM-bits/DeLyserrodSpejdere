using DeLyserrodSpejdere.Model;
using DeLyserrodSpejdere.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages.Admin
{
    public class EditActivitiesModel : PageModel
    {
        private IAdminLoginRepo _admin;

        public EditActivitiesModel(IAdminLoginRepo admin)
        {
            _admin = admin;
        }

        [BindProperty]
        public int Id { get; set; }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Activities UpdatedActivities { get; set; } = new();

        public List<Activities> ActivitiesList { get; set; } = new();

        public void OnPostSearchId()
        {
            if (_admin.ActivitieIdExist(Id) == true)
            {
                ActivitiesList = _admin.ReadActivitiesByID(Id);
            }
            else
            {
                Message = "Aktiviteten kan ikke findes";
            }
        }

        public void OnPostUpdate(int id)
        {
            if (_admin.ActivitieIdExist(id) == true)
            {
                _admin.UpdateActivitie(UpdatedActivities, id);
            }
            Message = "Aktiviteten er blevet updateret.";
        }

        public void OnGet()
        {
        }
    }
}