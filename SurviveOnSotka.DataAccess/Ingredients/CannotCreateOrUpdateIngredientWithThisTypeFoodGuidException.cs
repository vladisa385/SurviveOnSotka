using System;

namespace SurviveOnSotka.DataAccess.Ingredients
{
    public class CannotCreateOrUpdateIngredientWithThisTypeFoodGuidException : Exception

    {
        public CannotCreateOrUpdateIngredientWithThisTypeFoodGuidException()
            : base("Ingredient cannot be updated or created, The typefood's guid is incorrect")
        {
        }
    }
}
