using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;
using SurviveOnSotka.DataAccess.Exceptions;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class LoginUserCommand : Command<LoginUserRequest, UserResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public LoginUserCommand(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        protected override async Task<UserResponse> Execute(LoginUserRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(
                    request.Email,
                    request.Password,
                    request.RememberMe,
                    false);
            if (!result.Succeeded)
                throw new BadCredentialsException("Incorrect user password or email");
            var user = await _userManager.FindByEmailAsync(request.Email);
            return _mapper.Map<User, UserResponse>(user);
        }
    }
}