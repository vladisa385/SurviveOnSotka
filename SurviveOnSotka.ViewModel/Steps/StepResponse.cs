using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Steps
{
    public class StepResponse
    {
        [Required] public Guid Id { get; set; }
        [Range(0, int.MaxValue)] public int NumberStep { get; set; }

        [Required, MinLength(100), MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public Guid RecipeId { get; set; }
    }
}
