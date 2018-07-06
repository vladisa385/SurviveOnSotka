using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class Like
    {

        public Guid IdRecipe { get; set; }
        [Required]
        public Recipe Recipe { get; set; }
        public Guid IdUserWhoGiveLike { get; set; }
        [Required]
        public User UserWhoGiveLike { get; set; }
    }
}
