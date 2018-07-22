using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.ViewModel.Users
{
    public class UserFilter
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? IdLevel { get; set; }
        public int CurrentScore { get; set; }
        public bool Gender { get; set; }
        public string AboutYourself { get; set; }
        public RangeFilter<int> Recipies { get; set; }
        public RangeFilter<int> Reviews { get; set; }
        public RangeFilter<int> CheapPlaces { get; set; }
        public RangeFilter<int> RateReviews { get; set; }
    }
}
