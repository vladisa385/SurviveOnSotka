﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUpdateUserCommand
    {

        Task<UserResponse> ExecuteAsync(UpdateUserRequest request);

    }
}
