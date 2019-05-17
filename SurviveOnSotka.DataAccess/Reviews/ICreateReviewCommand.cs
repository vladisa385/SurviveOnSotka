﻿using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface ICreateReviewCommand
    {
        Task<ReviewResponse> ExecuteAsync(CreateReviewRequest request);
    }
}
