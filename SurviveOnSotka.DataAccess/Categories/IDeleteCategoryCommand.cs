using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Categories
{
    public interface IDeleteCategoryCommand
    {
        Task ExecuteAsync(Guid categoryId);
    }
}
