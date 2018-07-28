using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.DataAccess.Levels
{
    public class CannotCreateOrUpdateLevelWithThisGuidLastLevelException:Exception

    {
        public CannotCreateOrUpdateLevelWithThisGuidLastLevelException()
        : base("Level cannot be updated or created, The nextLevel's guid is incorrect")
    {
    }
    }
}
