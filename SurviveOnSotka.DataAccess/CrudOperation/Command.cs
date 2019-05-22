using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModell;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.DataAccess.CrudOperation
{
    public abstract class Command<TRequest, TResponse>
        where TResponse : Response
        where TRequest : Request
        {
            public async Task<TResponse> ExecuteAsync(TRequest request)
            {
                try
                {
                    return await Execute(request);
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
            protected abstract Task<TResponse> Execute(TRequest request);
        }
    }
