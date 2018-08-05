using System;
using System.Collections.Generic;

namespace SurviveOnSotka.ViewModel.CheapPlaces
{
    public class CheapPlaceFilter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid? CityId { get; set; }
        public Guid? UserId { get; set; }
        public RangeFilter<int> Likes { get; set; }
        public RangeFilter<int> DisLikes { get; set; }
        public ICollection<string> Tags { get; set; }

    }
}
