using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUpdateUserLevelCommand
    {
        Task<UserResponse> ExecuteAsync(string userId);
    }
}
