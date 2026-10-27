using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeLyserrodSpejdere.Repository
{
    public class UserLoginRepo : IUserLoginRepo
    {
        public List<Activities> ShowActivities()
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Select Activities.* NameOfActivites as AktivtetsNavn , DetailsAboutActivities as AktivitetsDetaljer , StartDate as OpstartsDato , StartTime as StartTidspunkt,EndTime as SlutTid , AgeRestrictions as AlderGrænse , SpecialCharacter as SpejderTegn , Address as Adresse from Activities";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Activities> liste = new();

            while (reader.Read())
            {
                Activities show = new();

                show.NameOfActivites = reader.GetString(0);
                show.DetailsAboutActivites = reader.GetString(1);
                show.StartDate = DateOnly.FromDateTime(reader.GetDateTime(2));
                show.StartTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(3));
                show.EndTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(4));
                show.AgeRestrictions = reader.GetInt32(5);
                show.SpecialCharacter = (SpecialCharacter)reader.GetInt32(6);
                show.Address = reader.GetString(7);

                liste.Add(show);
            }
            reader.Close();

            DBConnector.DisconnectToDb();

            return liste;
        }

        public List<Activities> ShowJoinedActivities(int? id)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Select ActivitiesRegister.*, Activities.NameOfActivites as AcName , Activities.StartDate as StartDate , Activities.StartTime as TimeStart , Activities.EndTime as TimeEnd, Activities.Address as Adresse , City.CityName as CityName , city.PostCode as PostCode from ActivitiesRegister
                                inner join Activities on ActivitiesRegister.ActivitiesId = Activities.ActivitiesId
                                inner join City on Activities.CityId = City.CityId
                                where ActivitiesRegister.PersonId = @id";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Activities> liste = new();

            while (reader.Read())
            {
                Activities show = new();

                show.NameOfActivites = reader.GetString(3);
                show.StartDate = DateOnly.FromDateTime(reader.GetDateTime(4));
                show.StartTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(5));
                show.EndTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(6));
                show.Address = reader.GetString(7);
                show.CityName = reader.GetString(8);
                show.PostCode = reader.GetInt32(9);

                liste.Add(show);
            }
            reader.Close();

            DBConnector.DisconnectToDb();

            return liste;
        }

        public void JoinActivitiesByPersonId(int activitesId, int? personId)
        {
            DBConnector.ConnectToDB();
            string sqlComm = @"insert into ActivitiesRegister(ActivitiesId,PersonId)
                                values (@activitesId,@personId)";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"activitesId", activitesId);
            cmd.Parameters.AddWithValue(@"personId", personId);

            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Tilmelding er udført. ");
            }
            DBConnector.DisconnectToDb();
        }

        public void LeaveActivities(int? id)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"delete from ActivitiesRegister where PersonId = @id";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);
            cmd.Parameters.AddWithValue(@"id", id);

            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Du er frameldt fra aktiviteten som har id : ({id})");
            }
            DBConnector.DisconnectToDb();
        }

        public List<Activities> SearchForActivitiesByDate(string dateTime, string dateTime1)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Select Activities.NameOfActivites as NameAct,Activities.DetailsAboutActivities as Details, Activities.StartDate as StartDate, Activities.StartTime as TimeStart , Activities.EndTime as EndTime , Activities.AgeRestrictions as AgeLimit,Activities.LimitOfMembers as Limits ,Count(ActivitiesRegister.ActivitiesId) as LimitCounter , City.CityName as City, City.PostCode as PostNumber , Activities.ActivitiesId as Id from Activities
                left join ActivitiesRegister on Activities.ActivitiesId= ActivitiesRegister.ActivitiesId
                inner join City on Activities.CityId = City.CityId
                where  activities.StartDate between @dateTime and @dateTime1
                group by ActivitiesRegister.ActivitiesId,Activities.NameOfActivites,StartDate,AgeRestrictions,LimitOfMembers,CityName,PostCode,Activities.DetailsAboutActivities,Activities.StartTime,Activities.EndTime,Activities.ActivitiesId";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"dateTime", dateTime);
            cmd.Parameters.AddWithValue(@"dateTime1", dateTime1);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Activities> list = new();

            while (reader.Read())
            {
                Activities act = new();

                act.NameOfActivites = reader.GetString(0);
                act.DetailsAboutActivites = reader.GetString(1);
                act.StartDate = DateOnly.FromDateTime(reader.GetDateTime(2));
                act.StartTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(3));
                act.EndTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(4));
                act.AgeRestrictions = reader.GetInt32(5);
                act.LimitOfMemebers = reader.GetInt32(6);
                act.LimitCounter = reader.GetInt32(7);
                //city
                act.CityName = reader.GetString(8);
                act.PostCode = reader.GetInt32(9);
                act.ActivitieId = reader.GetInt32(10);

                list.Add(act);
            }
            reader.Close();

            DBConnector.DisconnectToDb();

            return list;
        }

        public List<Activities> SearchForActivitiesByName(string name, string city)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Select Activities.NameOfActivites as NameAct,Activities.DetailsAboutActivities as Details, Activities.StartDate as StartDate, Activities.StartTime as TimeStart , Activities.EndTime as EndTime , Activities.AgeRestrictions as AgeLimit,Activities.LimitOfMembers as Limits ,Count(ActivitiesRegister.ActivitiesId) as LimitCounter , City.CityName as City, City.PostCode as PostNumber , Activities.ActivitiesId as Id from Activities
                left join ActivitiesRegister on Activities.ActivitiesId= ActivitiesRegister.ActivitiesId
                inner join City on Activities.CityId = City.CityId
                where City.CityName like @city or Activities.NameOfActivites like @name
                group by ActivitiesRegister.ActivitiesId,Activities.NameOfActivites,StartDate,AgeRestrictions,LimitOfMembers,CityName,PostCode,Activities.DetailsAboutActivities,Activities.StartTime,Activities.EndTime,Activities.ActivitiesId";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"name", "%" + name + "%");
            cmd.Parameters.AddWithValue(@"city", "%" + city + "%");

            SqlDataReader reader = cmd.ExecuteReader();

            List<Activities> list = new();

            while (reader.Read())
            {
                Activities act = new();

                act.NameOfActivites = reader.GetString(0);
                act.DetailsAboutActivites = reader.GetString(1);
                act.StartDate = DateOnly.FromDateTime(reader.GetDateTime(2));
                act.StartTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(3));
                act.EndTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(4));
                act.AgeRestrictions = reader.GetInt32(5);
                act.LimitOfMemebers = reader.GetInt32(6);
                act.LimitCounter = reader.GetInt32(7);
                //city
                act.CityName = reader.GetString(8);
                act.PostCode = reader.GetInt32(9);
                act.ActivitieId = reader.GetInt32(10);

                list.Add(act);
            }
            reader.Close();

            DBConnector.DisconnectToDb();

            return list;
        }
    }
}