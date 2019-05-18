using System;
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
    public class UpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateCategoryCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<CategoryResponse> ExecuteAsync(Guid categoryId, UpdateCategoryRequest request)
        {
            var foundCategory = await _context.Categories.FirstOrDefaultAsync(t => t.Id == categoryId);
            if (foundCategory == null)
            {
                throw new UpdateItemException($"category with id: {categoryId} not found");
            }
            var mappedCategory = _mapper.Map<UpdateCategoryRequest, Category>(request);
            mappedCategory.Id = categoryId;
            _context.Entry(foundCategory).CurrentValues.SetValues(mappedCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new UpdateItemException("Category cannot be update, The ParentCategory's guid is incorrect")
                {
                    DbUpdateException = exception,
                };
            }
            return _mapper.Map<Category, CategoryResponse>(foundCategory);
        }
    }
}
