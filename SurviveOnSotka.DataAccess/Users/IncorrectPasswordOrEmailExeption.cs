using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.DataAccess.Users
{
    public class IncorrectPasswordOrEmailExeption : Exception

    {
        public IncorrectPasswordOrEmailExeption() : base("Password or email are incorrect ")
        {

        }
    }
}
