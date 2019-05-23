using System;

namespace SurviveOnSotka.Entities
{
    public class TagsInRecipe
    {
        public Recipe Recipe { get; set; }
        public Guid RecipeId { get; set; }
        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}