using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Cities
{
    public class CityResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int CheapPlacesCount { get; set; }
    }
}
