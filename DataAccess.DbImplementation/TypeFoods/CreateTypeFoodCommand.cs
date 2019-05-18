using System.Threading.Tasks;
using AutoMapper;
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
        public CreateTypeFoodCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<TypeFoodResponse> ExecuteAsync(CreateTypeFoodRequest request)
        {
            var typeFood = _mapper.Map<CreateTypeFoodRequest, TypeFood>(request);
            await _context.TypeFoods.AddAsync(typeFood);
            await _context.SaveChangesAsync();
            return _mapper.Map<TypeFood, TypeFoodResponse>(typeFood);
        }
    }
}
