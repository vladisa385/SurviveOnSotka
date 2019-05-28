using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using System.Linq;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class UsersListQuery : ListQuery<UserResponse, UserFilter>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsersListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }
        protected override IQueryable<UserResponse> ApplyFilter(IQueryable<UserResponse> query, UserFilter filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);
            if (filter.FirstName != null)
                query = query.Where(p => p.FirstName.StartsWith(filter.FirstName));
            if (filter.LastName != null)
                query = query.Where(p => p.LastName.StartsWith(filter.LastName));
            if (filter.AboutYourself != null)
                query = query.Where(p => p.AboutYourself.Contains(filter.AboutYourself));
            if (filter.Recipies != null)
            {
                if (filter.Recipies.From != null)
                    query = query.Where(p => p.RecipiesCount >= filter.Recipies.From);

                if (filter.Recipies.To != null)
                    query = query.Where(p => p.RecipiesCount <= filter.Recipies.To);
            }

            if (filter.Reviews != null)
            {
                if (filter.Reviews.From != null)
                    query = query.Where(p => p.ReviewsCount >= filter.Reviews.From);

                if (filter.Reviews.To != null)
                    query = query.Where(p => p.ReviewsCount <= filter.Reviews.To);
            }
            if (filter.RateReviews != null)
            {
                if (filter.RateReviews.From != null)
                    query = query.Where(p => p.RateReviewsCount >= filter.RateReviews.From);

                if (filter.RateReviews.To != null)
                    query = query.Where(p => p.RateReviewsCount <= filter.RateReviews.To);
            }
            return query;
        }

        protected override IQueryable<UserResponse> GetQuery() =>
            _context.Users
                .Include(u => u.Recipies)
                .Include(u => u.Reviews)
                .Include(u => u.RateReviews)
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider);
    }
}