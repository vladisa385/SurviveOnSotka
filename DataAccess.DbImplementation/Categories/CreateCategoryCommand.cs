using System.Threading.Tasks;
using AutoMapper;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class CreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<CategoryResponse> ExecuteAsync(CreateCategoryRequest request)
        {
            var category = _mapper.Map<CreateCategoryRequest, Category>(request);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<Category, CategoryResponse>(category);
        }
    }
}
