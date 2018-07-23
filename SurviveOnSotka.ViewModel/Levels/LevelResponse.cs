using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurviveOnSotka.ViewModel.Levels
{
    public class LevelResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int MinScore { get; set; }
        [Required]
        public int MaxScore { get; set; }
        public string Name { get; set; }
        public Guid? NextLevelId { get; set; }
        public Guid? LastLevelId { get; set; }
        public string PathToIcon { get; set; }
        [Required]
        public int UsersCount { get; set; }
    }
}
