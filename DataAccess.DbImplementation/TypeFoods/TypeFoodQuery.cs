using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class TypeFoodQuery : ITypeFoodQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TypeFoodQuery(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<TypeFoodResponse> RunAsync(Guid typeFoodId)
        {
            TypeFoodResponse response = await _context.TypeFoods
                .ProjectTo<TypeFoodResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == typeFoodId);
            return response;
        }
    }
}

