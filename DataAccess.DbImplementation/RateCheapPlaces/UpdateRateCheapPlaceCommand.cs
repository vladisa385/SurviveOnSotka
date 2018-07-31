using System;
using System.Collections.Generic;
using System.Text;
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
    public class UpdateRateCheapPlaceCommand : IUpdateRateCheapPlaceCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateRateCheapPlaceCommand(AppDbContext context, IMapper mapper, IHostingEnvironment appEnvironment, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RateCheapPlaceResponse> ExecuteAsync(Guid cheapPlaceId, UpdateRateCheapPlaceRequest request)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            RateCheapPlace rateCheapPlace = await _context.RateCheapPlaces.FirstOrDefaultAsync(
                u => u.CheapPlaceId == cheapPlaceId &&
                     u.UserWhoGiveMarkId == currentUser.Id);
            if (rateCheapPlace != null)
            {
                rateCheapPlace.IsCool = request.IsCool;
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<RateCheapPlace, RateCheapPlaceResponse>(rateCheapPlace);
        }
    }
}
