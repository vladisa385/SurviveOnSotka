using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Db;

using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [HttpGet("GetList")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<UserResponse>))]
        public async Task<IActionResult> GetUsersListAsync(UserFilter user, ListOptions options, [FromServices]IUsersListQuery query)
        {
            var response = await query.RunAsync(user, options);
            return Ok(response);
        }

        [HttpGet("Get/{userId}", Name = "GetSingleUser")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserAsync(string userId, [FromServices] IUserQuery query)
        {
            UserResponse response = await query.RunAsync(userId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }
        [HttpPost("Register")]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register(CreateUserRequest user, [FromServices] ICreateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UserResponse response = await command.ExecuteAsync(user);
                return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);

            }
            catch (CannotCreateUserExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }


        [HttpPost("UpdateUser")]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest user, [FromServices] IUpdateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UserResponse response = await command.ExecuteAsync(user);
                return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);

            }
            catch (CannotCreateUserExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }


        [HttpPost("Login")]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login(LoginUserRequest user, [FromServices] ILoginUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UserResponse response = await command.ExecuteAsync(user);
                return Ok(response);
            }
            catch (IncorrectPasswordOrEmailExeption exception)
            {
                return BadRequest(exception.Message);
            }

        }


        [HttpPost("LogOff")]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<IActionResult> LogOff([FromServices] ILogOffUserCommand command)
        {
            await command.ExecuteAsync();
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("Delete/{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteUserAsync(string userId, [FromServices]IDeleteUserCommand command)
        {
            try
            {
                await command.ExecuteAsync(userId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}