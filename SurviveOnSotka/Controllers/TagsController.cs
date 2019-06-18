using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Tags;
using SurviveOnSotka.ViewModell;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    [ProducesResponseType(401)]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class TagsController : Controller
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ListResponse<TagResponse>>> GetTagsListAsync([FromQuery]TagFilter filter, [FromQuery] ListOptions options, [FromServices]ListQuery<TagResponse, TagFilter> query) =>
            await query.RunAsync(filter, options);

        [HttpDelete("Delete")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTagAsync(SimpleDeleteRequest request, [FromServices]Command<SimpleDeleteRequest, EmptyResponse<TagResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}