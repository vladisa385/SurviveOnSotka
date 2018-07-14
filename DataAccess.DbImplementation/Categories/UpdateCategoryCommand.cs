using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class UpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public UpdateCategoryCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<CategoryResponse> ExecuteAsync(Guid categoryId, UpdateCategoryRequest request)
        {
            Category foundCategory = await _context.Categories.FirstOrDefaultAsync(t => t.Id == categoryId);
            if (foundCategory != null)
            {
                Category mappedCategory = _mapper.Map<UpdateCategoryRequest, Category>(request);
                mappedCategory.Id = categoryId;
                _context.Entry(foundCategory).CurrentValues.SetValues(mappedCategory);
                if (request.Icon != null)
                {
                    mappedCategory.PathToIcon = _appEnvironment.WebRootPath + "/Files/Categories/" + request.Icon.FileName;
                    await CreateFileCommand.ExecuteAsync(request.Icon, _appEnvironment.WebRootPath + mappedCategory.PathToIcon);
                }
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Category, CategoryResponse>(foundCategory);
        }
    }
}
