using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Users
{
    public interface ILogOffUserCommand
    {
        Task ExecuteAsync();
    }
}
