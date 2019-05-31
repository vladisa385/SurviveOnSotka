using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.BaseOperation;
using SurviveOnSotka.Db;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class UpdateUserCommand : Command<UpdateUserRequest, UserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UpdateUserCommand(UserManager<User> userManager, IMapper mapper, AppDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        protected override async Task<UserResponse> Execute(UpdateUserRequest request)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.GetUserId());
            foundUser.AboutYourself = request.AboutYourself;
            foundUser.FirstName = request.FirstName;
            foundUser.LastName = request.LastName;
            foundUser.Gender = request.Gender;
            foundUser.Avatar = request.Avatar;
            await _userManager.UpdateAsync(foundUser);
            return _mapper.Map<User, UserResponse>(foundUser);
        }
    }
}