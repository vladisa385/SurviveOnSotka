using System;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.ViewModel.Implementanion.Reviews
{
    public class ReviewFilter:Filter
    {
        public Guid? Id { get; set; }
        public Guid? RecipeId { get; set; }
        public Guid? AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime? DateCreated { get; set; }
        public RangeFilter<int> Rate { get; set; }
        public string PathToPhotos { get; set; }
        public RangeFilter<int> RateReviewsCount { get; set; }

        public RangeFilter<int> Likes { get; set; }

        public RangeFilter<int> DisLikes { get; set; }
    }
}
