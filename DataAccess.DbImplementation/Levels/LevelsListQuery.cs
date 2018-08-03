using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Levels;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Levels;

namespace SurviveOnSotka.DataAccess.DbImplementation.Levels
{
    public class LevelsListQuery : ILevelsListQuery
    {
        private readonly AppDbContext _context;
        public LevelsListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;

        }

        private IQueryable<LevelResponse> ApplyFilter(IQueryable<LevelResponse> query, LevelFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }
            if (filter.LastLevelId != null)
            {
                query = query.Where(p => p.LastLevelId == filter.LastLevelId);
            }
            if (filter.NextLevelId != null)
            {
                query = query.Where(p => p.NextLevelId == filter.NextLevelId);
            }
            if (filter.Name != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }

            if (filter.Users != null)
            {
                if (filter.Users.From != null)
                {
                    query = query.Where(p => p.MinScore >= filter.Users.From);
                }

                if (filter.Users.To != null)
                {
                    query = query.Where(p => p.MinScore <= filter.Users.To);
                }
            }
            if (filter.MinScore != null)
            {
                if (filter.MinScore.From != null)
                {
                    query = query.Where(p => p.MinScore >= filter.MinScore.From);
                }

                if (filter.MinScore.To != null)
                {
                    query = query.Where(p => p.MinScore <= filter.MinScore.To);
                }
            }
            if (filter.MaxScore != null)
            {
                if (filter.MaxScore.From != null)
                {
                    query = query.Where(p => p.MaxScore >= filter.MaxScore.From);
                }

                if (filter.MaxScore.To != null)
                {
                    query = query.Where(p => p.MaxScore <= filter.MaxScore.To);
                }
            }
            return query;
        }

        public async Task<ListResponse<LevelResponse>> RunAsync(LevelFilter filter, ListOptions options)
        {
            IQueryable<LevelResponse> query = _context.Levels.Include("Users")
                .ProjectTo<LevelResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<LevelResponse>
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
