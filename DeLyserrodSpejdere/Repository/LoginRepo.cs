using DeLyserrodSpejdere.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeLyserrodSpejdere.Repository
{
    public class LoginRepo : ILoginRepo
    {
        public (bool, bool, int) LoginController(string username, string password)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"select SpejderLogin.Username,SpejderLogin.UserPassword , person.IsSupervisor as iSSuperVisor , Person.PersonId as PersonId from SpejderLogin
                                inner join Person on SpejderLogin.PersonId = Person.PersonId
                                where SpejderLogin.UserName=@UserName and SpejderLogin.UserPassword=@UserPassword";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"UserName", username);
            cmd.Parameters.AddWithValue(@"UserPassword", password);

            SqlDataReader reader = cmd.ExecuteReader();
            int loggedId = 0;
            bool usercontrol = false;
            bool isSupervioser = false;

            while (reader.Read())
            {
                if (username == reader.GetString(0) && password == reader.GetString(1) && reader.GetInt32(2) > 0)
                {
                    usercontrol = true;
                    isSupervioser = true;
                }
                else if (username == reader.GetString(0) && password == reader.GetString(1) && reader.GetInt32(2) < 1)
                {
                    usercontrol = true;
                    isSupervioser = false;
                }
                else
                {
                    usercontrol = false;
                    isSupervioser = false;
                }

                loggedId = reader.GetInt32(3);
            }

            DBConnector.DisconnectToDb();
            return (usercontrol, isSupervioser, loggedId);
        }

        public string ReadPersonById(int? id)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Select CONCAT( Person.FirstName ,' ', Person.LastName) from Person where PersonId = @id";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"id", id);

            string firstLastName = "";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                firstLastName = reader.GetString(0);
            }

            reader.Close();
            DBConnector.DisconnectToDb();

            return firstLastName;
        }
    }
}