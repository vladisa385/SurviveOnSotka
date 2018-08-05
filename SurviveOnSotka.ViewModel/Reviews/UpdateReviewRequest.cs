using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Reviews
{
    public class UpdateReviewRequest
    {

        [MinLength(100), MaxLength(2000)]
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        [Range(1, 5)]
        public int Rate { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
    }
}
