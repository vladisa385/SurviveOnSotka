using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.ViewModel.Implementanion.TypeFoods
{
    public class UpdateTypeFoodRequest:UpdateRequest
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
    }
}
