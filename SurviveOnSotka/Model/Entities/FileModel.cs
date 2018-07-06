using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class FileModel : DomainObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
