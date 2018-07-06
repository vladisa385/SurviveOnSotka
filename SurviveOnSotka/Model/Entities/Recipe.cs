using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class Recipe : DomainObject
    {
        [Required, MinLength(5)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public User Author { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public Step FirstStep { get; set; }
        public List<Tag> Tags { get; set; }
        public List<FileModel> Photos { get; set; }
        public DateTime TimeForCooking { get; set; }
        public DateTime TimeForPreparetion { get; set; }
    }
}
