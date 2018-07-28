using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SurviveOnSotka.Entities
{
    public class User : IdentityUser

    {
        [NotMapped]
        public const int PointsForReview = 100;
        [NotMapped]
        public const int PointsForRecipe = 100;
        [NotMapped]
        public const int PointsForRateReview = 50;
        [NotMapped]
        public const int PointsForCheapPlace = 100;
        [NotMapped]
        public const int PointsForRateCheapPlace = 50;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PathToAvatar { get; set; }
        public Guid? LevelId { get; set; }
        public Level Level { get; set; }

        public int CurrentScore => Recipies.Count        *  PointsForRecipe +
                                     Reviews.Count         * PointsForReview +
                                     CheapPlaces.Count     * PointsForCheapPlace +
                                     RateReviews.Count     * PointsForRateReview + 
                                     RateCheapPlaces.Count * PointsForRateCheapPlace;

        public bool Gender { get; set; }
        public string AboutYourself { get; set; }

        public ICollection<Recipe> Recipies { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CheapPlace> CheapPlaces { get; set; }
        public ICollection<RateCheapPlace> RateCheapPlaces { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }
    }
}
