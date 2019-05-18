using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class UpdateTypeFoodCommand : IUpdateTypeFoodCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTypeFoodCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<TypeFoodResponse> ExecuteAsync(Guid typeFoodId, UpdateTypeFoodRequest request)
        {
            var foundTypeFood = await _context.TypeFoods.FirstOrDefaultAsync(t => t.Id == typeFoodId);
            if (foundTypeFood == null)
                throw new UpdateItemException($"typeFood with id: {typeFoodId} not found");
            var mappedTypeFood = _mapper.Map<UpdateTypeFoodRequest, TypeFood>(request);
            mappedTypeFood.Id = typeFoodId;
            _context.Entry(foundTypeFood).CurrentValues.SetValues(mappedTypeFood);
            await _context.SaveChangesAsync();
            return _mapper.Map<TypeFood, TypeFoodResponse>(foundTypeFood);
        }
    }
}
