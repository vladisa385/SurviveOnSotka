using System;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.CheapPlaces
{
    public class CheapPlaceFilter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid? CityId { get; set; }
    }
}
