using DeLyserrodSpejdere.Model;

namespace DeLyserrodSpejdere.Interface
{
    public interface IUserLoginRepo
    {
        void JoinActivitiesByPersonId(int activitesId, int? personId);

        void LeaveActivities(int id);

        List<Activities> ShowActivities();

        List<Activities> SearchForActivitiesByDate(string dateTime, string dateTime1);

        List<Activities> SearchForActivitiesByName(string name, string city);
    }
}