using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    [ProducesResponseType(401)]
    // [Authorize]
    public class IngredientsController : Controller
    {
        [HttpGet("GetList")]
        //  [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(ListResponse<IngredientResponse>))]
        [ProducesResponseType(500, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetIngredientsListAsync(IngredientFilter ingredient, ListOptions options, [FromServices] IIngredientsListQuery query)
        {
            var response = await query.RunAsync(ingredient, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(403)]
        [ModelValidation]
        [ProducesResponseType(201, Type = typeof(IngredientResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateIngredientAsync([FromBody] CreateIngredientRequest ingredient, [FromServices] ICreateIngredientCommand command)
        {
            var response = await command.ExecuteAsync(ingredient);
            return CreatedAtRoute("GetSingleIngredient", new {ingredientId = response.Id}, response);
        }

        [HttpGet("Get/{ingredientId}", Name = "GetSingleIngredient")]
        //[Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(IngredientResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetIngredientAsync(Guid ingredientId, [FromServices] IIngredientQuery query)
        {
            var response = await query.RunAsync(ingredientId);
            return response == null ? (IActionResult) NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        //[Authorize(Roles = "admin")]
        [ModelValidation]
        [ProducesResponseType(200, Type = typeof(IngredientResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateIngredientAsync([FromBody] UpdateIngredientRequest request, [FromServices] IUpdateIngredientCommand command)
        {
            var response = await command.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpDelete("Delete/{ingredientId}")]
        [ProducesResponseType(204)]
        // [Authorize(Roles = "admin")]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> DeleteIngredientAsync(Guid ingredientId,[FromServices] IDeleteIngredientCommand command)
        {
            await command.ExecuteAsync(ingredientId);
            return NoContent();
        }
    }
}