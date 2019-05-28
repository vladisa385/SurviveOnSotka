using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;
using SurviveOnSotka.ViewModell;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class RecipesController : Controller
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(ListResponse<RecipeResponse>))]
        public async Task<IActionResult> GetRecipesListAsync(RecipeFilter recipe, ListOptions options, [FromServices] ListQuery<RecipeResponse, RecipeFilter> query)
        {
            var response = await query.RunAsync(recipe, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize]
        [ProducesResponseType(401)]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(201, Type = typeof(RecipeResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRecipeAsync([FromBody] CreateRecipeRequest request, [FromServices] Command<CreateRecipeRequest, RecipeResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleRecipe", new { recipeId = response.Id }, response);
        }

        [HttpGet("Get/{recipeId}", Name = "GetSingleRecipe")]
        [ProducesResponseType(200, Type = typeof(RecipeResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRecipeAsync(Guid recipeId, [FromServices] Query<RecipeResponse> query)
        {
            var response = await query.RunAsync(recipeId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        [Authorize]
        [ProducesResponseType(401)]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(200, Type = typeof(RecipeResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRecipeAsync([FromBody] UpdateRecipeRequest request, [FromServices] Command<UpdateRecipeRequest, RecipeResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        [Authorize]
        [ProducesResponseType(401)]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> DeleteRecipeAsync(SimpleDeleteRequest request, [FromServices] Command<SimpleDeleteRequest, EmptyResponse<RecipeResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}