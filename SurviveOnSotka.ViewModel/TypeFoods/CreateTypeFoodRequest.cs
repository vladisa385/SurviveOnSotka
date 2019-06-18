using SurviveOnSotka.ViewModell.Requests;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.TypeFoods
{
    public class CreateTypeFoodRequest : Request
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }

        public string Icon { get; set; }
    }
}