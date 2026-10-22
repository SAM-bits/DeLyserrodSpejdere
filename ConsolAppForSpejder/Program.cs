using DeLyserrodSpejdere.Model;
using DeLyserrodSpejdere.Repository;

namespace ConsolAppForSpejder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ////Activities aktivitet = new();
            ////aktivitet.ActivitieId = 1;
            ////aktivitet.NameOfActivites = " Bål hygge ";
            ////aktivitet.DetailsAboutActivites = " Vi skal lave bål og skumfiduser";
            ////aktivitet.StartDate = new DateOnly(2026, 10, 25);
            ////aktivitet.StartTime = new TimeOnly(09, 00, 00);
            ////aktivitet.EndTime = new TimeOnly(18, 00, 00);
            ////aktivitet.LimitOfMemebers = 2;
            ////aktivitet.AgeRestrictions = 15;
            ////aktivitet.SpecialCharacter = SpecialCharacter.Balmaerke;
            ////aktivitet.Address = "SpejderVej 13";
            ////aktivitet.CityName = "Roskilde";
            ////aktivitet.PostCode = 4000;

            //Activities aktivitet1 = new();
            //aktivitet1.ActivitieId = 1;
            //aktivitet1.NameOfActivites = " SkoveTur ";
            //aktivitet1.DetailsAboutActivites = " Vi skal på skove tur og plukke blåbære";
            //aktivitet1.StartDate = new DateOnly(2026, 11, 25);
            //aktivitet1.StartTime = new TimeOnly(09, 00, 00);
            //aktivitet1.EndTime = new TimeOnly(18, 00, 00);
            //aktivitet1.LimitOfMemebers = 5;
            //aktivitet1.AgeRestrictions = 10;
            //aktivitet1.SpecialCharacter = SpecialCharacter.IngenTegn;
            //aktivitet1.Address = "SpejderVej 13";
            //aktivitet1.CityName = "Roskilde";
            //aktivitet1.PostCode = 4000;

            ////AdminLoginRepo activitiesCreater = new();
            ////activitiesCreater.CreateActivities(aktivitet);
            //////activitiesCreater.CreateActivities(aktivitet1);

            ////Person testPerson = new();
            ////Person testPerson1 = new();
            ////Person testPerson2 = new();

            ////testPerson.IsSupervisor = true;
            ////testPerson.FirstName = "Saif";
            ////testPerson.LastName = "Atyaif";
            ////testPerson.Email = "Saifatyaif@gmail.com";
            ////testPerson.PhoneNumber = "52177690";
            ////testPerson.Age = 35;
            ////testPerson.Adress = "Majengen 12";
            ////testPerson.CityName = "Solrød Strand";
            ////testPerson.PostCode = 2680;
            ////testPerson.SpeacialCharacters = SpecialCharacter.Balmaerke;
            ////testPerson.UserName = "SaifMadie";
            ////testPerson.UserPassword = "123456789!";
            ////testPerson.UserPasswordConfirm = "123456789!";

            ////testPerson1.IsSupervisor = true;
            ////testPerson1.FirstName = "Hamza";
            ////testPerson1.LastName = "Madie";
            ////testPerson1.Email = "HamzaMadie@gmail.com";
            ////testPerson1.PhoneNumber = "52447788";
            ////testPerson1.Age = 8;
            ////testPerson1.Adress = "Majengen 12";
            ////testPerson1.CityName = "Solrød Strand";
            ////testPerson1.PostCode = 2680;
            ////testPerson1.SpeacialCharacters = SpecialCharacter.Madlavningsmaerke;
            ////testPerson1.UserName = "HamzaMadie";
            ////testPerson1.UserPassword = "123456789!";
            ////testPerson1.UserPasswordConfirm = "123456789!";

            ////testPerson2.IsSupervisor = true;
            ////testPerson2.FirstName = "Noora";
            ////testPerson2.LastName = "Atyaif";
            ////testPerson2.Email = "Noora.B.Madie@gmail.com";
            ////testPerson2.PhoneNumber = "85558877";
            ////testPerson2.Age = 7;
            ////testPerson2.Adress = "Majengen 12";
            ////testPerson2.CityName = "Solrød Strand";
            ////testPerson2.PostCode = 2680;
            ////testPerson2.SpeacialCharacters = SpecialCharacter.Knobmaerke;
            ////testPerson2.UserName = "NooraMadie";
            ////testPerson2.UserPassword = "123456789!";
            ////testPerson2.UserPasswordConfirm = "123456789!";

            ////CreateAccount creater = new();

            //////creater.Create(testPerson);
            ////creater.Create(testPerson1);
            ////creater.Create(testPerson2);

            //AdminLoginRepo test = new();

            ////test.ShowRegisteredInActivities(1);

            ////foreach (var item in test.ShowRegisteredInActivities(2))
            ////{
            ////    Console.WriteLine(item);
            ////}

            ////test.RemoveUserFromActivitieByPersonId(1);

            ////test.UpdateActivitie(aktivitet1);

            //UserLoginRepo user = new();

            ////user.ShowActivities();
            ////foreach (var item in user.ShowActivities())
            ////{
            ////    Console.WriteLine(item);
            ////}

            ////user.JoinActivitiesByPersonId(2, 1);
            ////user.JoinActivitiesByPersonId(2, 2);
            ////user.JoinActivitiesByPersonId(2, 3);
            //user.LeaveActivities(2);

            LoginRepo log = new();

            Console.WriteLine(log.LoginController("SaifMadie", "3299256331!"));
        }
    }
}