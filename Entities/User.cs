using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SurviveOnSotka.Entities
{
    public class User : IdentityUser

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PathToAvatar { get; set; }
        public Guid? LevelId { get; set; }
        public Level Level { get; set; }
        [Required]
        public int CurrentScore { get; set; }
        public bool Gender { get; set; }
        public string AboutYourself { get; set; }

        public ICollection<Recipe> Recipies { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CheapPlace> CheapPlaces { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }
    }
}
