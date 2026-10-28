using DeLyserrodSpejdere.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DeLyserrodSpejdere.Repository
{
    public class LoginRepo : ILoginRepo
    {
        public (bool, bool, int, string) LoginController(string username, string password)
        {
            DBConnector.ConnectToDB();

            string sqlComm = @"select SpejderLogin.Username,SpejderLogin.UserPassword , person.IsSupervisor as iSSuperVisor , Person.PersonId as PersonId , ConCat(Person.FirstName , ' ' , Person.LastName) from SpejderLogin
                                inner join Person on SpejderLogin.PersonId = Person.PersonId
                                where SpejderLogin.UserName=@UserName and SpejderLogin.UserPassword=@UserPassword";

            SqlCommand cmd = new(sqlComm, DBConnector.SqlConnection);

            cmd.Parameters.AddWithValue(@"UserName", username);
            cmd.Parameters.AddWithValue(@"UserPassword", password);

            SqlDataReader reader = cmd.ExecuteReader();
            string firstLastName = "";
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
                firstLastName = reader.GetString(4);
            }

            DBConnector.DisconnectToDb();
            return (usercontrol, isSupervioser, loggedId, firstLastName);
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

        public void UpdatePersonById(Person updatePerson, int? id)
        {
            DBConnector.ConnectToDB();

            Console.WriteLine(updatePerson.FirstName);
            string sqlCommUpdate = @" update Person
                                    Set FirstName = @FirstName , LastName=@LastName , Email =@Email , PhoneNumber=@PhoneNumber , Age=@Age , Adress = @Address ,
                                    CityId=(select CityId from City where CityName like @CityName and PostCode like @PostCode ) ,SpecialCharacter =@SpecialCharacter,
                                    UserName=@UserName
                                    where Person.PersonId = @id ";

            SqlCommand updateCmd = new(sqlCommUpdate, DBConnector.SqlConnection);

            updateCmd.Parameters.AddWithValue(@"id", id);
            updateCmd.Parameters.AddWithValue(@"FirstName", updatePerson.FirstName);
            updateCmd.Parameters.AddWithValue(@"LastName", updatePerson.LastName);
            updateCmd.Parameters.AddWithValue(@"Email", updatePerson.Email);
            updateCmd.Parameters.AddWithValue(@"PhoneNumber", updatePerson.PhoneNumber);
            updateCmd.Parameters.AddWithValue(@"Age", updatePerson.Age);
            updateCmd.Parameters.AddWithValue(@"Address", updatePerson.Adress);
            updateCmd.Parameters.AddWithValue(@"CityName", "%" + updatePerson.CityName + "%");
            updateCmd.Parameters.AddWithValue(@"PostCode", updatePerson.PostCode);
            updateCmd.Parameters.AddWithValue(@"SpecialCharacter", updatePerson.SpeacialCharacters);
            updateCmd.Parameters.AddWithValue(@"UserName", updatePerson.UserName);

            updateCmd.ExecuteNonQuery();

            DBConnector.DisconnectToDb();
        }

        public List<Person> ShowPerseonDetailsById(int? id)
        {
            DBConnector.ConnectToDB();

            string sqlCommList = @"Select Person.* , City.CityName as CityName , City.PostCode as PostCode from Person
                                    left join City on Person.CityId=City.CityId
                                    where PersonId=@id";

            SqlCommand listCmd = new(sqlCommList, DBConnector.SqlConnection);

            listCmd.Parameters.AddWithValue(@"id", id);

            SqlDataReader reader = listCmd.ExecuteReader();
            List<Person> listperson = new();
            Person person = new();
            while (reader.Read())
            {
                person.FirstName = reader.GetString(2);
                person.LastName = reader.GetString(3);
                person.Email = reader.GetString(4);
                person.PhoneNumber = reader.GetString(5);
                person.Age = reader.GetInt32(6);
                person.Adress = reader.GetString(7); ;
                person.CityName = reader.GetString(13);
                person.PostCode = reader.GetInt32(14);
                person.SpeacialCharacters = (SpecialCharacter)reader.GetInt32(9);
                person.UserName = reader.GetString(10);
            }
            reader.Close();
            listperson.Add(person);

            foreach (Person item in listperson)
            {
                Console.WriteLine(item);
            }

            DBConnector.DisconnectToDb();

            return listperson;
        }
    }
}