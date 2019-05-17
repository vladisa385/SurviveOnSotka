using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.Controllers
{
    //[Authorize]
    [ProducesResponseType(401)]
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(ListResponse<RecipeResponse>))]
        public async Task<IActionResult> GetRecipesListAsync(RecipeFilter recipe, ListOptions options, [FromServices]IRecipiesListQuery query)
        {
            var response = await query.RunAsync(recipe, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(RecipeResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRecipeAsync([FromBody] CreateRecipeRequest recipe, [FromServices]ICreateRecipeCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            RecipeResponse response = await command.ExecuteAsync(recipe);
            return CreatedAtRoute("GetSingleRecipe", new { recipeId = response.Id }, response);
        }

        [HttpGet("Get/{recipeId}", Name = "GetSingleRecipe")]
        [ProducesResponseType(200, Type = typeof(RecipeResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRecipeAsync(Guid recipeId, [FromServices] IRecipeQuery query)
        {
            RecipeResponse response = await query.RunAsync(recipeId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{recipeId}")]
        [ProducesResponseType(200, Type = typeof(RecipeResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRecipeAsync(Guid recipeId, [FromBody] UpdateRecipeRequest request, [FromServices] IUpdateRecipeCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                RecipeResponse response = await command.ExecuteAsync(recipeId, request);
                return response == null ? (IActionResult)NotFound($"recipe with id: {recipeId} not found") : Ok(response);
            }

            catch (ThisRequestNotFromOwnerException)
            {
                return StatusCode(403);
            }


        }

        [HttpDelete("Delete/{recipeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> DeleteRecipeAsync(Guid recipeId, [FromServices]IDeleteRecipeCommand command)
        {
            try
            {
                await command.ExecuteAsync(recipeId);
                return NoContent();
            }
            catch (ThisRequestNotFromOwnerException)
            {
                return StatusCode(403);
            }

        }
    }
}