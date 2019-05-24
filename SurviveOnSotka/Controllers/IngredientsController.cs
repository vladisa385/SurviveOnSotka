using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using SurviveOnSotka.ViewModell;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    [ProducesResponseType(401)]
    public class IngredientsController : Controller
    {
        [HttpGet("GetList")]
        //  [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(ListResponse<IngredientResponse>))]
        [ProducesResponseType(500, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetIngredientsListAsync(IngredientFilter ingredient, ListOptions options, [FromServices] ListQuery<IngredientResponse, IngredientFilter> query)
        {
            var response = await query.RunAsync(ingredient, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ModelValidation]
        [ProducesResponseType(201, Type = typeof(IngredientResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateIngredientAsync([FromBody] CreateIngredientRequest ingredient, [FromServices] Command<CreateIngredientRequest, IngredientResponse> command)
        {
            var response = await command.ExecuteAsync(ingredient);
            return CreatedAtRoute("GetSingleIngredient", new { ingredientId = response.Id }, response);
        }

        [HttpGet("Get/{ingredientId}", Name = "GetSingleIngredient")]
        //[Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(IngredientResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetIngredientAsync(Guid ingredientId, [FromServices] Query<IngredientResponse> query)
        {
            var response = await query.RunAsync(ingredientId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        [Authorize]
        [ProducesResponseType(401)]
        [ModelValidation]
        [ProducesResponseType(200, Type = typeof(IngredientResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateIngredientAsync([FromBody] UpdateIngredientRequest request, [FromServices] Command<UpdateIngredientRequest, IngredientResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(204)]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> DeleteIngredientAsync(SimpleDeleteRequest request, [FromServices] Command<SimpleDeleteRequest, IngredientResponse> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}