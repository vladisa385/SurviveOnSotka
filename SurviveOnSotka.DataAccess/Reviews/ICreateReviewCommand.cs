﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Review;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface ICreateReviewCommand
    {
        Task<ReviewResponse> ExecuteAsync(CreateReviewRequest request);
    }
}
