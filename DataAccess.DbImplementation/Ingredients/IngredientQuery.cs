using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Ingredients;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class IngredientQuery : IIngredientQuery
    {
        private readonly AppDbContext _context;
        public IngredientQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IngredientResponse> RunAsync(Guid ingredientId)
        {
            IngredientResponse response = await _context.Ingredients
                .ProjectTo<IngredientResponse>()
                .FirstOrDefaultAsync(p => p.Id == ingredientId);
            return response;
        }
    }
}

