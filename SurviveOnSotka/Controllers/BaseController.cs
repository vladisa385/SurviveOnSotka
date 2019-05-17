using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.Controllers
{
    public class BaseController:Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public BaseController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        protected async Task<User> GetCurrentUserAsync()
        {
            var contextUser = _httpContextAccessor.HttpContext.User;
            var result = await _userManager.GetUserAsync(contextUser);
            return result;
        }
    }
}
