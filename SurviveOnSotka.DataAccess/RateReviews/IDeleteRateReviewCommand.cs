using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public interface IDeleteRateReviewCommand
    {
        Task ExecuteAsync(Guid reviewId);
    }
}
