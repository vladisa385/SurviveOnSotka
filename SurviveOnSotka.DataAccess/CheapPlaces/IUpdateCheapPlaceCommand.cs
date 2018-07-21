using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Categories;
using SurviveOnSotka.ViewModel.CheapPlaces;

namespace SurviveOnSotka.DataAccess.CheapPlaces
{
    public interface IUpdateCheapPlaceCommand
    {
        Task<CheapPlaceResponse> ExecuteAsync(Guid cheapPlaceId, UpdateCheapPlaceRequest request);

    }
}
