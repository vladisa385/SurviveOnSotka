using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using SurviveOnSotka.ViewModell;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SurviveOnSotka.DataAccess.BaseOperation;
using SurviveOnSotka.Filters;
using SurviveOnSotka.ViewModel.Implementanion;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [HttpGet("GetList")]
        // [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<UserResponse>))]
        public async Task<IActionResult> GetUsersListAsync(UserFilter filter, ListOptions options, [FromServices]ListQuery<UserResponse, UserFilter> query)
        {
            var response = await query.RunAsync(filter, options);
            return Ok(response);
        }

        [HttpGet("Get/{userId}", Name = "GetSingleUser")]
        //[Authorize]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserAsync(Guid userId, [FromServices] Query<UserResponse> query)
        {
            var response = await query.RunAsync(userId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPost("Register")]
        [ModelValidation]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody]CreateUserRequest request, [FromServices] Command<CreateUserRequest, UserResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);
        }

        [HttpPut("UpdateUser")]
        [Authorize]
        [ServiceFilter(typeof(InjectUserId))]
        [ModelValidation]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        // [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserRequest request, [FromServices] Command<UpdateUserRequest, UserResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);
        }

        [HttpPut("ChangeUserPassword")]
        [Authorize]
        [ServiceFilter(typeof(InjectUserId))]
        [ModelValidation]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        // [Authorize]
        public async Task<IActionResult> ChangeUserPassword([FromBody]ChangePasswordUserRequest request, [FromServices] Command<ChangePasswordUserRequest, UserResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);
        }

        [HttpGet("IsAuthorized")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(40)]
        public IActionResult IsAuthorized() => Ok();

        [HttpPost("Login")]
        [ModelValidation]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody]LoginUserRequest request, [FromServices] Command<LoginUserRequest, UserResponse> command)
        {
            var response = await command.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpPost("LogOff")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        // [Authorize]
        public async Task<IActionResult> LogOff(EmptyRequest request, [FromServices] Command<EmptyRequest, EmptyResponse<UserResponse>> command)
        {
            await command.ExecuteAsync(request);
            return Ok();
        }

        // [Authorize(Roles = "admin")]
        [HttpDelete("Delete/{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteUserAsync(SimpleDeleteRequest request, [FromServices]Command<SimpleDeleteRequest, EmptyResponse<UserResponse>> command)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}