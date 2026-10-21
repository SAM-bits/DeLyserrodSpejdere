using DeLyserrodSpejdere.Model;

namespace DeLyserrodSpejdere.Interface
{
    public interface IAdminLoginRepo
    {
        void CreateActivities(Activities act);
        void DeleteActivitesbyId(int id);
        List<Activities> ReadActivitiesByID(int id);
        void RemoveUserFromActivitieByPersonId(int id);
        List<ActivitesRegister> ShowRegisteredInActivities(int id);
        void UpdateActivitie(Activities upAc);
    }
}