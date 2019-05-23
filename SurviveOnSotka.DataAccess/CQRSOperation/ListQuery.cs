using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.ViewModell;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.CQRSOperation
{
    public abstract class ListQuery<TResponse, TFilter>
    where TResponse : Response
    where TFilter : Filter
    {
        public async Task<ListResponse<TResponse>> RunAsync(TFilter filter, ListOptions options)
        {
            try
            {
                return await QueryListItem(filter, options);
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

        protected virtual async Task<ListResponse<TResponse>> QueryListItem(TFilter filter, ListOptions options)
        {
            var query = GetQuery();
            query = ApplyFilter(query, filter);
            if (options.Sort == null)
                options.Sort = "Id";
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            var totalCount = await query.CountAsync();
            var items = await query.ToListAsync();
            return new ListResponse<TResponse>
            {
                Items = items,
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                Sort = options.Sort ?? "-Id",
                TotalItemsCount = totalCount
            };
        }

        protected abstract IQueryable<TResponse> ApplyFilter(IQueryable<TResponse> query, TFilter filter);

        protected abstract IQueryable<TResponse> GetQuery();
    }
}