using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class DeleteTypeFoodCommand : DeleteCommand<TypeFoodResponse>
    {
        private readonly AppDbContext _context;

        public DeleteTypeFoodCommand(AppDbContext context)
        {
            _context = context;
        }

        protected override async Task DeleteItem(Guid typeFoodId)
        {
            var typeFoodToDelete = await _context.TypeFoods
                .Include(u => u.Ingredients)
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
