using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Step : DomainObject
    {
        [Range(0, int.MaxValue)]
        public int NumberStep { get; set; }
        [Required, MinLength(100), MaxLength(400)]
        public string Description { get; set; }
        [Required]
        public Recipe Recipe { get; set; }
        [Required]
        public Guid RecipeId { get; set; }
    }
}
