using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Categories
{
    public interface IDeleteCategoryCommand
    {
        Task ExecuteAsync(Guid categoryId);
    }
}
