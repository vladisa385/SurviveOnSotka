using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class RateReview
    {
        [Key]
        public Review Review { get; set; }
        [Key]
        public User UserWhoGiveMark { get; set; }
        [Required]
        public bool IsCool { get; set; }
    }
}
