using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SurviveOnSotka.DataAccess.Users
{
    public class CannotCreateUserExeption : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }

        public CannotCreateUserExeption(IEnumerable<IdentityError> errors) : base("User cannot be created") => Errors = errors;
    }
}