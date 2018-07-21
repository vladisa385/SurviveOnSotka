using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.CheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.CheapPlaces
{
    public class CheapPlaceQuery : ICheapPlaceQuery
    {
        private readonly AppDbContext _context;
        public CheapPlaceQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CheapPlaceResponse> RunAsync(Guid cheapPlaceId)
        {
            CheapPlaceResponse response = await _context.CheapPlaces
                .ProjectTo<CheapPlaceResponse>()
                .FirstOrDefaultAsync(p => p.Id == cheapPlaceId);
            return response;
        }
    }
}

