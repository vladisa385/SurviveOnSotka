using System;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.RateCheapPlaces
{
    public class UpdateRateCheapPlaceRequest
    {
        [Required]
        public bool IsCool { get; set; }
    }
}
