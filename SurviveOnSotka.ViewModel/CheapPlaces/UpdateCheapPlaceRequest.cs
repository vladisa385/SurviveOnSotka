using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.CheapPlaces
{
    public class UpdateCheapPlaceRequest
    {

        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required, MinLength(200), MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public Guid CityId { get; set; }
        [Required, MinLength(5), MaxLength(100)]
        public string Address { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
    }
}
