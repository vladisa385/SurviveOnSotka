using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.DataAccess.DbImplementation.Files
{
    public class CreateFileCommand
    {
        public static async Task ExecuteAsync(IFormFile file, string path)
        {
            Directory.CreateDirectory(path);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);

            }

        }
    }
}
