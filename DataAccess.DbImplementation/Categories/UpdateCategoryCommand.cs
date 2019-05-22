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
    public class UpdateCategoryCommand : Command<UpdateCategoryRequest,CategoryResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateCategoryCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }


        protected override void HandleError(Exception exception)
        {
            switch (exception)
            {
                case DbUpdateException _:
                     throw new UpdateItemException("Category cannot be update, The ParentCategory's guid is incorrect", exception);
            }
            base.HandleError(exception);
        }

        protected override  async Task<CategoryResponse> Execute(UpdateCategoryRequest request)
        {
            var foundCategory = await _context.Categories
                .FirstOrDefaultAsync(t => t.Id == request.Id);
            if (foundCategory == null)
                throw new UpdateItemException($"category with id: {request.Id} not found");
            var mappedCategory = _mapper.Map<UpdateCategoryRequest, Category>(request);
            _context.Entry(foundCategory).CurrentValues.SetValues(mappedCategory);
            await _context.SaveChangesAsync();
            return _mapper.Map<Category, CategoryResponse>(foundCategory);
        }
    }
}
