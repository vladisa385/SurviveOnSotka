using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.Steps
{
    public class UpdateStepRequest
    {
        [Range(0, int.MaxValue)] public int NumberStep { get; set; }

        [Required, MinLength(100), MaxLength(1000)]
        public string Description { get; set; }

    }
}