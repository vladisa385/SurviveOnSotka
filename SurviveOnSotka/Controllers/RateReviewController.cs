using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(401)]
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
        [ProducesResponseType(201, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRateReviewAsync([FromBody] CreateRateReviewRequest request, [FromServices]ICreateRateReviewCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var currentUser = await GetCurrentUserAsync();
            try
            {
                var response = await command.ExecuteAsync(request,currentUser.Id);
                return CreatedAtRoute("GetSingleRateReview", new { reviewId = response.ReviewId }, response);
            }
            catch (CannotCreateOrUpdateRateReviewException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Get/{reviewId}", Name = "GetSingleRateReview")]
        // [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetRateReviewAsync(Guid reviewId, [FromServices] IRateReviewQuery query)
        {
            var currentUser = await GetCurrentUserAsync();
            var response = await query.RunAsync(reviewId,currentUser.Id);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update")]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRateReviewAsync([FromBody] UpdateRateReviewRequest request, [FromServices] IUpdateRateReviewCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var currentUser = await GetCurrentUserAsync();
            try
            {
                var response = await command.ExecuteAsync(request, currentUser.Id);
                return  Ok(response);
            }
            catch (CannotCreateOrUpdateRateReviewException e)
            {
                return NotFound(e.Message);
            }
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
