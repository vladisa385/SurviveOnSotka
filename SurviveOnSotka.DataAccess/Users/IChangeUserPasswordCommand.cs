﻿using SurviveOnSotka.ViewModel.Implementanion.Users;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IChangeUserPasswordCommand
    {
        Task<UserResponse> ExecuteAsync(ChangePasswordUserRequest request);
    }
}