using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.Controllers
{
    [ProducesResponseType(401)]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    [Route("api/[controller]")]
    public class TypeFoodsController : Controller
    {

        [HttpGet("GetList")]
        [ServiceFilter(typeof(InjectUserId))]
        // [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<TypeFoodResponse>))]
        public async Task<IActionResult> GetTypeFoodsListAsync(TypeFoodFilter typeFood, ListOptions options, [FromServices]ListQuery<TypeFoodResponse,TypeFoodFilter> query)
        {
            var response = await query.RunAsync(typeFood, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        // [Authorize(Roles = "admin")]
        [ModelValidation]
        [ProducesResponseType(201, Type = typeof(TypeFoodResponse))]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTypeFoodAsync([FromBody] CreateTypeFoodRequest typeFood, [FromServices]Command<CreateTypeFoodRequest,TypeFoodResponse> command)
        {
            var response = await command.ExecuteAsync(typeFood);
            return CreatedAtRoute("GetSingleTypeFood", new { typeFoodId = response.Id }, response);
        }

        [HttpGet("Get/{typeFoodId}", Name = "GetSingleTypeFood")]
        // [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(TypeFoodResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTypeFoodAsync(Guid typeFoodId, [FromServices] Query<TypeFoodResponse> query)
        {
            var response = await query.RunAsync(typeFoodId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/")]
        //[Authorize(Roles = "admin")]
        [ModelValidation]
        [ProducesResponseType(200, Type = typeof(TypeFoodResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTypeFoodAsync([FromBody] UpdateTypeFoodRequest request, [FromServices] Command<UpdateTypeFoodRequest,TypeFoodResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(204)]
        //  [Authorize(Roles = "admin")]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTypeFoodAsync(SimpleDeleteRequest request, [FromServices]Command<SimpleDeleteRequest,TypeFoodResponse> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}
