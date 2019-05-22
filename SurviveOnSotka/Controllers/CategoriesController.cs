using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Categories;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.Controllers
{

    [Route("api/[controller]")]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("GetList")]
        [ProducesResponseType(401)]
        //[Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<CategoryResponse>))]
        public async Task<IActionResult> GetCategoriesListAsync(CategoryFilter categoryFilter, ListOptions options, [FromServices] ListQuery<CategoryResponse,CategoryFilter> query)
        {
            var response = await query.RunAsync(categoryFilter, options);
            return Ok(response);
        }
        [HttpPost("Create")]
        //[Authorize(Roles = "admin")]
        [ModelValidation]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(201, Type = typeof(CategoryResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest category, [FromServices] Command<CreateCategoryRequest,CategoryResponse> command)
        {
            var response = await command.ExecuteAsync(category);
            return CreatedAtRoute("GetSingleCategory", new {categoryId = response.Id}, response);
        }
        [HttpGet("Get/{categoryId}", Name = "GetSingleCategory")]
        //[Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(CategoryResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryAsync(Guid categoryId, [FromServices] Query<CategoryResponse> query)
        {
            var response = await query.RunAsync(categoryId);
            return response == null ? (IActionResult) NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ModelValidation]
        [ProducesResponseType(200, Type = typeof(CategoryResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryRequest request, [FromServices] Command<UpdateCategoryRequest,CategoryResponse> command)
        {
            var response = await command.ExecuteAsync( request);
            return Ok(response);
        }
        [HttpDelete("Delete/{categoryId}")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCategoryAsync(SimpleDeleteRequest request, [FromServices] Command<SimpleDeleteRequest,CategoryResponse> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}