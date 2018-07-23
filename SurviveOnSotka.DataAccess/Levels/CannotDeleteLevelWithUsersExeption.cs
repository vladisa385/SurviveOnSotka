using System;

namespace SurviveOnSotka.DataAccess.Levels
{
    public class CannotDeleteLevelWithUsersExeption : Exception

    {
        public CannotDeleteLevelWithUsersExeption()
               : base("Level cannot be deleted, if there are user in it.") { }
    }
}
