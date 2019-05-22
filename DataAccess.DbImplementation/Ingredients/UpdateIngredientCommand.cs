using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class UpdateIngredientCommand : IUpdateIngredientCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateIngredientCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<IngredientResponse> ExecuteAsync(UpdateIngredientRequest request)
        {
            var foundIngredient = await _context.Ingredients.FirstOrDefaultAsync(t => t.Id == request.Id);
            if(foundIngredient==null)
                throw new UpdateItemException($"Ingredient with id: {request.Id} not found");
            var mappedIngredient = _mapper.Map<UpdateIngredientRequest, Ingredient>(request);
            _context.Entry(foundIngredient).CurrentValues.SetValues(mappedIngredient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new UpdateItemException("Ingredient cannot be update, The TypeFood's guid is incorrect", exception);
            }
            return _mapper.Map<Ingredient, IngredientResponse>(foundIngredient);
        }
    }
}
