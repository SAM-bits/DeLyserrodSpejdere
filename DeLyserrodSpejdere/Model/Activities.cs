using System;
using System.Collections.Generic;
using System.Text;

namespace DeLyserrodSpejdere.Model
{
    public class Activities
    {
        public int ActivitieId { get; set; }
        public string _nameOfActivites;
        public string _detaialsOfActivites;
        public DateOnly StartDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int LimitOfMemebers { get; set; }
        public int _ageRestictions;
        public SpecialCharacter _specialCharacter;
        public string _city;

        public string NameOfActivites
        {
            get { return _nameOfActivites; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Det skal være et navn for aktiviteten!");
                }
                _nameOfActivites = value;
            }
        }

        public string DetailsAboutActivites
        {
            get { return _detaialsOfActivites; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Det skal være et navn for aktiviteten!");
                }
                _detaialsOfActivites = value;
            }
        }

        public int AgeRestrictions
        {
            get { return _ageRestictions; }
            set
            {
                if (int.IsNegative(value) || value > 105)
                {
                    throw new ArgumentException("Forkert alder begrænsing , det skal være mellem 0 og 105");
                }
                _ageRestictions = value;
            }
        }

        public SpecialCharacter SpecialCharacter
        {
            get { return _specialCharacter; }
            set
            {
                bool specialAcces = false;

                Person person = new();
                if (person.SpeacialCharacters == SpecialCharacter)
                {
                    specialAcces = true;
                }
                if (specialAcces == false)
                {
                    throw new ArgumentException("Du har opfylder ikke specialtegn kravet. prøv en anden aktivitet.");
                }

                _specialCharacter = value;
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Må ikke være tom , og adressen skal være roskilde. prøv igen !");
                }
                _city = value;
            }
        }

        public Activities()
        {
        }

        public override string ToString()
        {
            return
                 $"Aktivits Id : {ActivitieId} \n" +
                 $"Navnet på aktiviteten  : {NameOfActivites} \n" +
                 $"Dato : {StartDate} \n" +
                 $"Start tid : {StartTime} \n" +
                 $"Slut tid  : {EndTime} \n" +
                 $"Begrænset medlemer : {LimitOfMemebers} \n" +
                 $"Begrænset alder : {AgeRestrictions} År \n" +
                 $"Special tegn ? : {SpecialCharacter} \n" +
                 $"Området : {City} \n";
        }
    }
}