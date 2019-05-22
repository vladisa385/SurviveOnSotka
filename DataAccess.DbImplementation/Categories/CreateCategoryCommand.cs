using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.Exceptions;
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
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new CreateItemException("Category cannot be created, The ParentCategory's guid is incorrect",exception);
            }
            return _mapper.Map<Category, CategoryResponse>(category);
        }
    }
}
