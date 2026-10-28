using DeLyserrodSpejdere.Model;

namespace DeLyserrodSpejdere.Repository
{
    public interface ILoginRepo
    {
        (bool, bool, int, string) LoginController(string username, string password);

        string ReadPersonById(int? id);

        void UpdatePersonById(Person updatePerson, int? id);

        List<Person> ShowPerseonDetailsById(int? id);
    }
}