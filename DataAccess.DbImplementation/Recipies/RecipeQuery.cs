using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class RecipeQuery : IRecipeQuery
    {
        private readonly AppDbContext _context;

        public RecipeQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RecipeResponse> RunAsync(Guid recipeId)
        {
            RecipeResponse response = await _context.Recipes
                 .ProjectTo<RecipeResponse>()
                 .FirstOrDefaultAsync(p => p.Id == recipeId);
            return response;
        }
    }
}
