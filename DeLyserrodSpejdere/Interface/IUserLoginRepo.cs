using DeLyserrodSpejdere.Model;

namespace DeLyserrodSpejdere.Interface
{
    public interface IUserLoginRepo
    {
        void JoinActivitiesByPersonId(int activitesId, int personId);

        void LeaveActivities(int id);

        List<Activities> ShowActivities();
    }
}