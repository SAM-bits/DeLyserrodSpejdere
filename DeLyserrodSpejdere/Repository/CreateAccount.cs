using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeLyserrodSpejdere.Repository
{
    public class CreateAccount : ICreateAccount
    {
        public bool Create(Person account)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Insert Into Person (IsSupervisor,FirstName,LastName,Email,PhoneNumber,Age,Adress,CityId,SpecialCharacter,UserName,UserPassword,UserPasswordConfirm)
                                Output inserted.PersonId
                                Values (@IsSupervisor,@FirstName,@LastName,@Email,@PhoneNumber,@Age,@Adress,(Select CityId from City Where CityName Like @CityName and PostCode like @PostCode),
                                  @SpecialCharacter,@UserName,@UserPassword,@UserPasswordConfirm)";

            SqlCommand cmd = new SqlCommand(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"IsSupervisor", account.IsSupervisor);
            cmd.Parameters.AddWithValue(@"FirstName", account.FirstName);
            cmd.Parameters.AddWithValue(@"LastName", account.LastName);
            cmd.Parameters.AddWithValue(@"Email", account.Email);
            cmd.Parameters.AddWithValue(@"PhoneNumber", account.PhoneNumber);
            cmd.Parameters.AddWithValue(@"Age", account.Age);
            cmd.Parameters.AddWithValue(@"Adress", account.Adress);
            cmd.Parameters.AddWithValue(@"CityName","%"+ account.CityName +"%");
            cmd.Parameters.AddWithValue(@"PostCode", account.PostCode);
            cmd.Parameters.AddWithValue(@"SpecialCharacter", account.SpeacialCharacters);
            cmd.Parameters.AddWithValue(@"UserName", account.UserName);
            cmd.Parameters.AddWithValue(@"UserPassword", account.UserPassword);
            cmd.Parameters.AddWithValue(@"UserPasswordConfirm", account.UserPasswordConfirm);

            int id = (int)cmd.ExecuteScalar();
            if (id > 0)
            {
                AutoLoginCreater(id);
            }

            bool ok = false;

            if (id > 0)
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }

        public void AutoLoginCreater(int id)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"Select Top 1 PersonId,UserName,UserPassword From Person
                                  order by PersonId DESC ";
            SqlCommand cmd = new SqlCommand(sqlComm, DBConnector.SqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            int lastId = 0;
            string userName = "";
            string userPassword = "";
            while (reader.Read())
            {
                lastId = reader.GetInt32(0);
                userName = reader.GetString(1);
                userPassword = reader.GetString(2);
            }
            reader.Close();

            if (lastId == id)
            {
                string createLogin = @"Insert into SpejderLogin (PersonId,UserName,UserPassword)
                                    values (@PersonId, @UserName,@UserPassword)";

                SqlCommand create = new SqlCommand(createLogin, DBConnector.SqlConnection);

                create.Parameters.AddWithValue(@"Personid", lastId);
                create.Parameters.AddWithValue(@"UserName", userName);
                create.Parameters.AddWithValue(@"UserPassword", userPassword);

                if (create.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("Bruger navn oprettet. ");
                }
            }
            DBConnector.DisconnectToDb();
        }
    }
}