using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUsersListQuery
    {
        Task<ListResponse<UserResponse>> RunAsync(UserFilter filter, ListOptions options);
    }
}
