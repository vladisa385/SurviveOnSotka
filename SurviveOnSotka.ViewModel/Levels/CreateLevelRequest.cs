using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Levels
{
    public class CreateLevelRequest
    {
        [Required]
        public int MinScore { get; set; }
        [Required]
        public int MaxScore { get; set; }
        public string Name { get; set; }
        public Guid? NextLevelId { get; set; }
        public Guid? LastLevelId { get; set; }
        public IFormFile Icon { get; set; }
    }
}
