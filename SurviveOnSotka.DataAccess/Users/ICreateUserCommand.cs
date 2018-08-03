using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface ICreateUserCommand
    {
        Task<UserResponse> ExecuteAsync(CreateUserRequest request);
    }
}
