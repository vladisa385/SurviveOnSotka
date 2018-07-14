using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Tags
{
    public interface IDeleteTagCommand
    {
        Task ExecuteAsync(string tag);
    }
}
