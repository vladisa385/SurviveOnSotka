using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class RateReview
    {

        public Guid ReviewId { get; set; }
        public Guid UserWhoGiveMarkId { get; set; }
        public Review Review { get; set; }
        public User UserWhoGiveMark { get; set; }
        [Required]
        public bool IsCool { get; set; }
    }
}
