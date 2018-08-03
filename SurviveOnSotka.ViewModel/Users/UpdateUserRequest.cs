﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Users
{
    public class UpdateUserRequest
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
        [MinLength(100), MaxLength(1000)]
        public string AboutYourself { get; set; }
        [Display(Name = "Аватар")]
        public IFormFile Avatar { get; set; }
    }
}
