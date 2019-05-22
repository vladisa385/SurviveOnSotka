using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.CrudOperation
{
    public abstract class Query<TResponse>
    where TResponse : Response
    {
        public async Task<TResponse> RunAsync(Guid id)
        {
            try
            {
                return await QueryItem(id);
            }
            catch (Exception e)
            {
                HandleError(e);
            }

            return default;
        }

        protected virtual void HandleError(Exception ex)
        {
            throw ex;
        }
        protected abstract Task<TResponse> QueryItem(Guid id);
    }
}
