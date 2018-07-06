using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class RateReview
    {

        public Guid IdReview { get; set; }
        public Guid IdUserWhoGiveMark { get; set; }
        [Required]
        public Review Review { get; set; }
        [Required]
        public User UserWhoGiveMark { get; set; }
        [Required]
        public bool IsCool { get; set; }
    }
}
