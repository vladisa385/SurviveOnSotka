using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.Filters
{
    public class InjectUserId: ActionFilterAttribute
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

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = GetCurrentUserAsync().Result;
            if (context.ActionArguments[_keyName] is Request request)
                request.SetUserId(user.Id);
        }
    }
}
