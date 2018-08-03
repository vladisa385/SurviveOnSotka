using System;

namespace SurviveOnSotka.DataAccess.Levels
{
    public class CannotCreateOrUpdateLevelWithThisGuidNextLevelException : Exception
    {
        public CannotCreateOrUpdateLevelWithThisGuidNextLevelException()
        : base("Level cannot be updated or created, The lastLevel's guid is incorrect")
        {
        }
    }
}
