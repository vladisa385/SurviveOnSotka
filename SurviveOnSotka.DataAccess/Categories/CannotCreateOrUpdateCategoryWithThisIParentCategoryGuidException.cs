using System;

namespace SurviveOnSotka.DataAccess.Categories
{
    public class CannotCreateOrUpdateCategoryWithThisIParentCategoryGuidException:Exception
    {
        public CannotCreateOrUpdateCategoryWithThisIParentCategoryGuidException()
               : base("Category cannot be updated or created, The ParentCategory's guid is incorrect") { }
    }
}
