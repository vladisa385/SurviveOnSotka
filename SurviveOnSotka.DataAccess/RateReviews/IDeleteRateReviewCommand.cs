using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public interface IDeleteRateReviewCommand
    {
        Task ExecuteAsync(Guid rateReviewId);
    }
}
