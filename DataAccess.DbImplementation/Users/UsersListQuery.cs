using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class UsersListQuery : IUsersListQuery
    {
        private readonly AppDbContext _context;
        public UsersListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;

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
            if (filter.CheapPlaces != null)
            {
                if (filter.CheapPlaces.From != null)
                {
                    query = query.Where(p => p.CheapPlacesCount >= filter.CheapPlaces.From);
                }

                if (filter.CheapPlaces.To != null)
                {
                    query = query.Where(p => p.CheapPlacesCount <= filter.CheapPlaces.To);
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
                .ProjectTo<UserResponse>();
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

