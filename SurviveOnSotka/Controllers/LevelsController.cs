using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Levels;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Levels;

namespace SurviveOnSotka.Controllers
{
    [ProducesResponseType(401)]
    [Route("api/[controller]")]
    public class LevelsController : Controller
    {

        [HttpGet("GetList")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<LevelResponse>))]
        public async Task<IActionResult> GetLevelsListAsync(LevelFilter level, ListOptions options, [FromServices]ILevelsListQuery query)
        {
            var response = await query.RunAsync(level, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(201, Type = typeof(LevelResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> CreateLevelAsync([FromBody] CreateLevelRequest level, [FromServices]ICreateLevelCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                LevelResponse response = await command.ExecuteAsync(level);
                return CreatedAtRoute("GetSingleLevel", new { levelId = response.Id }, response);
            }
            catch (CannotCreateOrUpdateLevelWithThisGuidLastLevelException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (CannotCreateOrUpdateLevelWithThisGuidNextLevelException exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpGet("Get/{levelId}", Name = "GetSingleLevel")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(LevelResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLevelAsync(Guid levelId, [FromServices] ILevelQuery query)
        {
            LevelResponse response = await query.RunAsync(levelId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{levelId}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200, Type = typeof(LevelResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> UpdatelevelAsync(Guid levelId, [FromBody] UpdateLevelRequest request, [FromServices] IUpdateLevelCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                LevelResponse response = await command.ExecuteAsync(levelId, request);
                return response == null ? (IActionResult)NotFound($"level with id: {levelId} not found") : Ok(response);
            }
            catch (CannotCreateOrUpdateLevelWithThisGuidLastLevelException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (CannotCreateOrUpdateLevelWithThisGuidNextLevelException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("Delete/{levelId}")]
        [ProducesResponseType(204)]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeletelevelAsync(Guid levelId, [FromServices]IDeleteLevelCommand command)
        {
            try
            {
                await command.ExecuteAsync(levelId);
                return NoContent();
            }
            catch (CannotDeleteLevelWithUsersExeption exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}