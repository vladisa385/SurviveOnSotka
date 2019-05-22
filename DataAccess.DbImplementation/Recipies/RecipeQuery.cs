using System;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public RecipeQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RecipeResponse> RunAsync(Guid recipeId)
        {
            var response = await _context.Recipes
                 .ProjectTo<RecipeResponse>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync(p => p.Id == recipeId);
            return response;
        }
    }
}
