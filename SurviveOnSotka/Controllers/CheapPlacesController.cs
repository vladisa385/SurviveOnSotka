using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.CheapPlaces;

namespace SurviveOnSotka.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CheapPlacesController : Controller
    {
        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(ListResponse<CheapPlaceResponse>))]
        public async Task<IActionResult> GetCheapPlacesListAsync(CheapPlaceFilter cheapPlace, ListOptions options, [FromServices]ICheapPlacesListQuery query)
        {
            var response = await query.RunAsync(cheapPlace, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(CheapPlaceResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCheapPlaceAsync([FromBody] CreateCheapPlaceRequest cheapPlace, [FromServices]ICreateCheapPlaceCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CheapPlaceResponse response = await command.ExecuteAsync(cheapPlace);
            return CreatedAtRoute("GetSingleCheapPlace", new { cheapPlaceId = response.Id }, response);
        }

        [HttpGet("Get/{cheapPlaceId}", Name = "GetSingleCheapPlace")]
        [ProducesResponseType(200, Type = typeof(CheapPlaceResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCheapPlaceAsync(Guid cheapPlaceId, [FromServices] ICheapPlaceQuery query)
        {
            CheapPlaceResponse response = await query.RunAsync(cheapPlaceId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{cheapPlaceId}")]
        [ProducesResponseType(200, Type = typeof(CheapPlaceResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCheapPlaceAsync(Guid cheapPlaceId, [FromBody] UpdateCheapPlaceRequest request, [FromServices] IUpdateCheapPlaceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CheapPlaceResponse response = await command.ExecuteAsync(cheapPlaceId, request);
                return response == null ? (IActionResult)NotFound($"cheapPlace with id: {cheapPlaceId} not found") : Ok(response);
            }
            catch (CannotCreateOrUpdateCheapPlaceWithCurrentGuidCity exception)
            {
                return BadRequest(exception.Message);
            }
            catch (ThisRequestNotFromOwnerException exception)
            {
                return StatusCode(403);
            }


        }

        [HttpDelete("Delete/{cheapPlaceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> DeleteCheapPlaceAsync(Guid cheapPlaceId, [FromServices]IDeleteCheapPlaceCommand command)
        {
            try
            {
                await command.ExecuteAsync(cheapPlaceId);
                return NoContent();
            }
            catch (ThisRequestNotFromOwnerException)
            {
                return StatusCode(403);
            }

        }
    }
}
