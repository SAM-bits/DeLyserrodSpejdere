using DeLyserrodSpejdere.Model;
using DeLyserrodSpejdere.Repository;

namespace ConsolAppForSpejder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Activities aktivitet = new();
            aktivitet.ActivitieId = 1;
            aktivitet.NameOfActivites = " Bål hygge ";
            aktivitet.DetailsAboutActivites = " Vi skal lave bål og skumfiduser";
            aktivitet.StartDate = new DateOnly(2026, 10, 25);
            aktivitet.StartTime = new TimeOnly(09, 00, 00);
            aktivitet.EndTime = new TimeOnly(18, 00, 00);
            aktivitet.LimitOfMemebers = 2;
            aktivitet.AgeRestrictions = 15;
            aktivitet.SpecialCharacter = SpecialCharacter.Balmaerke;
            aktivitet.Address = "SpejderVej 13";
            aktivitet.CityName = "Roskilde";
            aktivitet.PostCode = 4000;

            Activities aktivitet1 = new();
            aktivitet1.NameOfActivites = " SkoveTur ";
            aktivitet1.DetailsAboutActivites = " Vi skal på skove tur og plukke blåbære";
            aktivitet1.StartDate = new DateOnly(2026, 11, 25);
            aktivitet1.StartTime = new TimeOnly(09, 00, 00);
            aktivitet1.EndTime = new TimeOnly(18, 00, 00);
            aktivitet1.LimitOfMemebers = 25;
            aktivitet1.AgeRestrictions = 5;
            aktivitet1.SpecialCharacter = SpecialCharacter.IngenTegn;
            aktivitet1.Address = "SpejderVej 13";
            aktivitet1.CityName = "Roskilde";
            aktivitet1.PostCode = 4000;

            AdminLoginRepo activitiesCreater = new();
            //activitiesCreater.CreateActivities(aktivitet);
            activitiesCreater.CreateActivities(aktivitet1);


            Person testPerson = new();

            testPerson.IsSupervisor = true;
            testPerson.FirstName = "Saif";
            testPerson.LastName = "Atyaif";
            testPerson.Email = "Saifatyaif@gmail.com";
            testPerson.PhoneNumber = "52177690";
            testPerson.Age = 35;
            testPerson.Adress = "Majengen 12";
            testPerson.CityName = "Solrød Strand";
            testPerson.PostCode = 2680;
            testPerson.SpeacialCharacters = SpecialCharacter.Balmaerke;
            testPerson.UserName = "SaifMadie";
            testPerson.UserPassword = "123456789!";
            testPerson.UserPasswordConfirm = "123456789!";

            CreateAccount creater = new();

            //creater.Create(testPerson);

        }
    }
}