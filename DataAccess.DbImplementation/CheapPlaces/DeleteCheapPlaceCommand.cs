using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.CheapPlaces
{
    public class DeleteCheapPlaceCommand : IDeleteCheapPlaceCommand
    {
        private readonly AppDbContext _context;

        public DeleteCheapPlaceCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid cheapPlaceId)
        {
            CheapPlace cheapPlaceToDelete = await _context.CheapPlaces.FirstOrDefaultAsync(p => p.Id == cheapPlaceId);

            if (cheapPlaceToDelete != null)
            {
                if (cheapPlaceToDelete.PathToPhotos != null)
                    DeleteFileCommand.Execute(cheapPlaceToDelete.PathToPhotos);
                _context.CheapPlaces.Remove(cheapPlaceToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
