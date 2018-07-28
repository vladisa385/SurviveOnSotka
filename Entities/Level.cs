﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurviveOnSotka.Entities
{
    public class Level : DomainObject
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
        [Required]
        public int MinScore { get; set; }
        [Required]
        public int MaxScore { get; set; }
        public string Name { get; set; }
        public Guid? NextLevelId { get; set; }
        public Guid? LastLevelId { get; set; }
        public Level NextLevel { get; set; }
        public Level LastLevel { get; set; }
        public string PathToIcon { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
