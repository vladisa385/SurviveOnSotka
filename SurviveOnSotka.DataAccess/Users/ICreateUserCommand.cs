using SurviveOnSotka.ViewModel.Implementanion.Users;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface ICreateUserCommand
    {
        Task<UserResponse> ExecuteAsync(CreateUserRequest request);
    }
}