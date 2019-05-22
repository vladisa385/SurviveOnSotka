using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{

    public class CreateIngredientCommand : CreateCommand<CreateIngredientRequest,IngredientResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreateIngredientCommand(AppDbContext dbContext, IMapper mapper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        protected override  async Task<IngredientResponse> CreateItem(CreateIngredientRequest request)
        {
            var ingredient = _mapper.Map<CreateIngredientRequest, Ingredient>(request);
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
            return _mapper.Map<Ingredient, IngredientResponse>(ingredient);
        }

        protected override void HandleError(Exception exception)
        {
            switch (exception)
            {
                case DbUpdateException _:
                    throw new CreateItemException("Ingredient cannot be created, The TypeFood's guid is incorrect", exception);
            }
            base.HandleError(exception);
        }
    }
}
