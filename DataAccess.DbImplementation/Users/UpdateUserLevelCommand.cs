using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.DataAccess.DbImplementation.Users
{
    public class UpdateUserLevelCommand:IUpdateUserLevelCommand
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UpdateUserLevelCommand(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserResponse> ExecuteAsync(string userId)
        {
           var userForLevelUp = await  _userManager.FindByIdAsync(userId);
            if (userForLevelUp?.Level.NextLevel != null && userForLevelUp.CurrentScore >= userForLevelUp.Level.MaxScore)
            {
                userForLevelUp.Level = userForLevelUp.Level.NextLevel;
                await _userManager.UpdateAsync(userForLevelUp);
            }
            return _mapper.Map<User, UserResponse>(userForLevelUp);
        }
    }
}
