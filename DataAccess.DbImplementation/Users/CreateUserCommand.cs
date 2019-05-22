using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class CreateUserCommand : ICreateUserCommand
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
        public async Task<UserResponse> ExecuteAsync(CreateUserRequest request)
        {
            User user = new User
            {
                Email = request.Email,
                UserName = request.Email,
            };

            // добавляем пользователя

            var result = await _userManager.CreateAsync(user, request.Password);
            // установка куки
            if (!result.Succeeded)
                throw new CannotCreateUserExeption(result.Errors);

            await _signInManager.SignInAsync(user, false);
            await _userManager.AddToRoleAsync(user, "user");
            return _mapper.Map<User, UserResponse>(user);

        }
    }
}
