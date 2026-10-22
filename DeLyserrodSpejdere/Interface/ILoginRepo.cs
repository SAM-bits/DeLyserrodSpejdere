namespace DeLyserrodSpejdere.Repository
{
    public interface ILoginRepo
    {
        (bool, bool) LoginController(string username, string password);
    }
}