using DeLyserrodSpejdere.Model;
using DeLyserrodSpejdere.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpejderWeb.Pages.Admin
{
    public class UpdateAccountModel : PageModel
    {
        private ILoginRepo _login;

        public UpdateAccountModel(ILoginRepo login)
        {
            _login = login;
        }

        [BindProperty]
        public Person UpdatedPerson { get; set; } = new();

        public List<Person> PersonList { get; set; } = new();

        public void OnPost()
        {
            int? personId = HttpContext.Session.GetInt32("LoggedId");
            PersonList = _login.ShowPerseonDetailsById(personId);
            Console.WriteLine(personId);
        }

        public void OnPostUpdatePerson()
        {
            Console.WriteLine(UpdatedPerson.FirstName);
            int? personId = HttpContext.Session.GetInt32("LoggedId");
            _login.UpdatePersonById(UpdatedPerson, personId);
        }
    }
}