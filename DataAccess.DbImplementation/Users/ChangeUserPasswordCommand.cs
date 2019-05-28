using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.BaseOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class ChangeUserPasswordCommand : Command<ChangePasswordUserRequest, UserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public ChangeUserPasswordCommand(IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IHostingEnvironment appEnvironment, AppDbContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
        }

        protected override async Task<UserResponse> Execute(ChangePasswordUserRequest request)
        {
            var foundUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == request.GetUserId());
            var result = await _userManager.ChangePasswordAsync(
                foundUser,
                request.OldPassword,
                request.NewPassword);
            if (!result.Succeeded)
                throw new UpdateItemException(result.Errors.ToString());
            return _mapper.Map<User, UserResponse>(foundUser);
        }
    }
}