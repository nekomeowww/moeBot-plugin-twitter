using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace moeBot_plugin_twitter.modules
{
    public class FileUltilities
    {
        public bool FileExsit(string path)
        {
            bool result = File.Exists(path);
            return result;
        }
    }
}