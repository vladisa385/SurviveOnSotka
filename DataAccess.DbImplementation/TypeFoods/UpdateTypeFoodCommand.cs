using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
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
        private readonly IHostingEnvironment _appEnvironment;

        public UpdateTypeFoodCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<TypeFoodResponse> ExecuteAsync(Guid typefoodId, UpdateTypeFoodRequest request)
        {
            TypeFood foundTypeFood = await _context.TypeFoods.FirstOrDefaultAsync(t => t.Id == typefoodId);
            if (foundTypeFood != null)
            {
                TypeFood mappedTypeFood = _mapper.Map<UpdateTypeFoodRequest, TypeFood>(request);
                mappedTypeFood.Id = typefoodId;
                _context.Entry(foundTypeFood).CurrentValues.SetValues(mappedTypeFood);
                if (request.Icon != null)
                {
                    mappedTypeFood.PathToIcon = _appEnvironment.WebRootPath + "/Files/TypeFoods/" + request.Icon.FileName;
                    await CreateFileCommand.ExecuteAsync(request.Icon, _appEnvironment.WebRootPath + mappedTypeFood.PathToIcon);
                }
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<TypeFood, TypeFoodResponse>(foundTypeFood);
        }
    }
}
