using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.CheapPlaces
{
    public class CheapPlaceResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        [MinLength(16), MaxLength(64)]
        public string Descriptrion { get; set; }
        [Required]
        public Guid CityId { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string Address { get; set; }
        public string PathToPhotos { get; set; }
        public int? Likes { get; set; }

        public int? DisLikes { get; set; }

    }
}
