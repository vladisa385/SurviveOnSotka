using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;
using SurviveOnSotka.DataAccess.Exceptions;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class CreateUserCommand : Command<CreateUserRequest, UserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public CreateUserCommand(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        protected override async Task<UserResponse> Execute(CreateUserRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new CreateItemException(result.Errors.ToString());
            await _signInManager.SignInAsync(user, false);
            return _mapper.Map<User, UserResponse>(user);
        }
    }
}