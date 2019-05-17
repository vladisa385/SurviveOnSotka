﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SurviveOnSotka.ViewModel.Reviews
{
    public class CreateReviewRequest
    {
        [Required]
        public Guid RecipeId { get; set; }
        [Required, MinLength(100), MaxLength(2000)]
        public string Text { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required, Range(1, 5)]
        public int Rate { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
    }
}
