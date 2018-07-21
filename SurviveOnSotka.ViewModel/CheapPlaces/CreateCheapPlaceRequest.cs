﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.CheapPlaces
{
    public class CreateCheapPlaceRequest
    {
        [Required, MinLength(5)]
        public string Name { get; set; }
        [Required, MinLength(200)]
        public string Description { get; set; }
        [Required]
        public Guid CityId { get; set; }

        public Guid? UserId { get; set; }
        public ICollection<IFormFile> Photos { get; set; }

    }
}
