using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUserQuery
    {
        Task<UserResponse> RunAsync(Guid userId);
    }
}
