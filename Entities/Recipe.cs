using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SurviveOnSotka.Entities
{
    public class Recipe : DomainObject
    {
        [Required, MinLength(5)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public ICollection<RecipeInCategories> Categories { get; set; }
        [Required]
        public ICollection<Review> Reviews { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string PathToPhotos { get; set; }
        public ICollection<TagsInRecipe> Tags { get; set; }
        public TimeSpan TimeForCooking { get; set; }
        public TimeSpan TimeForPreparetion { get; set; }
        public double Rate
        {
            get
            {
                if (Reviews == null) return 0;
                return Reviews.Average(u => u.Rate);

            }
        }
        public ICollection<IngredientToRecipe> Ingredients { get; set; }
        [Required]
        public ICollection<Step> Steps { get; set; }
    }
}
