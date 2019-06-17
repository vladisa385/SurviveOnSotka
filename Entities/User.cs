using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class User : IdentityUser<Guid>

    {
        [MinLength(5), MaxLength(40)]
        public string FirstName { get; set; }

        [MinLength(5), MaxLength(40)]
        public string LastName { get; set; }

        public byte[] Avatar { get; set; }
        public bool Gender { get; set; }
        public string AboutYourself { get; set; }

        public ICollection<Recipe> Recipies { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }
    }
}