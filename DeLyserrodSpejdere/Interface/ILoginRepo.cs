namespace DeLyserrodSpejdere.Repository
{
    public interface ILoginRepo
    {
        (bool, bool, int) LoginController(string username, string password);

        string ReadPersonById(int? id);
    }
}