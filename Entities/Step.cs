using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Step : DomainObject
    {

        public int NumberStep { get; set; }
        public string Description { get; set; }
        public string PathToPhoto { get; set; }
        [Required]
        public Recipe Recipe { get; set; }
        [Required]
        public Guid RecipeId { get; set; }
    }
}
