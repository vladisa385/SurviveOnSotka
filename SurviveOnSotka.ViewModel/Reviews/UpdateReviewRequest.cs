using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Implementanion.Reviews
{
    public class UpdateReviewRequest
    {
        [Required]
        public Guid Id { get; set; }
        [MinLength(100), MaxLength(2000)]
        public string Text { get; set; }
        [Range(1, 5)]
        public int Rate { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
    }
}
