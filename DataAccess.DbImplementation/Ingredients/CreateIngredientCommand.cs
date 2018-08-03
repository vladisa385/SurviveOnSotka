using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Ingredients;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{

    public class CreateIngredientCommand : ICreateIngredientCommand
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        public CreateIngredientCommand(AppDbContext dbContext, IMapper mapper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }
        public async Task<IngredientResponse> ExecuteAsync(CreateIngredientRequest request)
        {
            if (!_context.TypeFoods.Any(u => u.Id == request.TypeFoodId))
            {
                throw new CannotCreateOrUpdateIngredientWithThisTypeFoodGuidException();
            }
            var ingredient = _mapper.Map<CreateIngredientRequest, Ingredient>(request);
            await _context.Ingredients.AddAsync(ingredient);
            if (request.Icon != null)
            {
                string basedir = _appEnvironment.WebRootPath + "/Files/Ingredients/";
                ingredient.PathToIcon = basedir + request.Icon.FileName;
                await CreateFileCommand.ExecuteAsync(request.Icon, basedir);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Ingredient, IngredientResponse>(ingredient);
        }


    }
}
