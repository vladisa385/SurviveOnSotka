using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Levels;
using SurviveOnSotka.Db;

namespace SurviveOnSotka.DataAccess.DbImplementation.Levels
{
    public class DeleteLevelCommand : IDeleteLevelCommand
    {
        private readonly AppDbContext _context;

        public DeleteLevelCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid levelId)
        {

            Entities.Level levelToDelete = await _context.Levels.FirstOrDefaultAsync(p => p.Id == levelId);
            if (levelToDelete?.Users?.Count > 0)
            {
                throw new CannotDeleteLevelWithUsersExeption();
            }

            if (levelToDelete != null)
            {
                if (levelToDelete.PathToIcon != null)
                    DeleteFileCommand.Execute(levelToDelete.PathToIcon);
                _context.Levels.Remove(levelToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
