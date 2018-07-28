using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public class CannotCreateOrUpdareReviewWithThisGuidRecipe:Exception
    {
        public CannotCreateOrUpdareReviewWithThisGuidRecipe()
        : base("Review cannot be updated or created, The recipe's guid is incorrect")
        {
        }
    }
}
