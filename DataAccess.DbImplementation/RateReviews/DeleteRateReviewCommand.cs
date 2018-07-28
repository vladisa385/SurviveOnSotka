using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReview
{
    public class DeleteRateReviewCommand : IDeleteRateReviewCommand
    {
        public Task ExecuteAsync(Guid rateReviewId)
        {
            throw new NotImplementedException();
        }
    }
}
