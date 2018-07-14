using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class FileModel : DomainObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string TypeFile { get; set; }
        [Required]
        public byte[] BinaryFile { get; set; }
    }
}
