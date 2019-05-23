using System.IO;

namespace SurviveOnSotka.DataAccess.DbImplementation.Files
{
    public class DeleteFilesCommand
    {
        public static void Execute(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
    }
}