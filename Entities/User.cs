using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SurviveOnSotka.Entities
{
    public class User : IdentityUser

    {
        [MinLength(5), MaxLength(40)]
        public string FirstName { get; set; }
        [MinLength(5), MaxLength(40)]
        public string LastName { get; set; }
        public string PathToAvatar { get; set; }
        public Guid? LevelId { get; set; }
        public Level Level { get; set; }

        public int CurrentScore
        {
            get
            {
                var sum = 0;
                if (Recipies != null)
                    sum += Recipies.Count * Level.PointsForRecipe;
                if (Reviews != null)
                    sum += Reviews.Count * Level.PointsForReview;
                if (CheapPlaces != null)
                    sum += CheapPlaces.Count * Level.PointsForCheapPlace;
                if (RateCheapPlaces != null)
                    sum += RateCheapPlaces.Count * Level.PointsForRateCheapPlace;
                if (RateReviews != null)
                    sum += RateReviews.Count * Level.PointsForRateReview;
                return sum;
            }
        }

        public bool Gender { get; set; }
        [MinLength(100), MaxLength(1000)]
        public string AboutYourself { get; set; }

        public ICollection<Recipe> Recipies { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CheapPlace> CheapPlaces { get; set; }
        public ICollection<RateCheapPlace> RateCheapPlaces { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }
    }
}
