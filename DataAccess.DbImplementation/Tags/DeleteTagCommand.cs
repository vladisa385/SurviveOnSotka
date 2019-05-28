using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Tags;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.Tags
{
    public class DeleteTagCommand : Command<SimpleDeleteRequest, EmptyResponse<TagResponse>>
    {
        private readonly AppDbContext _context;

        public DeleteTagCommand(AppDbContext context) => _context = context;

        protected override async Task<EmptyResponse<TagResponse>> Execute(SimpleDeleteRequest request)
        {
            var tagToDelete = await _context.Tags.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (tagToDelete != null)
            {
                _context.Tags.Remove(tagToDelete);
                await _context.SaveChangesAsync();
            }
            return new EmptyResponse<TagResponse>();
        }
    }
}