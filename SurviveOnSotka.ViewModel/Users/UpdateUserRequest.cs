using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Users
{
    public class UpdateUserRequest
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
        public IFormFile Avatar { get; set; }
    }
}
