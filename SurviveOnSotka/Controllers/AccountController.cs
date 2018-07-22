using System;
using System.Threading.Tasks;
using AutoMapper;
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
            catch (CannotCreateUser exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }
    }
}