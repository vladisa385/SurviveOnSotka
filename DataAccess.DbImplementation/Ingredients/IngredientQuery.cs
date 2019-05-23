using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class IngredientQuery : Query<IngredientResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public IngredientQuery(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        protected override async Task<IngredientResponse> QueryItem(Guid ingredientId)
        {
            var response = await _context.Ingredients
                .ProjectTo<IngredientResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == ingredientId);
            return response;
        }
    }
}