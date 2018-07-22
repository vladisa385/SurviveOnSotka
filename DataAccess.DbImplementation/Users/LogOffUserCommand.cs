using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class LogOffUserCommand : ILogOffUserCommand
    {
        private readonly SignInManager<User> _signInManager;

        public LogOffUserCommand(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task ExecuteAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
