using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using SurviveOnSotka.ViewModell;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SurviveOnSotka.DataAccess.BaseOperation;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(500, Type = typeof(ErrorDetails))]
    public class AccountController : Controller
    {
        [HttpGet("GetList")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<ListResponse<UserResponse>>> GetUsersListAsync(UserFilter filter, ListOptions options, [FromServices]ListQuery<UserResponse, UserFilter> query) =>
            await query.RunAsync(filter, options);

        [HttpGet("Get/{userId}", Name = "GetSingleUser")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserResponse>> GetUserAsync(Guid userId, [FromServices] Query<UserResponse> query) =>
            await query.RunAsync(userId) ?? (ActionResult<UserResponse>)NotFound();

        [HttpPost("Register")]
        [ModelValidation]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserResponse>> Register([FromBody]CreateUserRequest request, [FromServices] Command<CreateUserRequest, UserResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);
        }

        [HttpPut("UpdateUser")]
        [RequestSizeLimit(1000_000_000_000)]
        [Authorize]
        [ModelValidation]
        [ServiceFilter(typeof(InjectUserId))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        // [Authorize]
        public async Task<ActionResult<UserResponse>> UpdateUser([FromBody]UpdateUserRequest request, [FromServices] Command<UpdateUserRequest, UserResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);
        }

        [HttpPut("ChangeUserPassword")]
        [Authorize]
        [ServiceFilter(typeof(InjectUserId))]
        [ModelValidation]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        // [Authorize]
        public async Task<ActionResult<UserResponse>> ChangeUserPassword([FromBody]ChangePasswordUserRequest request, [FromServices] Command<ChangePasswordUserRequest, UserResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);
        }

        [HttpGet("IsAuthorized")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult IsAuthorized() => Ok();

        [HttpPost("Login")]
        [ModelValidation]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserResponse>> Login([FromBody]LoginUserRequest request, [FromServices] Command<LoginUserRequest, UserResponse> command) =>
            await command.ExecuteAsync(request);

        [HttpPost("LogOff")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<ActionResult<EmptyResponse<UserResponse>>> LogOff(EmptyRequest request, [FromServices] Command<EmptyRequest, EmptyResponse<UserResponse>> command) =>
            await command.ExecuteAsync(request);

        [HttpDelete("Delete")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> DeleteUserAsync(SimpleDeleteRequest request, [FromServices]Command<SimpleDeleteRequest, EmptyResponse<UserResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}