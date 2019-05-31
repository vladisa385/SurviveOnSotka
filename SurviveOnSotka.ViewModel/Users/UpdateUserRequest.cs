using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.ViewModel.Implementanion.Users
{
    public class UpdateUserRequest : Request
    {
        [Display(Name = "Имя")]
        [MinLength(5), MaxLength(40)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [MinLength(5), MaxLength(40)]
        public string LastName { get; set; }

        [Display(Name = "Пол")]
        public bool Gender { get; set; }

        [Display(Name = "Описание")]
        public string AboutYourself { get; set; }

        [Display(Name = "Аватар")]
        public string Avatar { get; set; }
    }
}