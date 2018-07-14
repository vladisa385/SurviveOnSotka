using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class CreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        public CreateCategoryCommand(AppDbContext dbContext, IMapper mapper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }
        public async Task<CategoryResponse> ExecuteAsync(CreateCategoryRequest request)
        {
            var category = _mapper.Map<CreateCategoryRequest, Category>(request);
            await _context.Categories.AddAsync(category);
            if (request.Icon != null)
            {
                category.PathToIcon = _appEnvironment.WebRootPath + "/Files/Categories/" + request.Icon.FileName;
                await CreateFileCommand.ExecuteAsync(request.Icon, _appEnvironment.WebRootPath + category.PathToIcon);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Category, CategoryResponse>(category);
        }
    }
}
