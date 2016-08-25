using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.Pathing
{
    internal class ChromePathManager : IHistoryPath
    {
        private readonly static string WIN_7_8_10_HISTORY_PATH = String.Format("{0}\\Google\\Chrome\\User Data\\Default\\History",
                                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                                            ).Replace(@"\Roaming\", @"\Local\"); // workaround, chrome uses Local instead of Roaming folder ...

        public string HistoryPath
        {
            get
            {
                return WIN_7_8_10_HISTORY_PATH;
            }
        }
    }
}
