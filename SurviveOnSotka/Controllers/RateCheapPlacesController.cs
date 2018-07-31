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
        [ProducesResponseType(200, Type = typeof(ListResponse<RateCheapPlaceResponse>))]
        public async Task<IActionResult> GetRateCheapPlacesListAsync(RateCheapPlaceFilter rateCheapPlace,
            ListOptions options,
            [FromServices]IRateCheapPlacesListQuery query)
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
            return CreatedAtRoute("GetSingleRateCheapPlace", new { cheapPlaceId = response.CheapPlaceId }, response);

        }

        [HttpGet("Get/{cheapPlaceId}", Name = "GetSingleRateCheapPlace")]
        [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(RateCheapPlaceResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRateCheapPlaceAsync(Guid cheapPlaceId, [FromServices] IRateCheapPlaceQuery query)
        {
            RateCheapPlaceResponse response = await query.RunAsync(cheapPlaceId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{rateCheapPlaceId}")]
        [ProducesResponseType(200, Type = typeof(RateCheapPlaceResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateRateCheapPlaceAsync(Guid cheapPlaceId, [FromBody] UpdateRateCheapPlaceRequest request, [FromServices] IUpdateRateCheapPlaceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            RateCheapPlaceResponse response = await command.ExecuteAsync(cheapPlaceId, request);
            return response == null ? (IActionResult)NotFound($"rateCheapPlace with id: {cheapPlaceId} not found") : Ok(response);
        }

        [HttpDelete("Delete/{cheapPlaceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRateCheapPlaceAsync(Guid cheapPlaceId, [FromServices]IDeleteRateCheapPlaceCommand command)
        {
            await command.ExecuteAsync(cheapPlaceId);
            return NoContent();
        }
    }
}