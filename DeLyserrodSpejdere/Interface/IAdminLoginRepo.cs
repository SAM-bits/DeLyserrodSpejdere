using DeLyserrodSpejdere.Model;

namespace DeLyserrodSpejdere.Repository
{
    public interface IAdminLoginRepo
    {
        bool ActivitieIdExist(int id);

        List<Activities> SearchForActivitiesByDate(string dateTime, string dateTime1);

        List<Activities> SearchForActivitiesByName(string name, string city);

        bool PersonIdExist(int id);

        void CreateActivities(Activities act);

        void DeleteActivitesbyId(int id);

        List<Activities> ReadActivitiesByID(int id);

        void RemoveUserFromActivitieByPersonId(int id);

        (List<Activities>, List<Person>) MemebersRegisterToActivites(int acId, int persId);

        List<ActivitesRegister> ShowRegisteredInActivities(int id);

        void UpdateActivitie(Activities upAc, int id);
    }
}