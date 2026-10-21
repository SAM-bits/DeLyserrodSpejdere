using System;
using System.Collections.Generic;
using System.Text;

namespace DeLyserrodSpejdere.Model
{
    public class ActivitesRegister
    {
        public int ActivitesRegisterId { get; set; }
        public int ActivitieId { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameOfActivites { get; set; }

        public DateOnly StartDate { get; set; }

        public ActivitesRegister()
        {
        }

        public override string ToString()
        {
            return
                $"Aktivitetes registerings id :{ActivitesRegisterId}\n" +
                $"Aktivitets id:{ActivitieId}\n" +
                $"Person id:{PersonId}\n" +
                $"ForNavn :{FirstName}\n" +
                $"Efternavn:{LastName}\n" +
                $"Aktivitets navn :{NameOfActivites}\n" +
                $"Start dato :{StartDate}\n";
        }
    }
}