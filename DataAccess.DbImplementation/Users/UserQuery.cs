using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using System;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class UserQuery : Query<UserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserQuery(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        protected override async Task<UserResponse> QueryItem(Guid userId)
        {
            var response = await _userManager.Users
                .Include(u => u.Recipies)
                .Include(u => u.Reviews)
                .Include(u => u.RateReviews)
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == userId);
            return response;
        }
    }
}