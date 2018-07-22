﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SurviveOnSotka.DataAccess.Users
{
    public class CannotCreateUser : Exception
    {


        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateUser(IEnumerable<IdentityError> errors) : base("User cannot be created")
        {
            Errors = errors;
        }

    }
}
