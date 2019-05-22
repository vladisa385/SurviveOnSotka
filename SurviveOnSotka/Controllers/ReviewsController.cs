using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.DataAccess.ViewModels;
using SurviveOnSotka.Entities;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.Controllers
{
    [ProducesResponseType(401)]
    [Route("api/[controller]")]
    public class ReviewsController : BaseController
    {
        public ReviewsController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(httpContextAccessor, userManager)
        {
        }
        [HttpGet("GetList")]
        // [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<ReviewResponse>))]
        [ProducesResponseType(500, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetReviewsListAsync(ReviewFilter review, ListOptions options, [FromServices] IReviewsListQuery query)
        {
            var response = await query.RunAsync(review, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        // [Authorize(Roles = "admin")]
        [ModelValidation]
        [ProducesResponseType(201, Type = typeof(ReviewResponse))]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReviewAsync([FromBody] CreateReviewRequest review, [FromServices] ICreateReviewCommand command)
        {
            var currentUser = await GetCurrentUserAsync();
            var response = await command.ExecuteAsync(currentUser.Id,review);
            return CreatedAtRoute("GetSingleReview", new {reviewId = response.Id}, response);
        }

        [HttpGet("Get/{reviewId}", Name = "GetSingleReview")]
        // [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(ReviewResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetReviewAsync(Guid reviewId, [FromServices] IReviewQuery query)
        {
            var response = await query.RunAsync(reviewId);
            return response == null ? (IActionResult) NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        // [Authorize(Roles = "admin")]
        [ModelValidation]
        [ProducesResponseType(200, Type = typeof(ReviewResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateReviewAsync([FromBody] UpdateReviewRequest request, [FromServices] IUpdateReviewCommand command)
        {
            var response = await command.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpDelete("Delete/{reviewId}")]
        [ProducesResponseType(204)]
        // [Authorize(Roles = "admin")]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteReviewAsync(Guid reviewId, [FromServices] IDeleteReviewCommand command)
        {
            await command.ExecuteAsync(reviewId);
            return NoContent();
        }

    }
}

