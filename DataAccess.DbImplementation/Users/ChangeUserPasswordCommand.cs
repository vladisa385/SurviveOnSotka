using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class ChangeUserPasswordCommand : IChangeUserPasswordCommand
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public ChangeUserPasswordCommand(IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IHostingEnvironment appEnvironment)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }

        public async Task<UserResponse> ExecuteAsync(ChangePasswordUserRequest request)
        {
            var foundUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            IdentityResult result =
               await _userManager.ChangePasswordAsync(foundUser, request.OldPassword, request.NewPassword);
            if (!result.Succeeded)
            {

                throw new CannotChangePasswordExeption(result.Errors);

            }
            return _mapper.Map<User, UserResponse>(foundUser);

        }
    }
}
