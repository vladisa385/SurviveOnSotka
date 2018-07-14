using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DB;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel;

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
        [ProducesResponseType(200, Type = typeof(TypeFoodViewModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTypeFoodAsync(Guid typeFoodId)
        {
            TypeFood model = await _appDbContext.TypeFoods.FirstOrDefaultAsync(u => u.Id == typeFoodId);
            TypeFoodViewModel response = new TypeFoodViewModel();
            return response == null
                ? (IActionResult)NotFound()
                : Ok(response);
        }

        [HttpPost("CreateTypeFood")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTypeFoodAsync([FromBody]TypeFoodViewModel newTypeFood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var filePath = Path.GetTempFileName();
            if (newTypeFood.Avatar.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await newTypeFood.Avatar.CopyToAsync(stream);
                }
            }
            FileModel file = new FileModel { Name = newTypeFood.Avatar.FileName, Path = filePath };
            TypeFood typeFood = new TypeFood { Icon = file, Id = new Guid(), Name = newTypeFood.Name };
            await _appDbContext.FileModels.AddAsync(file);
            await _appDbContext.TypeFoods.AddAsync(typeFood);
            await _appDbContext.SaveChangesAsync();
            return Ok("Ok");
        }

        [HttpGet("All")]
        [ProducesResponseType(200, Type = typeof(List<TypeFoodViewModel>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTypeFoodsAsync()
        {
            var allTypeFoods = await _appDbContext.TypeFoods.ToListAsync();
            return allTypeFoods.Count == 0
                ? (IActionResult)NotFound()
                : Ok(allTypeFoods);
        }

        [HttpPut("{typeFoodId}")]
        [ProducesResponseType(200, Type = typeof(TypeFood))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTypeFoodAsync(Guid typeFoodId, [FromBody]TypeFoodViewModel editTypeFood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TypeFood typeFood = await _appDbContext.TypeFoods.FirstOrDefaultAsync(u => u.Id == typeFoodId);
            if (typeFood == null)
                return NotFound();
            FileModel file = null;
            if (editTypeFood.Avatar != null)
            {
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await editTypeFood.Avatar.CopyToAsync(stream);
                }
                file = new FileModel { Name = editTypeFood.Avatar.FileName, Path = filePath };
                await _appDbContext.FileModels.AddAsync(file);
            }

            typeFood.Name = editTypeFood.Name;
            typeFood.Icon = file ?? typeFood.Icon;
            _appDbContext.TypeFoods.Update(typeFood);
            await _appDbContext.SaveChangesAsync();
            return Ok("Done");
        }
    }
}