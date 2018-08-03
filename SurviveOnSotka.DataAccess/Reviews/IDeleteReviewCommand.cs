using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface IDeleteReviewCommand
    {
        Task ExecuteAsync(Guid reviewId);
    }
}
