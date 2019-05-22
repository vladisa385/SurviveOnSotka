using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IChangeUserPasswordCommand
    {
        Task<UserResponse> ExecuteAsync(ChangePasswordUserRequest request);
    }
}
