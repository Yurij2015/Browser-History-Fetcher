using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.FileSystem
{
    internal static class FileManager
    {
        /// <summary>
        /// Copy file to System.IO.Path.GetTempPath().
        /// </summary>
        /// <param name="fromPath">Full file path.</param>
        /// <returns> File path on which file was saved.</returns>
        public static string CopyFileToTempFolder(string fromPath)
        {
            string fullOutputpath = Path.Combine(System.IO.Path.GetTempPath(), Path.GetFileName(fromPath));

            File.Copy(fromPath, fullOutputpath, true);
            return fullOutputpath;
        }
    }
}
