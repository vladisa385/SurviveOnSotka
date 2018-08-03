using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Cities
{
    public class CreateCityRequest
    {
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }

    }
}
