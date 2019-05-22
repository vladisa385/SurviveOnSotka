using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class UserQuery : IUserQuery
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserQuery(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserResponse> RunAsync(Guid userId)
        {

            UserResponse response = await _userManager.Users.Include("Recipies")
                 .Include("Recipies")
                .Include("Reviews")
                .Include("CheapPlaces")
                .Include("RateReviews")
                 .Include("RateCheapPlaces")
                .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == userId);
            return response;
        }
    }
}
