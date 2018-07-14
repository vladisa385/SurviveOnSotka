using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class UpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateCategoryCommand(AppDbContext dbContext, IMapper mappper)
        {
            _context = dbContext;
            _mapper = mappper;
        }
        public async Task<CategoryResponse> ExecuteAsync(Guid categoryId, UpdateCategoryRequest request)
        {
            Category foundCategory = await _context.Categories.FirstOrDefaultAsync(t => t.Id == categoryId);
            if (foundCategory != null)
            {
                Category mappedCategory = _mapper.Map<UpdateCategoryRequest, Category>(request);
                mappedCategory.Id = categoryId;
                _context.Entry(foundCategory).CurrentValues.SetValues(mappedCategory);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Category, CategoryResponse>(foundCategory);
        }
    }
}
