using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface IDeleteReviewCommand
    {
        Task ExecuteAsync(Guid reviewId);
    }
}
