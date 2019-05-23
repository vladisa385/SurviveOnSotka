using SurviveOnSotka.ViewModel.Implementanion.Users;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface ILoginUserCommand
    {
        Task<UserResponse> ExecuteAsync(LoginUserRequest request);
    }
}