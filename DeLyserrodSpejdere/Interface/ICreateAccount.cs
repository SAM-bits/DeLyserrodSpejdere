using DeLyserrodSpejdere.Model;

namespace DeLyserrodSpejdere.Interface
{
    public interface ICreateAccount
    {
        void AutoLoginCreater(int id);

        bool Create(Person account);
    }
}