using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;
using SurviveOnSotka.ViewModell;
using System;
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
    public class TypeFoodsController : Controller
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ListResponse<TypeFoodResponse>>> GetTypeFoodsListAsync([FromQuery]TypeFoodFilter typeFood, [FromQuery]ListOptions options, [FromServices]ListQuery<TypeFoodResponse, TypeFoodFilter> query) =>
            await query.RunAsync(typeFood, options);

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<TypeFoodResponse>> CreateTypeFoodAsync(CreateTypeFoodRequest typeFood, [FromServices]Command<CreateTypeFoodRequest, TypeFoodResponse> command)
        {
            var response = await command.ExecuteAsync(typeFood);
            return CreatedAtRoute("GetSingleTypeFood", new { typeFoodId = response.Id }, response);
        }

        [HttpGet("Get/{typeFoodId}", Name = "GetSingleTypeFood")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TypeFoodResponse>> GetTypeFoodAsync(Guid typeFoodId, [FromServices] Query<TypeFoodResponse> query) =>
            await query.RunAsync(typeFoodId) ?? (ActionResult<TypeFoodResponse>)NotFound();

        [HttpPut("Update/")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TypeFoodResponse>> UpdateTypeFoodAsync(UpdateTypeFoodRequest request, [FromServices] Command<UpdateTypeFoodRequest, TypeFoodResponse> command) =>
            await command.ExecuteAsync(request);

        [HttpDelete("Delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTypeFoodAsync(SimpleDeleteRequest request, [FromServices]Command<SimpleDeleteRequest, EmptyResponse<TypeFoodResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}