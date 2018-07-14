using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Tags;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Tags;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ListResponse<TagResponse>))]
        public async Task<IActionResult> GetTagsListAsync(TagFilter filter, ListOptions options, [FromServices]ITagsListQuery query)
        {
            ListResponse<TagResponse> response = await query.RunAsync(filter, options);
            return Ok(response);
        }

        [HttpDelete("{tag}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTagAsync(string tag, [FromServices]IDeleteTagCommand command)
        {
            await command.ExecuteAsync(tag);
            return NoContent();
        }
    }
}