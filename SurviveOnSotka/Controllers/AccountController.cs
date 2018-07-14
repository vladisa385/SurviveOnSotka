using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Db;

using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel;

namespace SurviveOnSotka.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDbContext appDbContext, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser([FromBody]RegistrationViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<User>(model);
            //var result = await _userManager.CreateAsync(userIdentity, model.Password + salt);

            //if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
            await _userManager.AddToRoleAsync(userIdentity, "user");
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}