using DeLyserrodSpejdere.Model;

namespace DeLyserrodSpejdere.Interface
{
    public interface IUserLoginRepo
    {
        void JoinActivitiesByPersonId(int activitesId, int? personId);

        void LeaveActivities(int? personId, int acId);

        List<Activities> ShowActivities();

        List<Activities> ShowJoinedActivities(int? id);

        List<Activities> SearchForActivitiesByDate(string dateTime, string dateTime1);

        List<Activities> SearchForActivitiesByName(string name, string city);
    }
}