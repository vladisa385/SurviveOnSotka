using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurviveOnSotka.ViewModel
{
    public class RegistrationViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string AboutYourself { get; set; }
    }
}
