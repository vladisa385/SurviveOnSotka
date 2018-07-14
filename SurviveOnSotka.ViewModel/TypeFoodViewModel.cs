
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel
{
    public class TypeFoodViewModel
    {
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        [Required]
        public IFormFile Avatar { get; set; }
    }
}
