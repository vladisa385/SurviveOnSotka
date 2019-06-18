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
    [Authorize]
    [ApiController]
    [ProducesResponseType(401)]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class RecipesController : Controller
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ListResponse<RecipeResponse>>> GetRecipesListAsync([FromQuery]RecipeFilter recipe, [FromQuery] ListOptions options, [FromServices] ListQuery<RecipeResponse, RecipeFilter> query) =>
            await query.RunAsync(recipe, options);

        [HttpPost("Create")]
        [ServiceFilter(typeof(InjectUserId))]
        [RequestSizeLimit(1000_000_000_000)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<RecipeResponse>> CreateRecipeAsync(CreateRecipeRequest request, [FromServices] Command<CreateRecipeRequest, RecipeResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleRecipe", new { recipeId = response.Id }, response);
        }

        [HttpGet("Get/{recipeId}", Name = "GetSingleRecipe")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<RecipeResponse>> GetRecipeAsync(Guid recipeId, [FromServices] Query<RecipeResponse> query) =>
            await query.RunAsync(recipeId) ?? (ActionResult<RecipeResponse>)NotFound();

        [HttpPut("Update")]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<RecipeResponse>> UpdateRecipeAsync(UpdateRecipeRequest request, [FromServices] Command<UpdateRecipeRequest, RecipeResponse> command) =>
            await command.ExecuteAsync(request);

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRecipeAsync(SimpleDeleteRequest request, [FromServices] Command<SimpleDeleteRequest, EmptyResponse<RecipeResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}