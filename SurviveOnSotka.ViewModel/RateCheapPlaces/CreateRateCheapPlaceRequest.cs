using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.RateCheapPlaces
{
    public class CreateRateCheapPlaceRequest
    {
        [Required]
        public bool IsCool { get; set; }

    }
}
