using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.Cities;
using SurviveOnSotka.DataAccess.DbImplementation.Cities;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Cities;

namespace SurviveOnSotka.Controllers
{

    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet("GetList")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<CityResponse>))]
        public async Task<IActionResult> GetCitiesListAsync(CityFilter filterCity, ListOptions options, [FromServices]ICitiesListQuery query)
        {
            var response = await query.RunAsync(filterCity, options);
            return Ok(response);
        }


        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(201, Type = typeof(CityResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCityAsync([FromBody] CreateCityRequest city, [FromServices]ICreateCityCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CityResponse response = await command.ExecuteAsync(city);
            return CreatedAtRoute("GetSingleCity", new { cityId = response.Id }, response);
        }


        [HttpGet("Get/{cityId}", Name = "GetSingleCity")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(CityResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCityAsync(Guid cityId, [FromServices] ICityQuery query)
        {
            CityResponse response = await query.RunAsync(cityId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{cityId}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200, Type = typeof(CityResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCityAsync(Guid cityId, [FromBody] UpdateCityRequest request, [FromServices] IUpdateCityCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CityResponse response = await command.ExecuteAsync(cityId, request);
            return response == null ? (IActionResult)NotFound($"City with id: {cityId} not found") : Ok(response);
        }

        [HttpDelete("Delete/{cityId}")]
        [ProducesResponseType(204)]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCityAsync(Guid cityId, [FromServices]IDeleteCityCommand command)
        {
            try
            {
                await command.ExecuteAsync(cityId);
                return NoContent();
            }
            catch (CannotDeleteCityWithCheapPlacesExeption exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
