using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Quantity : DomainObject
    {
        [Required, MaxLength(7)]
        public string Name { get; set; }
        [Required]
        public int StandartMeasure { get; set; }
    }
}
