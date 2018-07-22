using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly UserManager<User> _userManager;

        public DeleteUserCommand(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task ExecuteAsync(string userId)
        {

            User userToDelete = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == userId);
            //if (userToDelete?.Ingredients?.Count > 0)
            //{
            //    throw new CannotDeleteUserWithIngredientsExeption();
            //}

            if (userToDelete != null)
            {
                if (userToDelete.PathToAvatar != null)
                    DeleteFileCommand.Execute(userToDelete.PathToAvatar);
                await _userManager.DeleteAsync(userToDelete);
            }
        }
    }
}
