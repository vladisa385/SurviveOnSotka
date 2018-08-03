using System;

namespace SurviveOnSotka.DataAccess.CheapPlaces
{
    public class CannotCreateOrUpdateCheapPlaceWithCurrentGuidCity : Exception
    {
        public CannotCreateOrUpdateCheapPlaceWithCurrentGuidCity()
            : base("CheapPlace cannot be updated or created, The city's guid is incorrect") { }
    }
}
