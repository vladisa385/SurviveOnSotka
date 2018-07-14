using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TasksManager.DataAccess.Tags
{
    public interface IDeleteTagCommand
    {
        Task ExecuteAsync(string tag);
    }
}
