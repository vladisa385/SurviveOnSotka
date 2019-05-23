using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface IDeleteUserCommand
    {
        Task ExecuteAsync(Guid userId);
    }
}