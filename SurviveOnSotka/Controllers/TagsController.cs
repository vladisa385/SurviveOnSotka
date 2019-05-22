using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion.Tags;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(401)]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class TagsController : Controller
    {
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<TagResponse>))]
        public async Task<IActionResult> GetTagsListAsync(TagFilter filter, ListOptions options, [FromServices]ListQuery<TagResponse,TagFilter> query)
        {
            var response = await query.RunAsync(filter, options);
            return Ok(response);
        }

        [HttpDelete("{tag}")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> DeleteTagAsync(Guid id, [FromServices]DeleteCommand<TagResponse> command)
        {
            await command.ExecuteAsync(id);
            return NoContent();
        }
    }
}