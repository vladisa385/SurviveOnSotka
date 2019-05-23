using SurviveOnSotka.ViewModel.Implementanion.Users;
using SurviveOnSotka.ViewModell;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUsersListQuery
    {
        Task<ListResponse<UserResponse>> RunAsync(UserFilter filter, ListOptions options);
    }
}