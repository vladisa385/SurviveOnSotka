using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.DataAccess.Levels
{
    public class CannotCreateOrUpdateLevelWithThisGuidNextLevelException:Exception
    {
        public CannotCreateOrUpdateLevelWithThisGuidNextLevelException()
        : base("Level cannot be updated or created, The lastLevel's guid is incorrect")
        {
        }
    }
}
