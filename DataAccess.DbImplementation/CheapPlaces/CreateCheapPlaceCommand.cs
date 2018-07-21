using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.CheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.CheapPlaces
{
    public class CreateCheapPlaceCommand : ICreateCheapPlaceCommand
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        public CreateCheapPlaceCommand(AppDbContext dbContext, IMapper mapper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }
        public async Task<CheapPlaceResponse> ExecuteAsync(CreateCheapPlaceRequest request)
        {
            if (!_context.Cities.Any(u => u.Id == request.CityId))
            {
                throw new CannotCreateOrUpdateCheapPlaceWithCurrentGuidCity();
            }
            var cheapPlace = _mapper.Map<CreateCheapPlaceRequest, CheapPlace>(request);
            await _context.CheapPlaces.AddAsync(cheapPlace);
            if (request.Photos != null)
            {
                cheapPlace.PathToPhotos = _appEnvironment.WebRootPath + "/Files/CheapPlaces/" + request.Name;
                foreach (var photo in request.Photos)
                {

                    await CreateFileCommand.ExecuteAsync(photo, _appEnvironment.WebRootPath + cheapPlace.PathToPhotos);
                }
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<CheapPlace, CheapPlaceResponse>(cheapPlace);
        }


    }
}
