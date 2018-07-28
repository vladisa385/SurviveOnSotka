﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Review;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface IUpdateReviewCommand
    {
        Task<ReviewResponse> ExecuteAsync(Guid reviewId, UpdateReviewRequest request);
    }
}
