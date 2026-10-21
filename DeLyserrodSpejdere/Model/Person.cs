using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace DeLyserrodSpejdere.Model
{
    public class Person
    {
        public int _isSupervisor;
        public int PersonId { get; set; }

        public string _firstName;
        public string _lastName;
        public string _email;
        public string _phoneNumber;
        public int _age;
        public string _adress;
        public string _cityName;
        public int _postCode;
        public int CityId { get; set; }
        public SpecialCharacter SpeacialCharacters { get; set; }

        public string _userName;
        public string _userPassword;
        public string _userPassworConfrim;

        public int IsSupervisor
        {
            get { return _isSupervisor; }
            set
            {
                if (value == 2007)
                {
                    _isSupervisor = 1;
                }
                else
                {
                    _isSupervisor = 0;
                }
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 2)
                {
                    throw new ArgumentException("Navn skal være min. 2 bogstaver ");
                }
                foreach (char name in value)
                {
                    if (char.IsLetter(name) == false)
                    {
                        throw new ArgumentException("Navn må kun indeholde bogstaver");
                    }
                }

                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 2)
                {
                    throw new ArgumentException("Navn skal være min. 2 bogstaver ");
                }
                foreach (char name in value)
                {
                    if (char.IsLetter(name) == false)
                    {
                        throw new ArgumentException("Navn må kun indeholde bogstaver");
                    }
                }

                _lastName = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains('@') || !value.Contains('.'))
                {
                    throw new ArgumentException("Email skal indeholde snabel a (@) og punktum (.) ! ");
                }
                _email = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 7)
                {
                    throw new ArgumentException("Mobil nummer skal indeholde 8 tal. Prøv igen !");
                }
                foreach (char phone in value)
                {
                    if (char.IsNumber(phone) == false)
                    {
                        throw new ArgumentException("Mobil nummber må kun indeholde tal. Prøv igen!.");
                    }
                }
                _phoneNumber = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (int.IsNegative(value) || value > 105)
                {
                    throw new ArgumentException("Alder må ikke være negativ eller større end 105 . ");
                }

                _age = value;
            }
        }

        public string Adress
        {
            get { return _adress; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 2)
                {
                    throw new ArgumentException("Adresse skal indeholde min. 2 bogstaver");
                }

                _adress = value;
            }
        }

        public string CityName
        {
            get { return _cityName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 2)
                {
                    throw new ArgumentException("Bynavn skal indeholde min. 2 bogstaver");
                }

                _cityName = value;
            }
        }

        public int PostCode
        {
            get { return _postCode; }
            set
            {
                if (int.IsNegative(value))
                {
                    throw new ArgumentException("Post nummer skal min indeholde 4 tal. ");
                }

                _postCode = value;
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 4)
                {
                    throw new ArgumentException("Bruger navn skal indeholde min . 4 bogstaver. Prøv igen! ");
                }
                _userName = value;
            }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 8)
                {
                    throw new ArgumentException("Koden skal min. være 8 lang.  ");
                }
                bool hasSymbol = false;

                foreach (char pass in value)
                {
                    if (char.IsSymbol(pass) || char.IsPunctuation(pass))
                    {
                        hasSymbol = true;
                    }
                }
                if (hasSymbol == false)
                {
                    throw new ArgumentException("Koden skal indeholder symboler (!£$€@ osv. )");
                }
                _userPassword = value;
            }
        }

        public string UserPasswordConfirm
        {
            get { return _userPassworConfrim; }
            set
            {
                bool idenitiy = false;

                if (UserPassword == value)
                {
                    idenitiy = true;
                }
                if (idenitiy == false)
                {
                    throw new ArgumentException("Koden stemmer ikke overens med det indtastet, prøv igen ! ");
                }

                _userPassworConfrim = value;
            }
        }

        public Person()
        {
        }

        public override string ToString()
        {
            return

                $"Er admin : {IsSupervisor}\n" +
                $"Person Id : {PersonId}\n" +
                $"Fornavn : {FirstName}\n" +
                $"Efternavn : {LastName}\n" +
                $"Email : {Email}\n" +
                $"PhoneNumber : {PhoneNumber}\n" +
                $"Alder : {Age}\n" +
                $"Adresse : {Adress}\n" +
                $"City Id : {CityId}\n" +
                $"Special spejdertegn : {SpeacialCharacters}\n" +
                $"Brugernavn : {UserName}\n" +
                $"Kodeordet : {UserPassword}\n" +
                $"Kodeordet bekræftelse : {UserPasswordConfirm}\n";
        }
    }
}