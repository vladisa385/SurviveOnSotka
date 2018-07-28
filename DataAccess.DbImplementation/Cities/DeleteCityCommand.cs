using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Cities;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.Cities
{
    public class DeleteCityCommand : IDeleteCityCommand

    {

        private readonly AppDbContext _context;

        public DeleteCityCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid cityId)
        {
            City cityToDelete = await _context.Cities.FirstOrDefaultAsync(p => p.Id == cityId);
            if (cityToDelete?.CheapPlaces?.Count > 0)
            {
                throw new CannotDeleteCityWithCheapPlacesExeption();
            }

            if (cityToDelete != null)
            {
                _context.Cities.Remove(cityToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
