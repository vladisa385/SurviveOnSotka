using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Categories;
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
    public class CategoriesController : ControllerBase
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ListResponse<CategoryResponse>>> GetCategoriesListAsync(CategoryFilter categoryFilter, ListOptions options, [FromServices] ListQuery<CategoryResponse, CategoryFilter> query) =>
            await query.RunAsync(categoryFilter, options);

        [HttpPost("Create")]
        [ModelValidation]
        [ProducesResponseType(201)]
        public async Task<ActionResult<CategoryResponse>> CreateCategoryAsync([FromBody] CreateCategoryRequest category, [FromServices] Command<CreateCategoryRequest, CategoryResponse> command)
        {
            var response = await command.ExecuteAsync(category);
            return CreatedAtRoute("GetSingleCategory", new { categoryId = response.Id }, response);
        }

        [HttpGet("Get/{categoryId}", Name = "GetSingleCategory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CategoryResponse>> GetCategoryAsync(Guid categoryId, [FromServices] Query<CategoryResponse> query) =>
            await query.RunAsync(categoryId) ?? (ActionResult<CategoryResponse>)NotFound();

        [HttpPut("Update")]
        [ModelValidation]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CategoryResponse>> UpdateCategoryAsync([FromBody] UpdateCategoryRequest request, [FromServices] Command<UpdateCategoryRequest, CategoryResponse> command) =>
            await command.ExecuteAsync(request);

        [HttpDelete("Delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCategoryAsync(SimpleDeleteRequest request, [FromServices] Command<SimpleDeleteRequest, EmptyResponse<CategoryResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}