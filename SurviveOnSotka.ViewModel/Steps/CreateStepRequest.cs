using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.Steps
{
    public class CreateStepRequest
    {
        [Range(0, int.MaxValue)]
        public int NumberStep { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }
    }
}