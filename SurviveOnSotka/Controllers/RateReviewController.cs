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
        [ProducesResponseType(200)]
        public async Task<ActionResult<ListResponse<RateReviewResponse>>> GetRateReviewsListAsync(RateReviewFilter filter, ListOptions options, [FromServices]ListQuery<RateReviewResponse, RateReviewFilter> query) =>
            await query.RunAsync(filter, options);

        [HttpPost("Create")]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<RateReviewResponse>> CreateRateReviewAsync([FromBody] CreateRateReviewRequest request, [FromServices]Command<CreateRateReviewRequest, RateReviewResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleRateReview", new { reviewId = response.ReviewId }, response);
        }

        [HttpGet("Get/{reviewId}", Name = "GetSingleRateReview")]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        public async Task<ActionResult<RateReviewResponse>> GetRateReviewAsync(Guid reviewId, [FromServices] Query<RateReviewResponse> query) =>
            await query.RunAsync(reviewId) ?? (ActionResult<RateReviewResponse>)NotFound();

        [HttpPut("Update")]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<RateReviewResponse>> UpdateRateReviewAsync([FromBody] UpdateRateReviewRequest request, [FromServices] Command<UpdateRateReviewRequest, RateReviewResponse> command) =>
            await command.ExecuteAsync(request);

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRateReviewAsync(SimpleDeleteRequest request, [FromServices]Command<SimpleDeleteRequest, EmptyResponse<RateReviewResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}