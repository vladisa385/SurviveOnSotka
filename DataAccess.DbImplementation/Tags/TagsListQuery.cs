using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Tags;

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
        protected override IQueryable<TagResponse> ApplyFilter(IQueryable<TagResponse> query, TagFilter filter)
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

        protected override IQueryable<TagResponse> GetQuery() => _context.Tags.ProjectTo<TagResponse>(_mapper.ConfigurationProvider);
    }
}
