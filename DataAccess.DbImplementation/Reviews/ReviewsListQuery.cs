using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.ViewModel.Review;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class ReviewsListQuery:IReviewsListQuery
    {
        public Task<ReviewResponse> RunAsync(Guid reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
