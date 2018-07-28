using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Reviews
{
    public class ReviewFilter
    {
        public Guid RecipeId { get; set; }
        public string AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public RangeFilter<int> Rate { get; set; }
        public string PathToPhotos { get; set; }
        public RangeFilter<int> RateReviewsCount { get; set; }

        public RangeFilter<int> Likes { get; set; }

        public RangeFilter<int> DisLikes { get; set; }
    }
}
