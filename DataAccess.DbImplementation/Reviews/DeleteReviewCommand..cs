using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class DeleteReviewCommand:IDeleteReviewCommand
    {
        public Task ExecuteAsync(Guid reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
