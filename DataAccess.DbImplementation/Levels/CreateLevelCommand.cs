using System.Linq;
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
    public class CreateLevelCommand : ICreateLevelCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        public CreateLevelCommand(AppDbContext dbContext, IMapper mapper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }
        public async Task<LevelResponse> ExecuteAsync(CreateLevelRequest request)
        {
            if (request.NextLevelId != null)
            {
                if (!_context.Levels.AnyAsync(u => u.NextLevelId == request.NextLevelId).Result)
                {
                    throw new CannotCreateOrUpdateLevelWithThisGuidNextLevelException();
                }
            }
            if (request.LastLevelId != null)
            {
                if (!_context.Levels.AnyAsync(u => u.LastLevelId == request.LastLevelId).Result)
                {
                    throw new CannotCreateOrUpdateLevelWithThisGuidLastLevelException();
                }
            }
            var level = _mapper.Map<CreateLevelRequest, Entities.Level>(request);
            await _context.Levels.AddAsync(level);
            if (request.Icon != null)
            {
                string basedir = _appEnvironment.WebRootPath + "/Files/Levels/";
                level.PathToIcon = basedir + request.Icon.FileName;
                await CreateFileCommand.ExecuteAsync(request.Icon, basedir);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.Level, LevelResponse>(level);
        }

    }
}
