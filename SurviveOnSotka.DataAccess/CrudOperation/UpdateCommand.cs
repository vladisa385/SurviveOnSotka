using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.CrudOperation
{
    public abstract class UpdateCommand<TRequest, TResponse> 
        where TResponse : Response
        where TRequest : UpdateRequest
    {
    public async Task<TResponse> ExecuteAsync(TRequest request)
    {
        try
        {
            return await UpdateItem(request);
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

    protected abstract Task<TResponse> UpdateItem(TRequest request);

    }
}
