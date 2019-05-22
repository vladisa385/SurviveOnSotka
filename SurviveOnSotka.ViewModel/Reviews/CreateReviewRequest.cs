using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.ViewModel.Implementanion.Reviews
{
    public class CreateReviewRequest:Request
    {
 
        [Required]
        public Guid RecipeId { get; set; }
        [Required, MinLength(100), MaxLength(2000)]
        public string Text { get; set; }
        [Required, Range(1, 5)]
        public int Rate { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
    }
}
