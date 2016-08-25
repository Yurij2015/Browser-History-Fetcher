using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.Pathing
{
    internal class OperaPathManager : IHistoryPath
    {
        private readonly static string HISTORY_FILE_PATH = String.Format("{0}\\Opera Software\\Opera Stable\\History",
                                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

        public string HistoryPath
        {
            get
            {
                return HISTORY_FILE_PATH;
            }
        }
    }
}
