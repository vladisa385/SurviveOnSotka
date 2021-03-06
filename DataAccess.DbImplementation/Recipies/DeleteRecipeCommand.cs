﻿using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class DeleteRecipeCommand : Command<SimpleDeleteRequest, EmptyResponse<RecipeResponse>>
    {
        private readonly AppDbContext _context;

        public DeleteRecipeCommand(AppDbContext context) => _context = context;

        protected override async Task<EmptyResponse<RecipeResponse>> Execute(SimpleDeleteRequest request)
        {
            var recipeToDelete = await _context.Recipes
                .Include(t => t.User)
                .FirstOrDefaultAsync(p => p.Id == request.Id);
            if (recipeToDelete == null) return null;
            if (!request.IsLegalAccess(recipeToDelete.UserId))
                throw new IllegalAccessException();
            _context.Recipes.Remove(recipeToDelete);
            await _context.SaveChangesAsync();
            return new EmptyResponse<RecipeResponse>();
        }
    }
}