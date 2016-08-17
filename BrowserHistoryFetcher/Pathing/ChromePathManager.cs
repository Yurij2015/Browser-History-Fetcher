using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserHistoryFetcher.Enums;

namespace BrowserHistoryFetcher.Pathing
{
    public class ChromePathManager : IBrowserInfo
    {
        private readonly static string WIN_7_8_10_HISTORY_PATH = String.Format("{0}\\Google\\Chrome\\User Data\\Default\\History",
                                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                                            ).Replace(@"\Roaming\", @"\Local\"); // workaround, chrome uses Local instead of Roaming folder ...

        public BrowserEnum GetBrowserType()
        {
            return BrowserEnum.Chrome;
        }

        public string GetHistoryPath()
        {
            return WIN_7_8_10_HISTORY_PATH;
        }

        public string GetTableName()
        {
            return "urls";
        }
    }
}
