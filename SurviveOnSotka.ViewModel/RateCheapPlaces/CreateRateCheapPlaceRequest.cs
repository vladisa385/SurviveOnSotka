using System;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.RateCheapPlaces
{
    public class CreateRateCheapPlaceRequest
    {
        [Required]
        public bool IsCool { get; set; }

    }
}
