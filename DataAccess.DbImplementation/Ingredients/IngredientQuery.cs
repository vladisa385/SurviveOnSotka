using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class IngredientQuery : IIngredientQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public IngredientQuery(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<IngredientResponse> RunAsync(Guid ingredientId)
        {
            var response = await _context.Ingredients
                .ProjectTo<IngredientResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == ingredientId);
            return response;
        }
    }
}

