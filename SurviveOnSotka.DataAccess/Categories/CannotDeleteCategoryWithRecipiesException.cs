using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.DataAccess.Categories
{
    public class CannotDeleteCategoryWithRecipiesException : Exception
    {
        public CannotDeleteCategoryWithRecipiesException()
            : base("Category cannot be deleted, if there are recipies in it.") { }
    }
}
