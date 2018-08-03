using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public interface IDeleteTypeFoodCommand
    {
        Task ExecuteAsync(Guid typeFoodId);
    }
}
