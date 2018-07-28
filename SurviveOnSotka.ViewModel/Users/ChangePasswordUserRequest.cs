using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurviveOnSotka.ViewModel.Users
{
    public class ChangePasswordUserRequest
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string NewPassword { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string NewPasswordConfirm { get; set; }

        [Display(Name = "Старый пароль")]
        public string OldPassword { get; set; }
    }
}
