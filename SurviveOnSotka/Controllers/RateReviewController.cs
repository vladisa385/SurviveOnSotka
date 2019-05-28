using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;
using SurviveOnSotka.ViewModell;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(401)]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class RateReviewsController : Controller
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(ListResponse<RateReviewResponse>))]
        public async Task<IActionResult> GetRateReviewsListAsync(RateReviewFilter filter, ListOptions options, [FromServices]ListQuery<RateReviewResponse, RateReviewFilter> query)
        {
            var response = await query.RunAsync(filter, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize]
        [ProducesResponseType(401)]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(201, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRateReviewAsync([FromBody] CreateRateReviewRequest request, [FromServices]Command<CreateRateReviewRequest, RateReviewResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleRateReview", new { reviewId = response.ReviewId }, response);
        }

        [HttpGet("Get/{reviewId}", Name = "GetSingleRateReview")]
        // [ServiceFilter(typeof(InjectUserId))]
        // [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetRateReviewAsync(Guid reviewId, [FromServices] Query<RateReviewResponse> query)
        {
            var response = await query.RunAsync(reviewId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        [Authorize]
        [ProducesResponseType(401)]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRateReviewAsync([FromBody] UpdateRateReviewRequest request, [FromServices] Command<UpdateRateReviewRequest, RateReviewResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        [Authorize]
        [ProducesResponseType(401)]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRateReviewAsync(SimpleDeleteRequest request, [FromServices]Command<SimpleDeleteRequest, RateReviewResponse> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}