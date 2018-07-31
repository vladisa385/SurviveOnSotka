﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface IReviewQuery
    {
        Task<ReviewResponse> RunAsync(Guid reviewId);
    }
}