using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.DataAccess.ViewModels;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class ReviewsListQuery : IReviewsListQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReviewsListQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<ReviewResponse> ApplyFilter(IQueryable<ReviewResponse> query, ReviewFilter filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);
            if (filter.Text != null)
                query = query.Where(p => p.Text.Contains(filter.Text));
            if (filter.Rate != null)
            {
                if (filter.Rate.From != null)
                    query = query.Where(p => p.Rate >= filter.Rate.From);

                if (filter.Rate.To != null)
                    query = query.Where(p => p.Rate <= filter.Rate.To);
            }
            if (filter.DateCreated != null)
                query = query.Where(p => p.DateCreated >= filter.DateCreated);
            if (filter.AuthorId != null)
                query = query.Where(p => p.Author.Id == filter.AuthorId);
            if (filter.RecipeId != null)
                query = query.Where(p => p.RecipeId == filter.RecipeId);
            if (filter.DisLikes != null)
            {
                if (filter.DisLikes.From != null)
                    query = query.Where(p => p.DisLikes >= filter.DisLikes.From);

                if (filter.DisLikes.To != null)
                    query = query.Where(p => p.DisLikes <= filter.DisLikes.To);
            }
            if (filter.Likes != null)
            {
                if (filter.Likes.From != null)
                    query = query.Where(p => p.Likes >= filter.Likes.From);

                if (filter.Likes.To != null)
                    query = query.Where(p => p.Likes <= filter.Likes.To);
            }
            return query;
        }
        public async Task<ListResponse<ReviewResponse>> RunAsync(ReviewFilter filter, ListOptions options)
        {
            var query = _context.Reviews
                .Include("Ingredients")
                .ProjectTo<ReviewResponse>(_mapper.ConfigurationProvider);
            query = ApplyFilter(query, filter);
            if (options.Sort == null)
                options.Sort = "Id";
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            var totalCount = await query.CountAsync();
            var items = await query.ToListAsync();
            return new ListResponse<ReviewResponse>
            {
                Items = items,
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                Sort = options.Sort ?? "-Id",
                TotalItemsCount = totalCount
            };
        }
    }
}

