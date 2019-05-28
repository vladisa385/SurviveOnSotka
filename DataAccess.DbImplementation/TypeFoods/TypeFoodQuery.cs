using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;
using System;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class TypeFoodQuery : Query<TypeFoodResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TypeFoodQuery(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        protected override async Task<TypeFoodResponse> QueryItem(Guid typeFoodId)
        {
            var response = await _context.TypeFoods
                  .ProjectTo<TypeFoodResponse>(_mapper.ConfigurationProvider)
                  .FirstOrDefaultAsync(p => p.Id == typeFoodId);
            return response;
        }
    }
}