using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.CrudOperation
{
    public abstract class DeleteCommand<T>
    {
        public async Task ExecuteAsync(Guid id)
        {
            try
            {
                await DeleteItem(id);
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        protected virtual void HandleError(Exception ex)
        {
            throw ex;
        }
        protected abstract Task DeleteItem(Guid id);
    }
}
