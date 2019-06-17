using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using SurviveOnSotka.ViewModell;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ProducesResponseType(401)]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class IngredientsController : Controller
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ListResponse<IngredientResponse>>> GetIngredientsListAsync(IngredientFilter ingredient, ListOptions options, [FromServices] ListQuery<IngredientResponse, IngredientFilter> query) =>
            await query.RunAsync(ingredient, options);

        [HttpPost("Create")]
        [ModelValidation]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IngredientResponse>> CreateIngredientAsync([FromBody] CreateIngredientRequest ingredient, [FromServices] Command<CreateIngredientRequest, IngredientResponse> command)
        {
            var response = await command.ExecuteAsync(ingredient);
            return CreatedAtRoute("GetSingleIngredient", new { ingredientId = response.Id }, response);
        }

        [HttpGet("Get/{ingredientId}", Name = "GetSingleIngredient")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IngredientResponse>> GetIngredientAsync(Guid ingredientId, [FromServices] Query<IngredientResponse> query) =>
            await query.RunAsync(ingredientId) ?? (ActionResult<IngredientResponse>)NotFound();

        [HttpPut("Update")]
        [ModelValidation]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IngredientResponse>> UpdateIngredientAsync([FromBody] UpdateIngredientRequest request, [FromServices] Command<UpdateIngredientRequest, IngredientResponse> command) =>
            await command.ExecuteAsync(request);

        [HttpDelete("Delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteIngredientAsync(SimpleDeleteRequest request, [FromServices] Command<SimpleDeleteRequest, EmptyResponse<IngredientResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}