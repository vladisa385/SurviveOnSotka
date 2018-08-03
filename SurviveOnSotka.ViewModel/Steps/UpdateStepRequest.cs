using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Steps
{
    public class UpdateStepRequest
    {
        [Range(0, int.MaxValue)] public int NumberStep { get; set; }

        [Required, MinLength(100), MaxLength(400)]
        public string Description { get; set; }

        [Required] public Guid RecipeId { get; set; }
    }
}