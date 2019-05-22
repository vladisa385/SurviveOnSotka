using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Tags;
using Task = System.Threading.Tasks.Task;

namespace SurviveOnSotka.DataAccess.DbImplementation.Tags
{
    public class DeleteTagCommand : DeleteCommand<TagResponse>
    {
        private readonly AppDbContext _context;

        public DeleteTagCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
        }
        protected override async Task DeleteItem(Guid id)
        {
            var tagToDelete = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if (tagToDelete != null)
            {
                _context.Tags.Remove(tagToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
