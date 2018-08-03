using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.Tags
{
    public class TagResponse
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<TagsInRecipe> Recipies { get; set; }
    }
}