using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.Controllers
{


    [Route("api/[controller]")]
    [ProducesResponseType(401)]
    //[Authorize]
    public class RateReviewsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public RateReviewsController(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        private async Task<User> GetCurrentUserAsync()
        {
            var contextUser = _httpContextAccessor.HttpContext.User;
            var result = await _userManager.GetUserAsync(contextUser);
            return result;
        }
        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(ListResponse<RateReviewResponse>))]
        public async Task<IActionResult> GetRateReviewsListAsync(
            RateReviewFilter rateReview,
            ListOptions options,
            [FromServices]IRateReviewsListQuery query)
        {
            var response = await query.RunAsync(rateReview, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRateReviewAsync( 
            [FromBody] CreateRateReviewRequest rateReview,
            [FromServices]ICreateRateReviewCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var currentUser = await GetCurrentUserAsync();
            try
            {
                var response = await command.ExecuteAsync(rateReview, currentUser.Id);
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
            RateReviewResponse response = await query.RunAsync(reviewId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{rateReviewId}")]
        [ProducesResponseType(200, Type = typeof(RateReviewResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRateReviewAsync(Guid rateReviewId, [FromBody] UpdateRateReviewRequest request, [FromServices] IUpdateRateReviewCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            RateReviewResponse response = await command.ExecuteAsync(rateReviewId, request);
            return response == null ? (IActionResult)NotFound($"rateReview with id: {rateReviewId} not found") : Ok(response);
        }

        [HttpDelete("Delete/{rateReviewId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRateReviewAsync(Guid rateReviewId, [FromServices]IDeleteRateReviewCommand command)
        {
            await command.ExecuteAsync(rateReviewId);
            return NoContent();
        }
    }
}
