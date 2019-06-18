using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Categories;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SurviveOnSotka.DataAccess.BaseOperation;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    [ProducesResponseType(401)]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ListResponse<CategoryResponse>>> GetCategoriesListAsync([FromQuery]CategoryFilter categoryFilter, [FromQuery]ListOptions options, [FromServices] ListQuery<CategoryResponse, CategoryFilter> query) =>
            await query.RunAsync(categoryFilter, options);

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<CategoryResponse>> CreateCategoryAsync(CreateCategoryRequest category, [FromServices] Command<CreateCategoryRequest, CategoryResponse> command)
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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CategoryResponse>> UpdateCategoryAsync(UpdateCategoryRequest request, [FromServices] Command<UpdateCategoryRequest, CategoryResponse> command) =>
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