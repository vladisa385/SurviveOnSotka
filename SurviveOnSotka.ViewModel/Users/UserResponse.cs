using System;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.ViewModel.Implementanion.Users
{
    public class UserResponse : Response
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [MinLength(5), MaxLength(40)]
        public string FirstName { get; set; }

        [MinLength(5), MaxLength(40)]
        public string LastName { get; set; }

        public string Avatar { get; set; }

        [Required]
        public bool Gender { get; set; }

        [MinLength(100), MaxLength(1000)]
        public string AboutYourself { get; set; }

        [Required]
        public int RecipiesCount { get; set; }

        [Required]
        public int ReviewsCount { get; set; }

        [Required]
        public int RateReviewsCount { get; set; }
    }
}