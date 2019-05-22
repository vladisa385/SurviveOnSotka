using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.CrudOperation
{
    public abstract class CreateCommand<TRequest,TResponse>
        where TResponse : Response
        where TRequest : CreateRequest
    {
        public async Task<TResponse> ExecuteAsync(TRequest request)
        {
            try
            {
                return await CreateItem(request);
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
        protected abstract Task<TResponse> CreateItem(TRequest request);
    }
}
