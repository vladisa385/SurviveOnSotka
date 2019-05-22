using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModell;


namespace SurviveOnSotka.DataAccess.CrudOperation
{
    public abstract class ListQuery<TResponse,TFilter>
    where TResponse : Response
    where TFilter : Filter
    {
        public async Task<ListResponse<TResponse>> RunAsync(TFilter filter, ListOptions options)
        {
            try
            {
                return await QueryListItem(filter,options);
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
        protected abstract Task<ListResponse<TResponse>> QueryListItem(TFilter filter, ListOptions options);
    }
}
