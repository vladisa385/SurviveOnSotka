using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Files
{
    public interface IDeleteFileCommand
    {
        Task ExecuteAsync(Guid fileId);
    }
}
