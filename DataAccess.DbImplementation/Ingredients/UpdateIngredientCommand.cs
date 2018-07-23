using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Ingredients;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class UpdateIngredientCommand : IUpdateIngredientCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public UpdateIngredientCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<IngredientResponse> ExecuteAsync(Guid typefoodId, UpdateIngredientRequest request)
        {
            Ingredient foundIngredient = await _context.Ingredients.FirstOrDefaultAsync(t => t.Id == typefoodId);
            if (foundIngredient != null)
            {
                Ingredient mappedIngredient = _mapper.Map<UpdateIngredientRequest, Ingredient>(request);
                mappedIngredient.Id = typefoodId;
                _context.Entry(foundIngredient).CurrentValues.SetValues(mappedIngredient);
                if (request.Icon != null)
                {
                    string basedir = _appEnvironment.WebRootPath + "/Files/Ingredients/";
                    mappedIngredient.PathToIcon = basedir + request.Icon.FileName;
                    await CreateFileCommand.ExecuteAsync(request.Icon, basedir);
                }
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Ingredient, IngredientResponse>(foundIngredient);
        }
    }
}
