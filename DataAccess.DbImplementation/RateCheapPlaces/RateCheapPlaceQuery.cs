using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateCheapPlaces;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateCheapPlaces
{
    public class RateCheapPlaceQuery : IRateCheapPlaceQuery
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RateCheapPlaceQuery(AppDbContext context, IHostingEnvironment appEnvironment, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RateCheapPlaceResponse> RunAsync(Guid cheapPlaceId)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            RateCheapPlaceResponse response = await _context.RateCheapPlaces
                .ProjectTo<RateCheapPlaceResponse>()
                .FirstOrDefaultAsync(p => p.CheapPlaceId == cheapPlaceId &&
                                          p.UserWhoGiveMarkId == currentUser.Id
                                          );
            return response;
        }
    }
}
