using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

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
            TypeFood typeFoodToDelete = await _context.TypeFoods.FirstOrDefaultAsync(p => p.Id == typeFoodId);
            if (typeFoodToDelete?.Ingredients?.Count > 0)
            {
                throw new CannotDeleteTypeFoodWithIngredientsExeption();
            }

            if (typeFoodToDelete != null)
            {
                if (typeFoodToDelete.PathToIcon != null)
                    DeleteFileCommand.Execute(typeFoodToDelete.PathToIcon);
                _context.TypeFoods.Remove(typeFoodToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
