﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Recipe : DomainObject
    {
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }

        [Required, MinLength(100), MaxLength(1000)]
        public string Description { get; set; }

        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string Photo { get; set; }
        public ICollection<TagsInRecipe> Tags { get; set; }
        public TimeSpan? TimeForCooking { get; set; }
        public TimeSpan? TimeForPreparetion { get; set; }

        [Required]
        public ICollection<IngredientToRecipe> Ingredients { get; set; }

        [Required]
        public ICollection<Step> Steps { get; set; }
    }
}