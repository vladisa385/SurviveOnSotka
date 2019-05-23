using SurviveOnSotka.ViewModel.Implementanion.Users;
using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IUserQuery
    {
        Task<UserResponse> RunAsync(Guid userId);
    }
}