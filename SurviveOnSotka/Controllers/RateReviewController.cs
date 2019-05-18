using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Entities;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(401)]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    //[Authorize]
    public class RateReviewsController : BaseController
    {
        public RateReviewsController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(httpContextAccessor, userManager)
        {
        }

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(ListResponse<RateReviewResponse>))]

        public async Task<IActionResult> GetRateReviewsListAsync(RateReviewFilter filter, ListOptions options, [FromServices]IRateReviewsListQuery query)
        {
            var response = await query.RunAsync(filter, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [ModelValidation]
        [ProducesResponseType(201, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRateReviewAsync([FromBody] CreateRateReviewRequest request, [FromServices]ICreateRateReviewCommand command)
        {
            var currentUser = await GetCurrentUserAsync();
            var response = await command.ExecuteAsync(request,currentUser.Id);
            return CreatedAtRoute("GetSingleRateReview", new { reviewId = response.ReviewId }, response);
        }

        [HttpGet("Get/{reviewId}", Name = "GetSingleRateReview")]
        // [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetRateReviewAsync(Guid reviewId, [FromServices] IRateReviewQuery query)
        {
            var currentUser = await GetCurrentUserAsync();
            var response = await query.RunAsync(reviewId, currentUser.Id);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        [ModelValidation]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRateReviewAsync([FromBody] UpdateRateReviewRequest request, [FromServices] IUpdateRateReviewCommand command)
        {
            var currentUser = await GetCurrentUserAsync();
            var response = await command.ExecuteAsync(request, currentUser.Id);
            return  Ok(response);
        }

        [HttpDelete("Delete/{reviewId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRateReviewAsync(Guid reviewId, [FromServices]IDeleteRateReviewCommand command)
        {
            var currentUser = await GetCurrentUserAsync();
            await command.ExecuteAsync(reviewId,currentUser.Id);
            return NoContent();
        }
    }
}
