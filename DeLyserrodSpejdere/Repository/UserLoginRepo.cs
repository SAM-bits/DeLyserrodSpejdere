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

            string sqlComm = @"Select  NameOfActivites as AktivtetsNavn , DetailsAboutActivities as AktivitetsDetaljer , StartDate as OpstartsDato , StartTime as StartTidspunkt,EndTime as SlutTid , AgeRestrictions as AlderGrænse , SpecialCharacter as SpejderTegn , Address as Adresse from Activities";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Activities> liste = new();
            Activities show = new();

            while (reader.Read())
            {
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

        public void JoinActivitiesByPersonId(int activitesId, int personId)
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

        public void LeaveActivities(int id)
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
    }
}