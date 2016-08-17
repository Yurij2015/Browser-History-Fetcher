using BrowserHistoryFetcher.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.Pathing
{
    public class OperaPathManager : IBrowserInfo
    {
        private readonly static string HISTORY_FILE_PATH = String.Format("{0}\\Opera Software\\Opera Stable\\History",
                                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

        public string GetHistoryPath()
        {
            return HISTORY_FILE_PATH;
        }
        public BrowserEnum GetBrowserType()
        {
            return BrowserEnum.Opera;
        }

        public string GetTableName()
        {
            return "urls";
        }
    }
}
