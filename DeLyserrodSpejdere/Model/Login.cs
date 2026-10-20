using System;
using System.Collections.Generic;
using System.Text;

namespace DeLyserrodSpejdere.Model
{
    public class Login
    {
        public int LoginId { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public Login()
        {
        }
    }
}