using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;
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
    public class ReviewsController : Controller
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ListResponse<ReviewResponse>>> GetReviewsListAsync(ReviewFilter review, ListOptions options, [FromServices] ListQuery<ReviewResponse, ReviewFilter> query) =>
            await query.RunAsync(review, options);

        [HttpPost("Create")]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ReviewResponse>> CreateReviewAsync([FromBody] CreateReviewRequest request, [FromServices] Command<CreateReviewRequest, ReviewResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleReview", new { reviewId = response.Id }, response);
        }

        [HttpGet("Get/{reviewId}", Name = "GetSingleReview")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ReviewResponse>> GetReviewAsync(Guid reviewId, [FromServices] Query<ReviewResponse> query) =>
            await query.RunAsync(reviewId) ?? (ActionResult<ReviewResponse>)NotFound();

        [HttpPut("Update")]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(200, Type = typeof(ReviewResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ReviewResponse>> UpdateReviewAsync([FromBody] UpdateReviewRequest request, [FromServices] Command<UpdateReviewRequest, ReviewResponse> command) =>
            await command.ExecuteAsync(request);

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteReviewAsync(SimpleDeleteRequest request, [FromServices] Command<SimpleDeleteRequest, EmptyResponse<ReviewResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}