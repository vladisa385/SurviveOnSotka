using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{

    public class CreateIngredientCommand : ICreateIngredientCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreateIngredientCommand(AppDbContext dbContext, IMapper mapper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<IngredientResponse> ExecuteAsync(CreateIngredientRequest request)
        {
            var ingredient = _mapper.Map<CreateIngredientRequest, Ingredient>(request);
            try
            {
                await _context.Ingredients.AddAsync(ingredient);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new CreateItemException("Ingredient cannot be created, The TypeFood's guid is incorrect", exception);
            }
            return _mapper.Map<Ingredient, IngredientResponse>(ingredient);
        }
    }
}
