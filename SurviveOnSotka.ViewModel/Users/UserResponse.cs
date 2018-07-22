﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.Users
{
    public class UserResponse
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PathToAvatar { get; set; }
        public Guid? IdLevel { get; set; }
        [Required]
        public int CurrentScore { get; set; }
        [Required]
        public bool Gender { get; set; }
        public string AboutYourself { get; set; }
        public int RecipiesCount { get; set; }
        public int ReviewsCount { get; set; }
        public int CheapPlacesCount { get; set; }
        public int RateReviewsCount { get; set; }
    }
}
