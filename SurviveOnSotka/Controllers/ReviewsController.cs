using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(401)]
    public class ReviewsController : Controller
    {
        [HttpGet("GetList")]
        // [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<ReviewResponse>))]
        [ProducesResponseType(500, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetReviewsListAsync(ReviewFilter review, ListOptions options, [FromServices] ListQuery<ReviewResponse, ReviewFilter> query)
        {
            var response = await query.RunAsync(review, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        // [Authorize(Roles = "admin")]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(201, Type = typeof(ReviewResponse))]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReviewAsync([FromBody] CreateReviewRequest review, [FromServices] Command<CreateReviewRequest,ReviewResponse> command)
        {
            var response = await command.ExecuteAsync(review);
            return CreatedAtRoute("GetSingleReview", new {reviewId = response.Id}, response);
        }

        [HttpGet("Get/{reviewId}", Name = "GetSingleReview")]
        // [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(ReviewResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetReviewAsync(Guid reviewId, [FromServices] Query<ReviewResponse> query)
        {
            var response = await query.RunAsync(reviewId);
            return response == null ? (IActionResult) NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        // [Authorize(Roles = "admin")]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(200, Type = typeof(ReviewResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateReviewAsync([FromBody] UpdateReviewRequest request, [FromServices] Command<UpdateReviewRequest,ReviewResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(204)]
        // [Authorize(Roles = "admin")]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteReviewAsync(SimpleDeleteRequest request, [FromServices] Command<SimpleDeleteRequest,ReviewResponse> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }

    }
}

