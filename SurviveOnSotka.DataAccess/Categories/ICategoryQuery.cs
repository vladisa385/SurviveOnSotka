using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.Categories
{
    public interface ICategoryQuery
    {

        Task<CategoryResponse> RunAsync(Guid categoryId);
    }
}
