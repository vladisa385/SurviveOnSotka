using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.ViewModel.Implementanion.TypeFoods
{
    public class CreateTypeFoodRequest:Request
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
    }
}
