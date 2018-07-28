using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.DataAccess.Cities
{
    public class CannotDeleteCityWithCheapPlacesExeption : Exception

    {
        public CannotDeleteCityWithCheapPlacesExeption()
               : base("City cannot be deleted, if there are CheapPlaces in it.") { }
    }
}
