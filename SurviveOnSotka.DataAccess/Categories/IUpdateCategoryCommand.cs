using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.Categories
{
    public interface IUpdateCategoryCommand
    {
        Task<CategoryResponse> ExecuteAsync(Guid categoryId, UpdateCategoryRequest request);

    }
}
