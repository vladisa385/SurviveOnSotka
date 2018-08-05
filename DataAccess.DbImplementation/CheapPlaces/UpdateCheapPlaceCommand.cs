using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.CheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.CheapPlaces
{
    public class UpdateCheapPlaceCommand : IUpdateCheapPlaceCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateCheapPlaceCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<CheapPlaceResponse> ExecuteAsync(Guid cheapPlaceId, UpdateCheapPlaceRequest request)
        {

            if (request.CityId != null && !_context.Cities.Any(u => u.Id == request.CityId))
            {
                throw new CannotCreateOrUpdateCheapPlaceWithCurrentGuidCity();
            }
            CheapPlace foundCheapPlace = await _context.CheapPlaces.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == cheapPlaceId);


            if (foundCheapPlace != null)
            {
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var isAdmin = await _userManager.IsInRoleAsync(currentUser, "admin");
                if (foundCheapPlace.User != currentUser && !isAdmin)
                    throw new ThisRequestNotFromOwnerException();
                CheapPlace mappedCheapPlace = _mapper.Map<UpdateCheapPlaceRequest, CheapPlace>(request);
                mappedCheapPlace.Id = cheapPlaceId;
                _context.Entry(foundCheapPlace).CurrentValues.SetValues(mappedCheapPlace);
                if (request.Photos != null)
                {
                    foreach (var photo in request.Photos)
                    {

                        await CreateFileCommand.ExecuteAsync(photo, foundCheapPlace.PathToPhotos);
                    }
                }
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<CheapPlace, CheapPlaceResponse>(foundCheapPlace);
        }
    }
}
