using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DB;
using SurviveOnSotka.Entities;
using TasksManager.DataAccess.Tags;
using Task = System.Threading.Tasks.Task;

namespace SurviveOnSotka.DataAccessDBImplementation.Tags
{
    public class DeleteTagCommand : IDeleteTagCommand
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;
        public DeleteTagCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task ExecuteAsync(string tag)
        {
            Tag tagToDelete = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tag);
            if (tagToDelete != null)
            {
                //we're getting "Remove tag from tasks where it's used" for free, since .OnDelete(DeleteBehavior.Cascade)
                //is used in CodeFirst model configuration
                _context.Tags.Remove(tagToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
