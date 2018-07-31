using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.DataAccess.DbImplementation.Files;

using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class DeleteReviewCommand : IDeleteReviewCommand
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly AppDbContext _context;

        public DeleteReviewCommand(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task ExecuteAsync(Guid reviewId)
        {
            Review reviewToDelete = await _context.Reviews.Include(t => t.Author).FirstOrDefaultAsync(p => p.Id == reviewId);

            if (reviewToDelete != null)
            {
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var isAdmin = await _userManager.IsInRoleAsync(currentUser, "admin");
                if (reviewToDelete.Author != currentUser && !isAdmin)
                    throw new ThisRequestNotFromOwnerException();
                if (reviewToDelete.PathToPhotos != null)
                    DeleteFileCommand.Execute(reviewToDelete.PathToPhotos);
                _context.Reviews.Remove(reviewToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
