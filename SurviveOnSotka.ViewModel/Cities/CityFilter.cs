using System;

namespace SurviveOnSotka.ViewModel.Cities
{
    public class CityFilter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<int> CheapPlaces { get; set; }
    }
}
