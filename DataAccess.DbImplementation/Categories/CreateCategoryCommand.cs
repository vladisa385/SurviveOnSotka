using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Categories;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class CreateCategoryCommand : CreateCommand<CreateCategoryRequest,CategoryResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        protected override async Task<CategoryResponse> CreateItem(CreateCategoryRequest request)
        {
            var category = _mapper.Map<CreateCategoryRequest, Category>(request);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<Category, CategoryResponse>(category);
        }

        protected override void HandleError(Exception exception)
        {
            switch (exception)
            {
                case DbUpdateException _:
                    throw new CreateItemException("Category cannot be created, The ParentCategory's guid is incorrect", exception);
            }
            base.HandleError(exception);
        }
    }
}
