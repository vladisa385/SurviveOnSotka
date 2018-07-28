using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class CreateReviewCommand : ICreateReviewCommand
    {
        public Task<ReviewResponse> ExecuteAsync(CreateReviewRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
