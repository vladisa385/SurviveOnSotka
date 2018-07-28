using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class UpdateReviewCommand : IUpdateReviewCommand
    {
        public Task<ReviewResponse> ExecuteAsync(Guid reviewId, UpdateReviewRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
