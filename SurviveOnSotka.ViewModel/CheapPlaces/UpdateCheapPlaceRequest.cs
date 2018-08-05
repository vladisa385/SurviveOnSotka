using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.CheapPlaces
{
    public class UpdateCheapPlaceRequest
    {

        [MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(200), MaxLength(2000)]
        public string Description { get; set; }
        public Guid? CityId { get; set; }
        [MinLength(5), MaxLength(100)]
        public string Address { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
    }
}
