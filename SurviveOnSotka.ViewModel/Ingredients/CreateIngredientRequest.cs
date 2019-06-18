using SurviveOnSotka.ViewModell.Requests;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.Ingredients
{
    public class CreateIngredientRequest : Request
    {
        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }

        public string Icon { get; set; }

        [Required]
        public Guid TypeFoodId { get; set; }
    }
}