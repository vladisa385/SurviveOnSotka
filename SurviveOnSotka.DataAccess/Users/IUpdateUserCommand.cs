using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUpdateUserCommand
    {

        Task<UserResponse> ExecuteAsync(UpdateUserRequest request);

    }
}
