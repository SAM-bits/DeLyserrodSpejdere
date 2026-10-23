using DeLyserrodSpejdere.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeLyserrodSpejdere.Service
{
    public class LoginService
    {
        private readonly ILoginRepo _login;

        public LoginService(ILoginRepo login)
        {
        }
    }
}