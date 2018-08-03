using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.CheapPlaces
{


    public class DeleteCheapPlaceCommand : IDeleteCheapPlaceCommand
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly AppDbContext _context;

        public DeleteCheapPlaceCommand(AppDbContext dbContext, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = dbContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task ExecuteAsync(Guid cheapPlaceId)
        {
            CheapPlace cheapPlaceToDelete = await _context.CheapPlaces.Include(t => t.User).FirstOrDefaultAsync(p => p.Id == cheapPlaceId);

            if (cheapPlaceToDelete != null)
            {
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var isAdmin = await _userManager.IsInRoleAsync(currentUser, "admin");
                if (cheapPlaceToDelete.User != currentUser && !isAdmin)
                    throw new ThisRequestNotFromOwnerException();
                if (cheapPlaceToDelete.PathToPhotos != null)
                    DeleteFileCommand.Execute(cheapPlaceToDelete.PathToPhotos);
                _context.CheapPlaces.Remove(cheapPlaceToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
