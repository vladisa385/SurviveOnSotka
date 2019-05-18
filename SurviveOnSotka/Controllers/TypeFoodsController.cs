using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.Filters;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.Controllers
{
    [ProducesResponseType(401)]
    [Route("api/[controller]")]
    public class TypeFoodsController : Controller
    {

        [HttpGet("GetList")]
        // [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<TypeFoodResponse>))]
        public async Task<IActionResult> GetTypeFoodsListAsync(TypeFoodFilter typeFood, ListOptions options, [FromServices]ITypeFoodsListQuery query)
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
        public async Task<IActionResult> CreateTypeFoodAsync([FromBody] CreateTypeFoodRequest typeFood, [FromServices]ICreateTypeFoodCommand command)
        {
            var response = await command.ExecuteAsync(typeFood);
            return CreatedAtRoute("GetSingleTypeFood", new { typeFoodId = response.Id }, response);
        }

        [HttpGet("Get/{typeFoodId}", Name = "GetSingleTypeFood")]
        // [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(TypeFoodResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTypeFoodAsync(Guid typeFoodId, [FromServices] ITypeFoodQuery query)
        {
            var response = await query.RunAsync(typeFoodId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{typeFoodId}")]
        //[Authorize(Roles = "admin")]
        [ModelValidation]
        [ProducesResponseType(200, Type = typeof(TypeFoodResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdatetypeFoodAsync(Guid typeFoodId, [FromBody] UpdateTypeFoodRequest request, [FromServices] IUpdateTypeFoodCommand command)
        {
            var response = await command.ExecuteAsync(typeFoodId, request);
            return Ok(response);
        }

        [HttpDelete("Delete/{typeFoodId}")]
        [ProducesResponseType(204)]
        //  [Authorize(Roles = "admin")]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTypeFoodAsync(Guid typeFoodId, [FromServices]IDeleteTypeFoodCommand command)
        {
            await command.ExecuteAsync(typeFoodId);
            return NoContent();
        }
    }
}
