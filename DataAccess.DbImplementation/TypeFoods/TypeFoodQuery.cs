using System;
using System.Threading.Tasks;
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
        public TypeFoodQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<TypeFoodResponse> RunAsync(Guid typeFoodId)
        {
            TypeFoodResponse response = await _context.TypeFoods
                .ProjectTo<TypeFoodResponse>()
                .FirstOrDefaultAsync(p => p.Id == typeFoodId);
            return response;
        }
    }
}

