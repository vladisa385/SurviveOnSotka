using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Category : DomainObject
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }

        [MinLength(10), MaxLength(64)]
        public string Descriptrion { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public string Icon { get; set; }
        public ICollection<Recipe> Recipies { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}