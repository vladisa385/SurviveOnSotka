using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.Categories
{
    public interface ICategoryQuery
    {

        Task<CategoryResponse> RunAsync(Guid categoryId);
    }
}
