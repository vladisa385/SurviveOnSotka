using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface IReviewsListQuery
    {
        Task<ListResponse<ReviewResponse>> RunAsync(ReviewFilter filter, ListOptions options);
    }
}
