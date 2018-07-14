using System;

namespace SurviveOnSotka.Entities
{
    public class RecipeInCategories
    {
        public Recipe Recipe { get; set; }
        public Guid RecipeId { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
