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

        public ActivitesRegister()
        {
        }
    }
}