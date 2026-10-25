using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Model;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace DeLyserrodSpejdere.Repository
{
    public class AdminLoginRepo : IAdminLoginRepo
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

        public void UpdateActivitie(Activities upAc, int id)
        {
            DBConnector.ConnectToDB();
            string sqlComm = @"Update Activities
                           SET NameOfActivites =@NameOfActivites ,DetailsAboutActivities=@DetailsAboutActivities, StartDate=@StartDate,StartTime=@StartTime,EndTime=@EndTime,LimitOfMembers=@LimitOfMembers,AgeRestrictions=@AgeRestrictions , SpecialCharacter =@SpecialCharacter,Address=@Address,CityId=(Select CityId from City where CityName=@CityName And PostCode=@PostCode)
                            Where ActivitiesId = @Id";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);
            cmd.Parameters.AddWithValue(@"Id", id);
            cmd.Parameters.AddWithValue(@"NameOfActivites", upAc.NameOfActivites);
            cmd.Parameters.AddWithValue(@"DetailsAboutActivities", upAc.DetailsAboutActivites);
            cmd.Parameters.AddWithValue(@"StartDate", upAc.StartDate);
            cmd.Parameters.AddWithValue(@"StartTime", upAc.StartTime);
            cmd.Parameters.AddWithValue(@"EndTime", upAc.EndTime);
            cmd.Parameters.AddWithValue(@"LimitOfMembers", upAc.LimitOfMemebers);
            cmd.Parameters.AddWithValue(@"AgeRestrictions", upAc.AgeRestrictions);
            cmd.Parameters.AddWithValue(@"SpecialCharacter", upAc.SpecialCharacter);
            cmd.Parameters.AddWithValue(@"Address", upAc.Address);
            cmd.Parameters.AddWithValue(@"CityName", upAc.CityName);
            cmd.Parameters.AddWithValue(@"PostCode", upAc.PostCode);

            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Updatering af Aktivitet med aktivetes id ({id}) er updateret.");
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

        public bool ActivitieIdExist(int id)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Select Count(*) from Activities where Activities.ActivitiesId = @id";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"id", id);

            int count = (int)cmd.ExecuteScalar();

            DBConnector.DisconnectToDb();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PersonIdExist(int id)
        {
            DBConnector.ConnectToDB();
            string sqlComm = @"Select Count(*) from Person where Person.Personid =@id";
            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"id", id);

            int count = (int)cmd.ExecuteScalar();

            DBConnector.DisconnectToDb();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ActivitesRegister> ShowRegisteredInActivities(int id)
        {
            DBConnector.ConnectToDB();
            string sqlComm = @"Select ActivitiesRegister.*, Person.FirstName , Person.LastName , Activities.NameOfActivites,Activities.StartDate   From ActivitiesRegister
                            inner join Person on ActivitiesRegister.PersonId = Person.Personid
                            inner join Activities on ActivitiesRegister.ActivitiesId = Activities.ActivitiesId Where Activities.ActivitiesId = @id";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"id", id);

            List<ActivitesRegister> list = new();
            ActivitesRegister reg = new();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reg.ActivitesRegisterId = reader.GetInt32(0);
                reg.ActivitieId = reader.GetInt32(1);
                reg.PersonId = reader.GetInt32(2);
                reg.FirstName = reader.GetString(3);
                reg.LastName = reader.GetString(4);
                reg.NameOfActivites = reader.GetString(5);
                reg.StartDate = DateOnly.FromDateTime(reader.GetDateTime(6));

                list.Add(reg);
            }

            reader.Close();

            DBConnector.DisconnectToDb();

            return list;
        }

        public void RemoveUserFromActivitieByPersonId(int id)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Delete From ActivitiesRegister where ActivitiesRegister.PersonId = @id ";
            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"id", id);

            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"bruger med Personid ({id}) er blevet fjernet fra aktiviteten.");
            }

            DBConnector.DisconnectToDb();
        }

        public (List<Activities>, List<Person>) MemebersRegisterToActivites(int acId, int persId)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Select Activities.NameOfActivites as AktivitieNavn ,Activities.StartDate as StartDato ,Activities.Address as Adresse ,Person.FirstName as FistName ,Person.LastName as LastName , Person.PhoneNumber as PhoneNumber , ActivitiesRegister.PersonId as PersonId From ActivitiesRegister
                            inner join Activities on ActivitiesRegister.ActivitiesId = Activities.ActivitiesId
                            inner join Person on ActivitiesRegister.PersonId = Person.PersonId
                            where ActivitiesRegister.ActivitiesId = @AcId or ActivitiesRegister.PersonId = @PersId ";
            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"AcId", acId);
            cmd.Parameters.AddWithValue(@"PersId", persId);

            SqlDataReader reader1 = cmd.ExecuteReader();

            Activities foundAc = new();

            List<Activities> acList = new();
            List<Person> persList = new();

            while (reader1.Read())
            {
                foundAc.NameOfActivites = reader1.GetString(0);
                foundAc.StartDate = DateOnly.FromDateTime(reader1.GetDateTime(1));
                foundAc.Address = reader1.GetString(2);
            }
            acList.Add(foundAc);
            reader1.Close();

            SqlDataReader reader2 = cmd.ExecuteReader();

            while (reader2.Read())
            {
                Person foundPer = new();

                foundPer.FirstName = reader2.GetString(3);
                foundPer.LastName = reader2.GetString(4);
                foundPer.PhoneNumber = reader2.GetString(5);
                foundPer.PersonId = reader2.GetInt32(6);

                persList.Add(foundPer);
            }

            reader2.Close();
            DBConnector.DisconnectToDb();
            return (acList, persList);
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