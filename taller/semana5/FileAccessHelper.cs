using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace econradoS5B
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string path)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, path);
        }
    }
}
