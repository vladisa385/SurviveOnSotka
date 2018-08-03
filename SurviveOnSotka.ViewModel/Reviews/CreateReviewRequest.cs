using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.Reviews
{
    public class CreateReviewRequest
    {
        [Required, MinLength(100), MaxLength(1000)]
        public string Text { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required, Range(1, 5)]
        public int Rate { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
    }
}
