using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.Files;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.Files
{
    public class DeleteFileCommand : IDeleteFileCommand
    {
        private readonly AppDbContext _context;
        public DeleteFileCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid fileId)
        {
            FileModel fileModelToDelete = await _context.FileModels.
                FirstOrDefaultAsync(u => u.Id == fileId);
            _context.FileModels.Remove(fileModelToDelete);
            await _context.SaveChangesAsync();

        }
    }
}
