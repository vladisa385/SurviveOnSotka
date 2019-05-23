using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Entities;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class LogOffUserCommand : ILogOffUserCommand
    {
        private readonly SignInManager<User> _signInManager;

        public LogOffUserCommand(SignInManager<User> signInManager) => _signInManager = signInManager;

        public async Task ExecuteAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}