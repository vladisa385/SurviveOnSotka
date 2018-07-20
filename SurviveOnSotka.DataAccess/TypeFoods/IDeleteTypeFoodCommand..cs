using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public interface IDeleteTypeFoodCommand
    {
        Task ExecuteAsync(Guid typeFoodId);
    }
}
