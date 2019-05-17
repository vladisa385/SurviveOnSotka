using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class RecipiesListQuery : IRecipiesListQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RecipiesListQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private IQueryable<RecipeResponse> ApplyFilter(IQueryable<RecipeResponse> query, RecipeFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }
            if (filter.UserId != null)
            {
                query = query.Where(p => p.User.Id == filter.UserId);
            }
            if (filter.Name != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }
            if (filter.Categories != null)
            {
                if (filter.Categories.From != null)
                {
                    query = query.Where(p => p.CategoriesCount >= filter.Categories.From);
                }

                if (filter.Categories.To != null)
                {
                    query = query.Where(p => p.CategoriesCount <= filter.Categories.To);
                }
            }
            if (filter.Reviews != null)
            {
                if (filter.Reviews.From != null)
                {
                    query = query.Where(p => p.Reviews.Count >= filter.Reviews.From);
                }

                if (filter.Reviews.To != null)
                {
                    query = query.Where(p => p.Reviews.Count <= filter.Reviews.To);
                }
            }
            if (filter.DateCreated != null)
            {

                query = query.Where(p => p.DateCreated >= filter.DateCreated.From);

            }
            if (filter.Description != null)
            {

                query = query.Where(p => p.Description.Contains(filter.Description));

            }
            if (filter.Rate != null)
            {
                if (filter.Rate.From != null)
                {
                    query = query.Where(p => p.Rate >= filter.Rate.From);
                }

                if (filter.Rate.To != null)
                {
                    query = query.Where(p => p.Rate <= filter.Rate.To);
                }
            }
            if (filter.TimeForCooking != null)
            {
                if (filter.TimeForCooking.From != null)
                {
                    query = query.Where(p => p.TimeForCooking >= filter.TimeForCooking.From);
                }

                if (filter.TimeForCooking.To != null)
                {
                    query = query.Where(p => p.TimeForCooking <= filter.TimeForCooking.To);
                }
            }
            if (filter.TimeForPreparetion != null)
            {
                if (filter.TimeForPreparetion.From != null)
                {
                    query = query.Where(p => p.TimeForPreparetion >= filter.TimeForPreparetion.From);
                }

                if (filter.TimeForPreparetion.To != null)
                {
                    query = query.Where(p => p.TimeForPreparetion <= filter.TimeForPreparetion.To);
                }
            }
            if (filter.Tags != null)
            {
                foreach (var tag in filter.Tags)
                {
                    query = query.Where(u => u.Tags.Any(y => y.Tag == tag));
                }
            }
            //if (filter.Ingredients != null)
            //{
            //    foreach (var ingredient in filter.Ingredients)
            //    {

            //        query = query.Where(u => u.Ingredients.Any(y =>
            //            ingredient.Id == filter.Id
            //            &&
            //            ingredient.Amount.From == null || y.Amount >= ingredient.Amount.From
            //            &&
            //            ingredient.Amount.To == null || y.Amount >= ingredient.Amount.To
            //            &&
            //            ingredient.Price.From == null || y.Amount >= ingredient.Price.From
            //            &&
            //            ingredient.Price.To == null || y.Amount >= ingredient.Price.To
            //            &&
            //            ingredient.Amount.From == null || y.Amount >= ingredient.Amount.From
            //            &&
            //            ingredient.Amount.To == null || y.Amount >= ingredient.Amount.To
            //            ));
            //    }
            //}
            return query;


        }

        public async Task<ListResponse<RecipeResponse>> RunAsync(RecipeFilter filter, ListOptions options)
        {
            IQueryable<RecipeResponse> query = _context.Recipes
                .Include("Ingredients")
                .Include("Categories")
                .Include("Reviews")
                .Include("Ingredients")
                .Include("Steps")
                .Include("Tags")
                .ProjectTo<RecipeResponse>(_mapper.ConfigurationProvider); ;
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<RecipeResponse>
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

