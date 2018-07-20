using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class CreateTypeFoodCommand : ICreateTypeFoodCommand
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        public CreateTypeFoodCommand(AppDbContext dbContext, IMapper mapper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }
        public async Task<TypeFoodResponse> ExecuteAsync(CreateTypeFoodRequest request)
        {
            var typeFood = _mapper.Map<CreateTypeFoodRequest, TypeFood>(request);
            await _context.TypeFoods.AddAsync(typeFood);
            if (request.Icon != null)
            {
                typeFood.PathToIcon = _appEnvironment.WebRootPath + "/Files/TypeFoods/" + request.Icon.FileName;
                await CreateFileCommand.ExecuteAsync(request.Icon, _appEnvironment.WebRootPath + typeFood.PathToIcon);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<TypeFood, TypeFoodResponse>(typeFood);
        }


    }
}
