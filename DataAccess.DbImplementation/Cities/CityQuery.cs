using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Cities;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Cities;


namespace SurviveOnSotka.DataAccess.DbImplementation.Cities
{
    public class CityQuery:ICityQuery
    {
        private readonly AppDbContext _context;
        public CityQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CityResponse> RunAsync(Guid cityId)
        {
            CityResponse response = await _context.Cities
                .ProjectTo<CityResponse>()
                .FirstOrDefaultAsync(p => p.Id == cityId);
            return response;
        }
    }
}
