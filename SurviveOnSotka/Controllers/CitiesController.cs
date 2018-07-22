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
    }
}