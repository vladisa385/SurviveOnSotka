using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface ILogOffUserCommand
    {
        Task ExecuteAsync();
    }
}
