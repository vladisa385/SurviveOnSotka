using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface ILoginUserCommand
    {
        Task<UserResponse> ExecuteAsync(LoginUserRequest request);
    }
}
