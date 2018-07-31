using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.Controllers
{
    [ProducesResponseType(401)]
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        [HttpGet("GetList")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<ReviewResponse>))]
        public async Task<IActionResult> GetReviewsListAsync(ReviewFilter review, ListOptions options,
            [FromServices] IReviewsListQuery query)
        {
            var response = await query.RunAsync(review, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(201, Type = typeof(ReviewResponse))]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReviewAsync(Guid recipeId, [FromBody] CreateReviewRequest review,
            [FromServices] ICreateReviewCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ReviewResponse response = await command.ExecuteAsync(recipeId, review);
            if (response == null)
                return NotFound();
            return CreatedAtRoute("GetSingleReview", new { reviewId = response.Id }, response);
        }

        [HttpGet("Get/{reviewId}", Name = "GetSingleReview")]
        [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(ReviewResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetReviewAsync(Guid reviewId, [FromServices] IReviewQuery query)
        {
            ReviewResponse response = await query.RunAsync(reviewId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{reviewId}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200, Type = typeof(ReviewResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateReviewAsync(Guid reviewId, [FromBody] UpdateReviewRequest request,
            [FromServices] IUpdateReviewCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReviewResponse response = await command.ExecuteAsync(reviewId, request);
            return response == null ? (IActionResult)NotFound($"review with id: {reviewId} not found") : Ok(response);
        }

        [HttpDelete("Delete/{reviewId}")]
        [ProducesResponseType(204)]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeletereviewAsync(Guid reviewId, [FromServices] IDeleteReviewCommand command)
        {
            try
            {
                await command.ExecuteAsync(reviewId);
                return NoContent();
            }
            catch (ThisRequestNotFromOwnerException)
            {
                return StatusCode(403);
            }

        }
    }
}

