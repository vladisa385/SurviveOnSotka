using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUserQuery
    {
        Task<UserResponse> RunAsync(Guid userId);
    }
}
