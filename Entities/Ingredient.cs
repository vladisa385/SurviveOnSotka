﻿using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Ingredient : DomainObject
    {
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        public TypeFood TypeFood { get; set; }
        public string PathToIcon { get; set; }
    }
}