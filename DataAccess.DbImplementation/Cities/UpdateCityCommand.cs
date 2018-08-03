using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Cities;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Cities;

namespace SurviveOnSotka.DataAccess.DbImplementation.Cities
{
    public class UpdateCityCommand : IUpdateCityCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public UpdateCityCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<CityResponse> ExecuteAsync(Guid typefoodId, UpdateCityRequest request)
        {
            City foundCity = await _context.Cities.FirstOrDefaultAsync(t => t.Id == typefoodId);
            if (foundCity != null)
            {
                City mappedCity = _mapper.Map<UpdateCityRequest, City>(request);
                mappedCity.Id = typefoodId;
                _context.Entry(foundCity).CurrentValues.SetValues(mappedCity);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<City, CityResponse>(foundCity);
        }
    }
}

