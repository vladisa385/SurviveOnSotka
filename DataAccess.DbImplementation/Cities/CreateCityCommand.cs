using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SurviveOnSotka.DataAccess.Cities;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Cities;

namespace SurviveOnSotka.DataAccess.DbImplementation.Cities
{
    public class CreateCityCommand : ICreateCityCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        public CreateCityCommand(AppDbContext dbContext, IMapper mapper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }
        public async Task<CityResponse> ExecuteAsync(CreateCityRequest request)
        {
            var city = _mapper.Map<CreateCityRequest, City>(request);
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return _mapper.Map<City, CityResponse>(city);
        }


    }
}

