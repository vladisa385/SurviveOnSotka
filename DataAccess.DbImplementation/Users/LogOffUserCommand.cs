using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.Entities;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class LogOffUserCommand : Command<EmptyRequest, EmptyResponse<UserResponse>>
    {
        private readonly SignInManager<User> _signInManager;

        public LogOffUserCommand(SignInManager<User> signInManager) => _signInManager = signInManager;

        protected override async Task<EmptyResponse<UserResponse>> Execute(EmptyRequest request)
        {
            await _signInManager.SignOutAsync();
            return new EmptyResponse<UserResponse>();
        }
    }
}