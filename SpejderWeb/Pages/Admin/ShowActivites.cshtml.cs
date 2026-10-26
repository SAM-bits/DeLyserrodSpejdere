using DeLyserrodSpejdere.Model;
using DeLyserrodSpejdere.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages.Admin
{
    public class ShowAktivitesModel : PageModel
    {

        private IAdminLoginRepo _admin;


        public ShowAktivitesModel(IAdminLoginRepo admin)
        {
            _admin = admin;
        }


        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string SearchCity { get; set; }
        [BindProperty]
        public string ActivitiesName { get; set; }

        
        [BindProperty]
        public string DateSearch { get; set; }
        [BindProperty]
        public string DateSearch1 { get; set; }


        public List<Activities> ActivitiesListe { get; set; } =new();


        public void OnPostSearchDate()
        {

            Console.WriteLine(DateSearch1);
            Console.WriteLine(DateSearch);

            ActivitiesListe = _admin.SearchForActivities( DateSearch,DateSearch1);
        }
        public void OnPostSearchName()
        {
            ActivitiesListe = _admin.SearchForActivitiesByName( ActivitiesName,SearchCity);
        }






    }
}
