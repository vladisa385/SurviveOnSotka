using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class RecipeQuery : Query<RecipeResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RecipeQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        protected override async Task<RecipeResponse> QueryItem(Guid recipeId)
        {
            var response = await _context.Recipes
               .ProjectTo<RecipeResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(p => p.Id == recipeId);
            return response;
        }
    }
}
