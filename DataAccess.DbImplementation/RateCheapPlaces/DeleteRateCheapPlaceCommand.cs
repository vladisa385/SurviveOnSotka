using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateCheapPlaces;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateCheapPlaces
{
    public class DeleteRateCheapPlaceCommand : IDeleteRateCheapPlaceCommand

    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeleteRateCheapPlaceCommand(AppDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task ExecuteAsync(Guid cheapPlaceId)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            RateCheapPlace rateCheapPlaceToDelete = await _context.RateCheapPlaces.FirstOrDefaultAsync(p => p.CheapPlaceId == cheapPlaceId && p.UserWhoGiveMarkId == currentUser.Id);
            if (rateCheapPlaceToDelete != null)
            {
                _context.RateCheapPlaces.Remove(rateCheapPlaceToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
