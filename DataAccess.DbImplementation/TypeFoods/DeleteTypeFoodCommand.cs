using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class DeleteTypeFoodCommand : IDeleteTypeFoodCommand
    {
        private readonly AppDbContext _context;
        public DeleteTypeFoodCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid typeFoodId)
        {
            var typeFoodToDelete = await _context.TypeFoods
                .Include(u=>u.Ingredients)
                .FirstOrDefaultAsync(p => p.Id == typeFoodId);
            if (typeFoodToDelete?.Ingredients?.Count > 0)
                throw new DeleteItemCrudException("Cannot delete typeFood with ingredients");
            if (typeFoodToDelete != null)
            {
                _context.TypeFoods.Remove(typeFoodToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
