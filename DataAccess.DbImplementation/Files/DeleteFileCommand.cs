using System.IO;

namespace SurviveOnSotka.DataAccess.DbImplementation.Files
{
    public class DeleteFileCommand
    {

        public static void Execute(string path)
        {
            File.Delete(path);
        }
    }
}
