using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.ViewModel.Implementanion.Users
{
    public class UpdateUserRequest : Request
    {
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Пол")]
        public bool Gender { get; set; }

        [Display(Name = "Описание")]
        public string AboutYourself { get; set; }

        [Display(Name = "Аватар")]
        public string Avatar { get; set; }
    }
}