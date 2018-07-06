using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SurviveOnSotka.Model.Entities
{
    public class User : IdentityUser

    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public FileModel Avatar { get; set; }
        [Required]
        public Level Level { get; set; }
        [Required]
        public int CurrentScore { get; set; }
        [Required]
        public bool Gender { get; set; }
        public string AboutYourself { get; set; }
    }
}
