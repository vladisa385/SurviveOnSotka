using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Levels;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Levels;

namespace SurviveOnSotka.DataAccess.DbImplementation.Levels
{
    public class UpdateLevelCommand : IUpdateLevelCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public UpdateLevelCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<LevelResponse> ExecuteAsync(Guid levelId, UpdateLevelRequest request)
        {
            Entities.Level foundLevel = await _context.Levels.FirstOrDefaultAsync(t => t.Id == levelId);
            if (foundLevel != null)
            {
                Entities.Level mappedLevel = _mapper.Map<UpdateLevelRequest, Entities.Level>(request);
                mappedLevel.Id = levelId;
                _context.Entry(foundLevel).CurrentValues.SetValues(mappedLevel);
                if (request.Icon != null)
                {
                    string basedir = _appEnvironment.WebRootPath + "/Files/Levels/";
                    mappedLevel.PathToIcon = basedir + request.Icon.FileName;
                    await CreateFileCommand.ExecuteAsync(request.Icon, basedir);
                }
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Entities.Level, LevelResponse>(foundLevel);
        }
    }
}

