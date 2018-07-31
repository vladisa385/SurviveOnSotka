using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(401)]
    [Authorize]
    public class RateReviewsController : Controller
    {

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(ListResponse<RateReviewResponse>))]
        public async Task<IActionResult> GetRateReviewsListAsync(RateReviewFilter rateReview,
            ListOptions options,
            [FromServices]IRateReviewsListQuery query)
        {
            var response = await query.RunAsync(rateReview, options);
            return Ok(response);
        }

        [HttpPost("Create/{reviewId}")]
        [ProducesResponseType(201, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRateReviewAsync(Guid reviewId, [FromBody] CreateRateReviewRequest rateReview, [FromServices]ICreateRateReviewCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            RateReviewResponse response = await command.ExecuteAsync(reviewId, rateReview);


            if (response == null)
                return NotFound();
            return CreatedAtRoute("GetSingleRateReview", new { reviewId = response.ReviewId }, response);

        }

        [HttpGet("Get/{reviewId}", Name = "GetSingleRateReview")]
        [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRateReviewAsync(Guid reviewId, [FromServices] IRateReviewQuery query)
        {
            RateReviewResponse response = await query.RunAsync(reviewId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{reviewId}")]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRateReviewAsync(Guid reviewId, [FromBody] UpdateRateReviewRequest request, [FromServices] IUpdateRateReviewCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            RateReviewResponse response = await command.ExecuteAsync(reviewId, request);
            return response == null ? (IActionResult)NotFound($"rateReview with id: {reviewId} not found") : Ok(response);
        }

        [HttpDelete("Delete/{reviewId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRateReviewAsync(Guid reviewId, [FromServices]IDeleteRateReviewCommand command)
        {
            await command.ExecuteAsync(reviewId);
            return NoContent();
        }
    }
}
