using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurviveOnSotka.Entities
{
    public class TagsInRecipe
    {
        public Recipe Task { get; set; }
        public int TaskId { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
