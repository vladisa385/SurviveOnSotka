using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Levels;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Levels;

namespace SurviveOnSotka.DataAccess.DbImplementation.Levels
{
    public class LevelQuery : ILevelQuery
    {
        private readonly AppDbContext _context;
        public LevelQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<LevelResponse> RunAsync(Guid levelId)
        {
            LevelResponse response = await _context.Levels
                .ProjectTo<LevelResponse>()
                .FirstOrDefaultAsync(p => p.Id == levelId);
            return response;
        }
    }
}
