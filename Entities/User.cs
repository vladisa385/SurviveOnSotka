using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SurviveOnSotka.Entities
{
    public class User : IdentityUser<Guid>

    {
        [MinLength(5), MaxLength(40)]
        public string FirstName { get; set; }
        [MinLength(5), MaxLength(40)]
        public string LastName { get; set; }
        public string PathToAvatar { get; set; }
        public bool Gender { get; set; }
        [MinLength(100), MaxLength(1000)]
        public string AboutYourself { get; set; }

        public ICollection<Recipe> Recipies { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }
    }
}
