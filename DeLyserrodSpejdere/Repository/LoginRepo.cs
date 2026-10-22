using DeLyserrodSpejdere.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeLyserrodSpejdere.Repository
{
    public class LoginRepo : ILoginRepo
    {
        public (bool, bool) LoginController(string username, string password)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"select SpejderLogin.Username,SpejderLogin.UserPassword , person.IsSupervisor as iSSuperVisor from SpejderLogin
                                inner join Person on SpejderLogin.PersonId = Person.PersonId
                                where SpejderLogin.UserName=@UserName and SpejderLogin.UserPassword=@UserPassword";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"UserName", username);
            cmd.Parameters.AddWithValue(@"UserPassword", password);

            SqlDataReader reader = cmd.ExecuteReader();

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
            }

            DBConnector.DisconnectToDb();
            return (usercontrol, isSupervioser);
        }
    }
}