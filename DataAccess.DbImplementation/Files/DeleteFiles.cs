using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SurviveOnSotka.DataAccess.DbImplementation.Files
{
    public class DeleteFiles
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
