using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Tags;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.DbImplementation.Tags
{
    public class TagsListQuery : ListQuery<TagResponse,TagFilter>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TagsListQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        protected override async Task<ListResponse<TagResponse>> QueryListItem(TagFilter filter, ListOptions options)
        {
            var query = _context.Tags.ProjectTo<TagResponse>(_mapper.ConfigurationProvider);
            query = ApplyFilter(query, filter);
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            var items = await query.ToListAsync();
            return new ListResponse<TagResponse>
            {
                Items = items,
                Sort = options.Sort ?? "-Id",
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
            };
        }

        private IQueryable<TagResponse> ApplyFilter(IQueryable<TagResponse> query, TagFilter filter)
        {
            if (filter.Name != null)
                query = query.Where(t => t.Name.StartsWith(filter.Name));
            if (filter.RecepiesCount == null) return query;
            if (filter.RecepiesCount.From != null)
                query = query.Where(p => p.RecipiesCount >= filter.RecepiesCount.From);
            if (filter.RecepiesCount.To != null)
                query = query.Where(p => p.RecipiesCount <= filter.RecepiesCount.To);
            return query;
        }
    }
}
