using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUsersListQuery
    {
        Task<ListResponse<UserResponse>> RunAsync(UserFilter filter, ListOptions options);
    }
}
