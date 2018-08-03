using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.RateCheapPlaces
{
    public class UpdateRateCheapPlaceRequest
    {
        [Required]
        public bool IsCool { get; set; }
    }
}
