using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Tags;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Tags;

namespace SurviveOnSotka.DataAccess.DbImplementation.Tags
{
    public class TagsListQuery : ITagsListQuery
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;
        public TagsListQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ListResponse<TagResponse>> RunAsync(TagFilter filter, ListOptions options)
        {
            IQueryable<TagResponse> query = _context.Tags.ProjectTo<TagResponse>();
            query = ApplyFilter(query, filter);
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            //todo: refactor to use automapper
            return new ListResponse<TagResponse>
            {
                Items = await query.ToListAsync(),
                Sort = options.Sort ?? "-Id",
                Page = options.Page,
                PageSize = options.PageSize ?? -1,

            };
        }

        private IQueryable<TagResponse> ApplyFilter(IQueryable<TagResponse> query, TagFilter filter)
        {
            if (filter.Name != null)
            {
                query = query.Where(t => t.Name.StartsWith(filter.Name));
            }
            return query;
        }
    }
}
