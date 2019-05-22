using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.DataAccess.ViewModels;
using SurviveOnSotka.Entities;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.Controllers
{
    //[Authorize]
    [ProducesResponseType(401)]
    [Route("api/[controller]")]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class RecipesController : BaseController
    {
        public RecipesController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(httpContextAccessor, userManager)
        {
        }
        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(ListResponse<RecipeResponse>))]
        public async Task<IActionResult> GetRecipesListAsync(RecipeFilter recipe, ListOptions options,
            [FromServices] IRecipiesListQuery query)
        {
            var response = await query.RunAsync(recipe, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [ModelValidation]
        [ProducesResponseType(201, Type = typeof(RecipeResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRecipeAsync([FromBody] CreateRecipeRequest recipe, [FromServices] ICreateRecipeCommand command)
        {
            var currentUser = await GetCurrentUserAsync();
            var response = await command.ExecuteAsync(currentUser.Id,recipe);
            return CreatedAtRoute("GetSingleRecipe", new {recipeId = response.Id}, response);
        }

        [HttpGet("Get/{recipeId}", Name = "GetSingleRecipe")]
        [ProducesResponseType(200, Type = typeof(RecipeResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRecipeAsync(Guid recipeId, [FromServices] IRecipeQuery query)
        {
            var response = await query.RunAsync(recipeId);
            return response == null ? (IActionResult) NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        [ModelValidation]
        [ProducesResponseType(200, Type = typeof(RecipeResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRecipeAsync( [FromBody] UpdateRecipeRequest request,[FromServices] IUpdateRecipeCommand command)
        {
            var response = await command.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpDelete("Delete/{recipeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> DeleteRecipeAsync(Guid recipeId, [FromServices] IDeleteRecipeCommand command)
        {
            await command.ExecuteAsync(recipeId);
            return NoContent();
        }
    }
}