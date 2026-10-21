using DeLyserrodSpejdere.Model;

namespace DeLyserrodSpejdere.Interface
{
    public interface ICreateAccount
    {
        void AutoLoginCreater(int id);

        void Create(Person account);
    }
}