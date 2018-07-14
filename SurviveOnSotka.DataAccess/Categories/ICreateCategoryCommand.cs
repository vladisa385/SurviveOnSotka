using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.Categories
{
    public interface ICreateCategoryCommand
    {
        Task<CategoryResponse> ExecuteAsync(CreateCategoryRequest request);
    }
}
