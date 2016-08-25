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
        private readonly static string SUB_PATH = String.Format("{0}\\Mozilla\\Firefox\\Profiles",
                                                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

        private readonly static string HISTORY_FILE_PATH = Path.Combine(Directory.GetDirectories(SUB_PATH).First(), "places.sqlite");

        public string HistoryPath
        {
            get
            {
                return HISTORY_FILE_PATH;
            }
        }
    }
}
