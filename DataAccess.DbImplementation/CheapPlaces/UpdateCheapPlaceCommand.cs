using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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

        public UpdateCheapPlaceCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<CheapPlaceResponse> ExecuteAsync(Guid cheapPlaceId, UpdateCheapPlaceRequest request)
        {
            if (!_context.Cities.Any(u => u.Id == request.CityId))
            {
                throw new CannotCreateOrUpdateCheapPlaceWithCurrentGuidCity();
            }
            CheapPlace foundCheapPlace = await _context.CheapPlaces.FirstOrDefaultAsync(t => t.Id == cheapPlaceId);
            if (foundCheapPlace != null)
            {
                CheapPlace mappedCheapPlace = _mapper.Map<UpdateCheapPlaceRequest, CheapPlace>(request);
                mappedCheapPlace.Id = cheapPlaceId;
                _context.Entry(foundCheapPlace).CurrentValues.SetValues(mappedCheapPlace);
                if (request.Photos != null)
                {
                    foundCheapPlace.PathToPhotos = _appEnvironment.WebRootPath + "/Files/CheapPlaces/" + request.Name;
                    foreach (var photo in request.Photos)
                    {

                        await CreateFileCommand.ExecuteAsync(photo, _appEnvironment.WebRootPath + foundCheapPlace.PathToPhotos);
                    }
                }
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<CheapPlace, CheapPlaceResponse>(foundCheapPlace);
        }
    }
}
