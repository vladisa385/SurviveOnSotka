using SurviveOnSotka.ViewModell.Requests;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.Reviews
{
    public class CreateReviewRequest : Request
    {
        [Required]
        public Guid RecipeId { get; set; }

        [Required, MinLength(100), MaxLength(2000)]
        public string Text { get; set; }

        [Required, Range(1, 5)]
        public int Rate { get; set; }

        public string Photo { get; set; }
    }
}