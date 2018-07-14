using System.Collections.Generic;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.Tags
{
    public class TagResponse
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<TagsInRecipe> Recipess { get; set; }
    }
}