using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class DeleteRecipeCommand : IDeleteRecipeCommand
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly AppDbContext _context;

        public DeleteRecipeCommand(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task ExecuteAsync(Guid recipeId)
        {
            Recipe recipeToDelete = await _context.Recipes.Include(t => t.User).FirstOrDefaultAsync(p => p.Id == recipeId);

            if (recipeToDelete != null)
            {
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var isAdmin = await _userManager.IsInRoleAsync(currentUser, "admin");
                if (recipeToDelete.User != currentUser && !isAdmin)
                    throw new ThisRequestNotFromOwnerException();
                if (recipeToDelete.PathToPhotos != null)
                    DeleteFileCommand.Execute(recipeToDelete.PathToPhotos);
                _context.Recipes.Remove(recipeToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
