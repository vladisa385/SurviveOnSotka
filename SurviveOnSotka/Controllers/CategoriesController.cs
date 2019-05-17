using System;
using System.Threading.Tasks;
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
        [ProducesResponseType(401)]
        //[Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<CategoryResponse>))]
        public async Task<IActionResult> GetCategoriesListAsync(CategoryFilter categoryFilter, ListOptions options, [FromServices]ICategoriesListQuery query)
        {
            var response = await query.RunAsync(categoryFilter, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(201, Type = typeof(CategoryResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest category, [FromServices]ICreateCategoryCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                CategoryResponse response = await command.ExecuteAsync(category);
                return CreatedAtRoute("GetSingleCategory", new { categoryId = response.Id }, response);
            }
            catch (CannotCreateOrUpdateCategoryWithThisIParentCategoryGuidException exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpGet("Get/{categoryId}", Name = "GetSingleCategory")]
        //[Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(CategoryResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryAsync(Guid categoryId, [FromServices] ICategoryQuery query)
        {
            CategoryResponse response = await query.RunAsync(categoryId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{categoryId}")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(200, Type = typeof(CategoryResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdatecategoryAsync(Guid categoryId, [FromBody] UpdateCategoryRequest request, [FromServices] IUpdateCategoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                CategoryResponse response = await command.ExecuteAsync(categoryId, request);
                return response == null ? (IActionResult)NotFound($"category with id: {categoryId} not found") : Ok(response);
            }
            catch (CannotCreateOrUpdateCategoryWithThisIParentCategoryGuidException exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpDelete("Delete/{categoryId}")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
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