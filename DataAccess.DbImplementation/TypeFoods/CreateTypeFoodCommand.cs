﻿using AutoMapper;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class CreateTypeFoodCommand : Command<CreateTypeFoodRequest, TypeFoodResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateTypeFoodCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        protected override async Task<TypeFoodResponse> Execute(CreateTypeFoodRequest request)
        {
            var typeFood = _mapper.Map<CreateTypeFoodRequest, TypeFood>(request);
            await _context.TypeFoods.AddAsync(typeFood);
            await _context.SaveChangesAsync();
            return _mapper.Map<TypeFood, TypeFoodResponse>(typeFood);
        }
    }
}