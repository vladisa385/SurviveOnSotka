using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Review
    {
        [Key]
        public Recipe Recipe { get; set; }
        [Key]
        public User Author { get; set; }
        [Required, MinLength(200)]
        public string Text { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required, MinLength(1), MaxLength(5)]
        public int Rate { get; set; }
        public List<FileModel> Photos { get; set; }
    }
}
