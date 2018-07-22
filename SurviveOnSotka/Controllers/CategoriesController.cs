using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.Controllers
{

    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("GetList")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<CategoryResponse>))]
        public async Task<IActionResult> GetCategoriesListAsync(CategoryFilter categoryFilter, ListOptions options, [FromServices]ICategoriesListQuery query)
        {
            var response = await query.RunAsync(categoryFilter, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(201, Type = typeof(CategoryResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest category, [FromServices]ICreateCategoryCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CategoryResponse response = await command.ExecuteAsync(category);
            return CreatedAtRoute("GetSingleCategory", new { categoryId = response.Id }, response);
        }

        [HttpGet("Get/{categoryId}", Name = "GetSingleCategory")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(CategoryResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryAsync(Guid categoryId, [FromServices] ICategoryQuery query)
        {
            CategoryResponse response = await query.RunAsync(categoryId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{categoryId}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200, Type = typeof(CategoryResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdatecategoryAsync(Guid categoryId, [FromBody] UpdateCategoryRequest request, [FromServices] IUpdateCategoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CategoryResponse response = await command.ExecuteAsync(categoryId, request);
            return response == null ? (IActionResult)NotFound($"category with id: {categoryId} not found") : Ok(response);
        }

        [HttpDelete("Delete/{categoryId}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeletecategoryAsync(Guid categoryId, [FromServices]IDeleteCategoryCommand command)
        {
            try
            {
                await command.ExecuteAsync(categoryId);
                return NoContent();
            }
            catch (CannotDeleteCategoryWithRecipiesException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }


}