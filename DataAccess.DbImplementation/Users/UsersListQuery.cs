using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.DataAccess.ViewModels;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class UsersListQuery : IUsersListQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UsersListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }

        private IQueryable<UserResponse> ApplyFilter(IQueryable<UserResponse> query, UserFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.FirstName != null)
            {
                query = query.Where(p => p.FirstName.StartsWith(filter.FirstName));
            }
            if (filter.LastName != null)
            {
                query = query.Where(p => p.LastName.StartsWith(filter.LastName));
            }
            if (filter.AboutYourself != null)
            {
                query = query.Where(p => p.AboutYourself.Contains(filter.AboutYourself));
            }
            if (filter.Recipies != null)
            {
                if (filter.Recipies.From != null)
                {
                    query = query.Where(p => p.RecipiesCount >= filter.Recipies.From);
                }

                if (filter.Recipies.To != null)
                {
                    query = query.Where(p => p.RecipiesCount <= filter.Recipies.To);
                }
            }

            if (filter.Reviews != null)
            {
                if (filter.Reviews.From != null)
                {
                    query = query.Where(p => p.ReviewsCount >= filter.Reviews.From);
                }

                if (filter.Reviews.To != null)
                {
                    query = query.Where(p => p.ReviewsCount <= filter.Reviews.To);
                }
            }
            if (filter.RateReviews != null)
            {
                if (filter.RateReviews.From != null)
                {
                    query = query.Where(p => p.RateReviewsCount >= filter.RateReviews.From);
                }

                if (filter.RateReviews.To != null)
                {
                    query = query.Where(p => p.RateReviewsCount <= filter.RateReviews.To);
                }
            }
            return query;
        }

        public async Task<ListResponse<UserResponse>> RunAsync(UserFilter filter, ListOptions options)
        {
            IQueryable<UserResponse> query = _context.Users
                .Include("Recipies")
                .Include("Reviews")
                .Include("CheapPlaces")
                .Include("RateReviews")
                 .Include("RateCheapPlaces")
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider);
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<UserResponse>
            {
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                Sort = options.Sort ?? "-Id",
                TotalItemsCount = totalCount
            };
        }
    }
}

