using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.RateCheapPlaces
{
    public class RateCheapPlaceResponse
    {
        public Guid CheapPlaceId { get; set; }
        public Guid UserWhoGiveMarkId { get; set; }
        [Required]
        public bool IsCool { get; set; }
    }
}
