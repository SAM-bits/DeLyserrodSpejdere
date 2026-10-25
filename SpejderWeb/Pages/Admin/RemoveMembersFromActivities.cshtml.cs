using DeLyserrodSpejdere.Model;
using DeLyserrodSpejdere.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages.Admin
{
    public class RemoveActivitesModel : PageModel
    {
        private IAdminLoginRepo _admin;

        public RemoveActivitesModel(IAdminLoginRepo admin)
        {
            _admin = admin;
        }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public int ActivitieId { get; set; }

        [TempData]
        public string ActivitieMessage { get; set; }

        public string PersonMessage { get; set; }

        public List<Activities> ShowActivities { get; set; } = new();
        public List<Person> ShowPerson { get; set; } = new();

        public void OnPostShowMembers()
        {
            if (_admin.ActivitieIdExist(ActivitieId) == true)
            {
                (ShowActivities, ShowPerson) = _admin.MemebersRegisterToActivites(ActivitieId, PersonId);
            }
            if (_admin.PersonIdExist(PersonId) == true)
            {
                (ShowActivities, ShowPerson) = _admin.MemebersRegisterToActivites(ActivitieId, PersonId);
            }

            if (_admin.ActivitieIdExist(ActivitieId) == false)
            {
                ActivitieMessage = $"Kan ikke finde aktivitetsId :{ActivitieId}";
            }
            if (_admin.PersonIdExist(PersonId) == false)
            {
                PersonMessage = $"Kan ikke finde PersonId :{PersonId}";
            }
        }

        public void OnPostRemoveUser(int id)
        {
            Console.WriteLine($"du modtager id {id}");
            Console.WriteLine($"{OnPostRemoveUser}");
            _admin.RemoveUserFromActivitieByPersonId(id);
        }
    }
}