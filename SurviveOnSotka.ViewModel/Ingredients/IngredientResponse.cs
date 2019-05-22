using System;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.ViewModel.Implementanion.Ingredients
{
    public class IngredientResponse:Response

    {
    [Required] public Guid Id { get; set; }
    [Required] public Guid TypeFoodId { get; set; }

    [Required, MinLength(5), MaxLength(100)]
    public string Name { get; set; }

    public string PathToIcon { get; set; }
    [Required] public int RecipiesCount { get; set; }
    }
}
