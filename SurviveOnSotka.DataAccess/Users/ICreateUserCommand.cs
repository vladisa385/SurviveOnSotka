using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface ICreateUserCommand
    {
        Task<UserResponse> ExecuteAsync(CreateUserRequest request);
    }
}
