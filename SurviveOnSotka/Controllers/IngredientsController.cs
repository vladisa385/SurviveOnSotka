using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Ingredients;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class IngredientsController : Controller
    {

        [HttpGet("GetList")]
        [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(ListResponse<IngredientResponse>))]
        public async Task<IActionResult> GetIngredientsListAsync(IngredientFilter ingredient, ListOptions options, [FromServices]IIngredientsListQuery query)
        {
            var response = await query.RunAsync(ingredient, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(201, Type = typeof(IngredientResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateIngredientAsync([FromBody] CreateIngredientRequest ingredient, [FromServices]ICreateIngredientCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            IngredientResponse response = await command.ExecuteAsync(ingredient);
            return CreatedAtRoute("GetSingleIngredient", new { ingredientId = response.Id }, response);
        }

        [HttpGet("Get/{ingredientId}", Name = "GetSingleIngredient")]
        [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(IngredientResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetIngredientAsync(Guid ingredientId, [FromServices] IIngredientQuery query)
        {
            IngredientResponse response = await query.RunAsync(ingredientId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{ingredientId}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200, Type = typeof(IngredientResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateingredientAsync(Guid ingredientId, [FromBody] UpdateIngredientRequest request, [FromServices] IUpdateIngredientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IngredientResponse response = await command.ExecuteAsync(ingredientId, request);
            return response == null ? (IActionResult)NotFound($"ingredient with id: {ingredientId} not found") : Ok(response);
        }

        [HttpDelete("Delete/{ingredientId}")]
        [ProducesResponseType(204)]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteingredientAsync(Guid ingredientId, [FromServices]IDeleteIngredientCommand command)
        {
            try
            {
                await command.ExecuteAsync(ingredientId);
                return NoContent();
            }
            catch (CannotDeleteIngredientWithRecipiesExeption exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}