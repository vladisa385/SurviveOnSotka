using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModell.Requests;
using System.Threading.Tasks;

namespace SurviveOnSotka.Filters
{
    public class InjectUserId : IAsyncActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly string _keyName;

        public InjectUserId(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _keyName = "request";
        }

        protected async Task<User> GetCurrentUserAsync()
        {
            var contextUser = _httpContextAccessor.HttpContext.User;
            var result = await _userManager.GetUserAsync(contextUser);
            return result;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = await GetCurrentUserAsync();
            if (context.ActionArguments[_keyName] is Request request)
                request.SetUserId(user.Id);
            await next();
        }
    }
}