using System;
using System.Threading.Tasks;
using AutoMapper;
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
    public class CreateRateCheapPlaceCommand : ICreateRateCheapPlaceCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateRateCheapPlaceCommand(AppDbContext context, IMapper mapper, IHostingEnvironment appEnvironment, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RateCheapPlaceResponse> ExecuteAsync(Guid cheapPlaceId, CreateRateCheapPlaceRequest request)
        {
            RateCheapPlace rateCheapPlace = null;
            User user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var currentCheapPlace = await _context.CheapPlaces.Include("RateCheapPlaces").FirstOrDefaultAsync(u => u.Id == cheapPlaceId);
            if (currentCheapPlace != null)
            {
                var currentUser = await _userManager.Users.Include("RateCheapPlaces").FirstOrDefaultAsync(
                    u => u.Id == user.Id);
                if (_context.RateCheapPlaces.AnyAsync(
                        u => u.CheapPlaceId == currentCheapPlace.Id &&
                             u.UserWhoGiveMarkId == currentUser.Id).Result == false)
                {
                    rateCheapPlace = _mapper.Map<CreateRateCheapPlaceRequest, RateCheapPlace>(request);
                    rateCheapPlace.UserWhoGiveMark = currentUser;
                    currentUser.RateCheapPlaces.Add(rateCheapPlace);
                    rateCheapPlace.CheapPlace = currentCheapPlace;
                    currentCheapPlace.RateCheapPlaces.Add(rateCheapPlace);
                    await _context.RateCheapPlaces.AddAsync(rateCheapPlace);
                    await _context.SaveChangesAsync();
                }
            }
            return _mapper.Map<RateCheapPlace, RateCheapPlaceResponse>(rateCheapPlace);
        }
    }
}
