using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.ViewModel.CheapPlaces
{
    public class CheapPlaceResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(200), MaxLength(500)]
        public string Descriptrion { get; set; }
        [Required]
        public Guid CityId { get; set; }
        [Required]
        public UserResponse Author { get; set; }
        [Required, MinLength(5), MaxLength(100)]
        public string Address { get; set; }
        public string PathToPhotos { get; set; }
        public int? Likes { get; set; }
        public ICollection<string> Tags { get; set; }
        public int? DisLikes { get; set; }

    }
}
