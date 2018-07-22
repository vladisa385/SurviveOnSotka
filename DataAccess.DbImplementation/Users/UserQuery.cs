using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class UserQuery : IUserQuery
    {
        private readonly UserManager<User> _userManager;

        public UserQuery(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserResponse> RunAsync(string userId)
        {
            UserResponse response = await _userManager.Users
                .ProjectTo<UserResponse>()
                .FirstOrDefaultAsync(p => p.Id == userId);
            return response;
        }
    }
}
