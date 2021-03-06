﻿using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class DeleteTypeFoodCommand : Command<SimpleDeleteRequest, EmptyResponse<TypeFoodResponse>>
    {
        private readonly AppDbContext _context;

        public DeleteTypeFoodCommand(AppDbContext context) => _context = context;

        protected override async Task<EmptyResponse<TypeFoodResponse>> Execute(SimpleDeleteRequest request)
        {
            var typeFoodToDelete = await _context.TypeFoods
                .Include(u => u.Ingredients)
                .FirstOrDefaultAsync(p => p.Id == request.Id);
            if (typeFoodToDelete?.Ingredients?.Count > 0)
                throw new DeleteItemException("Cannot delete typeFood with ingredients");
            if (typeFoodToDelete != null)
            {
                _context.TypeFoods.Remove(typeFoodToDelete);
                await _context.SaveChangesAsync();
            }
            return new EmptyResponse<TypeFoodResponse>();
        }
    }
}