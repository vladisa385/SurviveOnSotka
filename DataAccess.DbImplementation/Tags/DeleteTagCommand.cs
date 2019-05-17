using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Tags;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using Task = System.Threading.Tasks.Task;

namespace SurviveOnSotka.DataAccess.DbImplementation.Tags
{
    public class DeleteTagCommand : IDeleteTagCommand
    {
        private readonly AppDbContext _context;

        public DeleteTagCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
        }
        public async Task ExecuteAsync(string tag)
        {
            var tagToDelete = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tag);
            if (tagToDelete != null)
            {
                _context.Tags.Remove(tagToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
