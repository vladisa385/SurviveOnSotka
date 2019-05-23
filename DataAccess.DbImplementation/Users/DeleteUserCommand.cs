﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Entities;
using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly UserManager<User> _userManager;

        public DeleteUserCommand(UserManager<User> userManager) => _userManager = userManager;

        public async Task ExecuteAsync(Guid userId)
        {
            User userToDelete = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == userId);

            if (userToDelete != null)
            {
                if (userToDelete.PathToAvatar != null)
                    DeleteFileCommand.Execute(userToDelete.PathToAvatar);
                await _userManager.DeleteAsync(userToDelete);
            }
        }
    }
}