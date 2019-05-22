using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Tags;

namespace SurviveOnSotka.DataAccess.DbImplementation.Tags
{
    public class DeleteTagCommand : Command<SimpleDeleteRequest,TagResponse>
    {
        private readonly AppDbContext _context;

        public DeleteTagCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
        }
        protected override async Task<TagResponse> Execute(SimpleDeleteRequest request)
        {
            var tagToDelete = await _context.Tags.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (tagToDelete != null)
            {
                _context.Tags.Remove(tagToDelete);
                await _context.SaveChangesAsync();
            }
            return null;
        }
    }
}
