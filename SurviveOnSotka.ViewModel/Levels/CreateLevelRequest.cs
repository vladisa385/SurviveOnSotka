using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Levels
{
    public class CreateLevelRequest
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int MinScore { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int MaxScore { get; set; }
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        public Guid? NextLevelId { get; set; }
        public Guid? LastLevelId { get; set; }
        public IFormFile Icon { get; set; }
    }
}
