using System;

namespace SurviveOnSotka.DataAccess.Ingredients
{
    public class CannotDeleteIngredientWithRecipiesExeption : Exception

    {
        public CannotDeleteIngredientWithRecipiesExeption()
               : base("Ingredient cannot be deleted, if there are recipe in it.") { }
    }
}
