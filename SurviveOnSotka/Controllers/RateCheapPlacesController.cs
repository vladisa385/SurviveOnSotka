using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.RateCheapPlaces;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(401)]
    [Authorize]
    public class RateCheapPlacesController : Controller
    {

        [HttpGet("GetList")]
        [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(ListResponse<RateCheapPlaceResponse>))]
        public async Task<IActionResult> GetRateCheapPlacesListAsync(RateCheapPlaceFilter rateCheapPlace, ListOptions options, [FromServices]IRateCheapPlacesListQuery query)
        {
            var response = await query.RunAsync(rateCheapPlace, options);
            return Ok(response);
        }

        [HttpPost("Create/{cheapPlaceId}")]
        [ProducesResponseType(201, Type = typeof(RateCheapPlaceResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRateCheapPlaceAsync(Guid cheapPlaceId, [FromBody] CreateRateCheapPlaceRequest rateCheapPlace, [FromServices]ICreateRateCheapPlaceCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            RateCheapPlaceResponse response = await command.ExecuteAsync(cheapPlaceId, rateCheapPlace);


            if (response == null)
                return NotFound();
            return CreatedAtRoute("GetSingleRateCheapPlace", new { rateCheapPlaceId = response.CheapPlaceId }, response);

        }

        [HttpGet("Get/{rateCheapPlaceId}", Name = "GetSingleRateCheapPlace")]
        [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(RateCheapPlaceResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRateCheapPlaceAsync(Guid rateCheapPlaceId, [FromServices] IRateCheapPlaceQuery query)
        {
            RateCheapPlaceResponse response = await query.RunAsync(rateCheapPlaceId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{rateCheapPlaceId}")]
        [ProducesResponseType(200, Type = typeof(RateCheapPlaceResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRateCheapPlaceAsync(Guid rateCheapPlaceId, [FromBody] UpdateRateCheapPlaceRequest request, [FromServices] IUpdateRateCheapPlaceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            RateCheapPlaceResponse response = await command.ExecuteAsync(rateCheapPlaceId, request);
            return response == null ? (IActionResult)NotFound($"rateCheapPlace with id: {rateCheapPlaceId} not found") : Ok(response);
        }

        [HttpDelete("Delete/{rateCheapPlaceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRateCheapPlaceAsync(Guid rateCheapPlaceId, [FromServices]IDeleteRateCheapPlaceCommand command)
        {
            await command.ExecuteAsync(rateCheapPlaceId);
            return NoContent();
        }
    }
}