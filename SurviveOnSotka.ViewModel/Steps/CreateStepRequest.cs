using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Steps
{
    public class CreateStepRequest
    {
        [Range(0, int.MaxValue)]
        public int NumberStep { get; set; }
        [Required, MinLength(100), MaxLength(400)]
        public string Description { get; set; }
    }
}
