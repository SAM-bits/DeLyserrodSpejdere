using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Model;
using DeLyserrodSpejdere.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages.User
{
    public class ShowActivitiesModel : PageModel
    {
        private IUserLoginRepo _user;

        public ShowActivitiesModel(IUserLoginRepo user)
        {
            _user = user;
        }

        [BindProperty]
        public string AcName { get; set; }

        [BindProperty]
        public string CityName { get; set; }

        [BindProperty]
        public string Date1 { get; set; }

        [BindProperty]
        public string Date2 { get; set; }

        public int? PersonId { get; set; }

        public List<Activities> ActivitiesListe { get; set; } = new();

        public void OnPostDateSearch()
        {
            Console.WriteLine(Date1);
            Console.WriteLine(Date2);
            ActivitiesListe = _user.SearchForActivitiesByDate(Date1, Date2);
        }

        public void OnPostNameSearch()
        {
            ActivitiesListe = _user.SearchForActivitiesByName(AcName, CityName);
        }

        public void OnPostJoinActivitie(int acId)
        {
            PersonId = HttpContext.Session.GetInt32("LoggedId");
            Console.WriteLine(acId);
            Console.WriteLine(PersonId);
            if (PersonId > 0 || PersonId != null)
            {
                _user.JoinActivitiesByPersonId(acId, PersonId);
            }
        }
    }
}