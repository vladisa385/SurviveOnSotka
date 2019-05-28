using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Entities;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class DeleteUserCommand : Command<SimpleDeleteRequest, EmptyResponse<UserResponse>>
    {
        private readonly UserManager<User> _userManager;

        public DeleteUserCommand(UserManager<User> userManager) => _userManager = userManager;


        protected override async Task<EmptyResponse<UserResponse>> Execute(SimpleDeleteRequest request)
        {
            var userToDelete = await _userManager.Users
                .FirstOrDefaultAsync(p => p.Id == request.Id);
            if (userToDelete != null)
                await _userManager.DeleteAsync(userToDelete);
            return new EmptyResponse<UserResponse>();
        }
    }
}