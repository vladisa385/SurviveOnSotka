using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.Controllers
{

    [Route("api/[controller]")]
    public class TypeFoodsController : Controller
    {

        [HttpGet("GetList")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(ListResponse<TypeFoodResponse>))]
        public async Task<IActionResult> GetTypeFoodsListAsync(TypeFoodFilter typeFood, ListOptions options, [FromServices]ITypeFoodsListQuery query)
        {
            var response = await query.RunAsync(typeFood, options);
            return Ok(response);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(201, Type = typeof(TypeFoodResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTypeFoodAsync([FromBody] CreateTypeFoodRequest typeFood, [FromServices]ICreateTypeFoodCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            TypeFoodResponse response = await command.ExecuteAsync(typeFood);
            return CreatedAtRoute("GetSingleTypeFood", new { typeFoodId = response.Id }, response);
        }

        [HttpGet("Get/{typeFoodId}", Name = "GetSingleTypeFood")]
        [Authorize(Roles = "user")]
        [ProducesResponseType(200, Type = typeof(TypeFoodResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTypeFoodAsync(Guid typeFoodId, [FromServices] ITypeFoodQuery query)
        {
            TypeFoodResponse response = await query.RunAsync(typeFoodId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("Update/{typeFoodId}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200, Type = typeof(TypeFoodResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdatetypeFoodAsync(Guid typeFoodId, [FromBody] UpdateTypeFoodRequest request, [FromServices] IUpdateTypeFoodCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TypeFoodResponse response = await command.ExecuteAsync(typeFoodId, request);
            return response == null ? (IActionResult)NotFound($"typeFood with id: {typeFoodId} not found") : Ok(response);
        }

        [HttpDelete("Delete/{typeFoodId}")]
        [ProducesResponseType(204)]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeletetypeFoodAsync(Guid typeFoodId, [FromServices]IDeleteTypeFoodCommand command)
        {
            try
            {
                await command.ExecuteAsync(typeFoodId);
                return NoContent();
            }
            catch (CannotDeleteTypeFoodWithIngredientsExeption exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }


}
