using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class Level : DomainObject
    {
        [Required]
        public int MinScore { get; set; }
        [Required]
        public int MaxScore { get; set; }
        public Level NextLevel { get; set; }
        public Level LastLevel { get; set; }
    }
}
