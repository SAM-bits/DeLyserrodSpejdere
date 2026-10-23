using DeLyserrodSpejdere.Model;

namespace DeLyserrodSpejdere.Repository
{
    public interface IAdminLoginRepo
    {
        bool ActivitieIdExist(int id);
        void CreateActivities(Activities act);
        void DeleteActivitesbyId(int id);
        List<Activities> ReadActivitiesByID(int id);
        void RemoveUserFromActivitieByPersonId(int id);
        List<ActivitesRegister> ShowRegisteredInActivities(int id);
        void UpdateActivitie(Activities upAc,int id);
    }
}