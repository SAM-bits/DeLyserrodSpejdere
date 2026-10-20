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
            aktivitet.City = "Roskilde 4000";

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

            creater.Create(testPerson);
        }
    }
}