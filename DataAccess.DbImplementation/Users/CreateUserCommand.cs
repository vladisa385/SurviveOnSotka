using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CreateUserCommand(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserResponse> ExecuteAsync(CreateUserRequest request)
        {
            var levelForBeginner = await _context.Levels.FirstAsync(u => u.MinScore == 0);
            User user = new User
            {
                Email = request.Email,
                UserName = request.Email,

                Level = levelForBeginner
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
