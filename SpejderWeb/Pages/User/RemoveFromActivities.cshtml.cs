using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages.User
{
    public class RemoveFromActivitiesModel : PageModel
    {
        private IUserLoginRepo _user;

        public RemoveFromActivitiesModel(IUserLoginRepo user)
        {
            _user = user;
        }

        public List<Activities> ActivitiesListe { get; set; } = new();

        public void OnPostShowAc()
        {
            int? PersonId = HttpContext.Session.GetInt32("LoggedId");

            Console.WriteLine(PersonId);
            if (PersonId > 0 && PersonId != null)
            {
                ActivitiesListe = _user.ShowJoinedActivities(PersonId);
            }
        }

        public void OnPostLeaveAc()
        {
            int? PersonId = HttpContext.Session.GetInt32("LoggedId");
            if (PersonId > 0 && PersonId != null)
            {
                _user.LeaveActivities(PersonId);
            }
        }
    }
}