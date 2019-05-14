using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SurviveOnSotka.DataAccess.Users
{
    public class ThisRequestNotFromOwnerException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public ThisRequestNotFromOwnerException(IEnumerable<IdentityError> errors) : base("It is not owner")
        {
            Errors = errors;
        }
    }
}
