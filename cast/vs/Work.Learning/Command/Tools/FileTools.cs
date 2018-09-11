using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Command.Tools
{
    public class FileTools
    {
        public void SaveInfo(string path, string suffix)
        {

            string filePath = string.Format("{0}/{1}.{2}",path, Guid.NewGuid().ToString(), suffix);

            if (!File.Exists(filePath))
            {

            }

            StreamWriter sw = new StreamWriter(filePath);

        }
    }
}