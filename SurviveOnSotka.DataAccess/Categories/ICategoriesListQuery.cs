using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.ViewModels;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.Categories
{
    public interface ICategoriesListQuery
    {
        Task<ListResponse<CategoryResponse>> RunAsync(CategoryFilter filter, ListOptions options);
    }
}
