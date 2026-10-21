using DeLyserrodSpejdere.Model;
using Microsoft.Data.SqlClient;

namespace DeLyserrodSpejdere.Repository
{
    public class AdminLoginRepo
    {
        public void CreateActivities(Activities act)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Insert Into Activities (NameOfActivites,DetailsAboutActivities, StartDate,StartTime,EndTime,LimitOfMembers,AgeRestrictions , SpecialCharacter,Address,CityId)
                            Values (@NameOfActivites,@DetailsAboutActivities,@StartDate,@StartTime,@EndTime,@LimitsOfMembers,@AgeRestrictions,@SpecialCharacter,@Address,(Select CityId from City where CityName=@CityName And PostCode=@PostCode))";

            SqlCommand cmd = new SqlCommand(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"NameOfActivites", act.NameOfActivites);
            cmd.Parameters.AddWithValue(@"DetailsAboutActivities", act.DetailsAboutActivites);
            cmd.Parameters.AddWithValue(@"StartDate", act.StartDate);
            cmd.Parameters.AddWithValue(@"StartTime", act.StartTime);
            cmd.Parameters.AddWithValue(@"EndTime", act.EndTime);
            cmd.Parameters.AddWithValue(@"LimitsOfMembers", act.LimitOfMemebers);
            cmd.Parameters.AddWithValue(@"AgeRestrictions", act.AgeRestrictions);
            cmd.Parameters.AddWithValue(@"SpecialCharacter", act.SpecialCharacter);
            cmd.Parameters.AddWithValue(@"Address", act.Address);
            cmd.Parameters.AddWithValue(@"CityName", act.CityName);
            cmd.Parameters.AddWithValue(@"PostCode", act.PostCode);

            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Aktiviteten er oprettet. : ");
            }
            DBConnector.DisconnectToDb();
        }

        public List<Activities> ReadActivitiesByID(int id)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"select Activities.* ,CityName as City , PostCode as PostCode from Activities
                                inner join City on City.CityId = Activities.CityId where ActivitiesId = @id; ";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Activities> list = new();
            Activities act = new();

            while (reader.Read())
            {
                act.ActivitieId = reader.GetInt32(0);
                act.NameOfActivites = reader.GetString(1);
                act.DetailsAboutActivites = reader.GetString(2);
                act.StartDate = DateOnly.FromDateTime(reader.GetDateTime(3));
                act.StartTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(4));
                act.EndTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(5));
                act.LimitOfMemebers = reader.GetInt32(6);
                act.AgeRestrictions = reader.GetInt32(7);
                act.SpecialCharacter = (SpecialCharacter)reader.GetInt32(8);
                act.Address = reader.GetString(10);
                //city
                act.CityName = reader.GetString(11);
                act.PostCode = reader.GetInt32(12);
            }
            reader.Close();

            list.Add(act);
            DBConnector.DisconnectToDb();

            return list;
        }













        public void DeleteActivitesbyId(int id)
        {
            DBConnector.ConnectToDB();
            string sqlComm = @"Delete from Activities where ActivitiesId = @id";

            SqlCommand cmd = new SqlCommand(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"id", id);

            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Aktivitet med id = ({id}) er nu slettet. ");
            }
            DBConnector.DisconnectToDb();
        }



    }
}