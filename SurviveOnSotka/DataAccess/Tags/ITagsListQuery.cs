using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Tags;

namespace TasksManager.DataAccess.Tags
{
    public interface ITagsListQuery
    {
        Task<ListResponse<TagResponse>> RunAsync(TagFilter filter, ListOptions options);
    }
}
