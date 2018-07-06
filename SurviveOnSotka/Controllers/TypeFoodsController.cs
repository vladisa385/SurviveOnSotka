using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Db;
using SurviveOnSotka.Model.Entities;

namespace SurviveOnSotka.Controllers
{

    [Route("api/[controller]")]
    public class TypeFoodsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TypeFoodsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("{typeFoodId}")]
        [ProducesResponseType(200, Type = typeof(TypeFood))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid typeFoodId)
        {
            TypeFood response = await _appDbContext.TypeFoods.FirstOrDefaultAsync(u => u.Id == typeFoodId);
            return response == null
                ? (IActionResult)NotFound()
                : Ok(response);
        }


    }
}