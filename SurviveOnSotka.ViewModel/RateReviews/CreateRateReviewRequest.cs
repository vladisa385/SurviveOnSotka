﻿using SurviveOnSotka.ViewModell.Requests;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.RateReviews
{
    public class CreateRateReviewRequest : Request
    {
        [Required]
        public Guid ReviewId { get; set; }

        [Required]
        public bool IsCool { get; set; }
    }
}