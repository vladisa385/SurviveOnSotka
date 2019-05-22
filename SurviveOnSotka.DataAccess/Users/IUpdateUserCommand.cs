using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUpdateUserCommand
    {

        Task<UserResponse> ExecuteAsync(UpdateUserRequest request);

    }
}
