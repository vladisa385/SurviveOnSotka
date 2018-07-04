using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class RateReview
    {

        public int IdReview { get; set; }
        public int IdUserWhoGiveMark { get; set; }
        [Required]
        public bool IsCool { get; set; }
    }
}
