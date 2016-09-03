using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.Pathing
{
    internal class MozillaPathManager : IHistoryPath
    {
        private readonly static string APP_DATA_DIR_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private readonly static string BASE_SUB_PATH = String.Format("{0}\\Mozilla\\Firefox\\Profiles", APP_DATA_DIR_PATH);

        public string HistoryPath
        {
            get
            {
                // Mozilla not installed
                if (!Directory.Exists(BASE_SUB_PATH))
                    return APP_DATA_DIR_PATH;

                string profileDir = Directory.GetDirectories(BASE_SUB_PATH).FirstOrDefault();

                // Profile dir not found
                if (profileDir == null)
                    return APP_DATA_DIR_PATH;

                // Try to find history file
                return Path.Combine(profileDir, "places.sqlite");
            }
        }
    }
}
