using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModell.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.Reviews
{
    public class UpdateReviewRequest : Request
    {
        [Required]
        public Guid Id { get; set; }

        [MinLength(100), MaxLength(2000)]
        public string Text { get; set; }

        [Range(1, 5)]
        public int Rate { get; set; }

        public string Photo { get; set; }
    }
}