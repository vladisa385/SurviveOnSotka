using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.ViewModel.Implementanion.Users
{
    public class CreateUserRequest : Request
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

    }
}