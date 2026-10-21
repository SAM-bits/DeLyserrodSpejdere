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

        public List<Activities> ReadByID()
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"select * from Activities ";
            string sqlCommCity = @"select * from City where  ";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Activities> list = new();
            Activities act = new();

            while (reader.Read())
            {
                act.ActivitieId = reader.GetInt32(0);
                act.NameOfActivites = reader.GetString(1);
                act.DetailsAboutActivites = reader.GetString(2);
                act.StartDate = DateOnly.FromDateTime(reader.GetDateTime(3));
                act.StartTime = TimeOnly.FromDateTime(reader.GetDateTime(4));
                act.EndTime = TimeOnly.FromDateTime(reader.GetDateTime(5));
                act.LimitOfMemebers = reader.GetInt32(6);
                act.AgeRestrictions = reader.GetInt32(7);
                act.SpecialCharacter = (SpecialCharacter)reader.GetInt32(8);
                act.CityName = reader.GetString(9);
                act.Address = reader.GetString(10);
            }
        }
    }
}